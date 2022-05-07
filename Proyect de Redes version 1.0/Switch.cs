using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    public class Switch : LogicDevice, IActions
    {
        private bool[] PortToSend;
        public Switch(string name, int numberPorts) : base(name, numberPorts)
        {
            InfoReceived = new string[numberPorts];
            PortToSend = new bool[numberPorts];
            FramesToSend = new Queue<Frame>();
            CurrentPortR = -1;
            CurrentMacAddress = new List<string>();
            for (int i = 0; i < Ports.Length; i++)
            {
                CurrentMacAddress.Add(null);
            }
        }
        public List<string> CurrentMacAddress { get; set; }

        public string[] InfoReceived { get; set; }
        public int ReceivePort { get; set; }
        public Queue<Frame> FramesToSend { get; set; }

        public Frame ActualFrame { get; set; }
        public int CurrentPortR { get; set; }


        public void Receive(Port receivePort, int time, bool end)
        {
            ReceivePort = int.Parse(receivePort.Name[receivePort.Name.Length - 1].ToString());
            string bit = receivePort.Wire.GetThreadToRecieve(receivePort).Value.ToString();
            if (bit != "-1")
            {
                InfoReceived[ReceivePort] += bit;
                CheckFrame(InfoReceived[ReceivePort]);
                if (FramesToSend.Count > 0)
                {
                    ActualFrame = FramesToSend.Peek();
                    if (CurrentPortR == -1)
                        CurrentPortR = CurrentMacAddress.IndexOf(ActualFrame.MacAddressOrigin);
                    Send(ActualFrame.NextBit(ref end), time, end);
                    if (end == true)
                        FramesToSend.Dequeue();
                }
            }
        }

        private void CheckFrame(string frame)
        {
            int dataBits = 0;
            int verifBits = 0;
            if (frame.Length < 16)
                return;
            else if (frame.Length == 32)
            {
                string origin = frame.Substring(16, 16);
                CurrentMacAddress[ReceivePort] = origin;
            }
            else if (frame.Length > 48)
            {
                dataBits = Convert.ToInt32(frame.Substring(32, 8), 2) * 8;
                verifBits = Convert.ToInt32(frame.Substring(40, 8), 2);
                if (frame.Length == 48 + dataBits + verifBits)
                {
                    Frame currentFrame = new Frame(InfoReceived[ReceivePort]);
                    FramesToSend.Enqueue(currentFrame);
                    InfoReceived[ReceivePort] = "";
                }
            }
        }

        private bool IsForAll(string address)
        {
            return address == "1111111111111111";
        }

        public void Send(string info, int time, bool end)
        {
            string address = Tools.BinaryToHex(ActualFrame.MacAddressDest).ToUpper();
            if (!IsForAll(address))
            {
                for (int i = 0; i < Ports.Length; i++)
                {
                    if (Ports[i].Wire != null)
                    {
                        Port portR = Ports[i].Wire.ConnectedPort(Ports[i].Name);
                        if (portR.Owner is Host)
                        {
                            Host hostR = (Host)portR.Owner;
                            if (hostR.MacAddress == address)
                            {
                                Ports[i].Send(info, time, end);
                                return;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < Ports.Length; i++)
                {
                    if (i != CurrentPortR)
                        Ports[i].Send(info, time, end);
                }
            }
        }
    }
}
