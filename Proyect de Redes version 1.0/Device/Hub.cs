using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyect_de_Redes_version_1._0
{
    public class Hub : LogicDevice, IActions
    {
        public Hub(string name, int numberOfPorts) : base(name, numberOfPorts)
        {
            lineToWrite = new string[numberOfPorts + 1];
        }
        private string[] lineToWrite;

        public int ReceivePort { get; set; }
        public void Send(string bit, int time, bool end)
        {
            for (int i = 0; i < Ports.Length; i++)
            {
                if (i != ReceivePort)
                {
                    if (Ports[i].Wire != null)
                    {
                        int wireBit = -1;
                        if (Ports[i].Wire.GetThreadToSend(Ports[i]).Value == -1)
                            Ports[i].Wire.GetThreadToSend(Ports[i]).Value = int.Parse(bit);
                        else
                            wireBit = Ports[i].Wire.GetThreadToSend(Ports[i]).Value;
                        if (bit != "-1")
                        {
                            if (wireBit != -1)
                            {
                                Ports[i].Wire.GetThreadToSend(Ports[i]).Value = wireBit ^ int.Parse(bit);
                            }
                            lineToWrite[i + 1] = Ports[i].Wire.GetThreadToSend(Ports[i]).Value.ToString();
                        }
                        else
                            Ports[i].Wire.GetThreadToSend(Ports[i]).Value = int.Parse(bit);
                        Port portR = Ports[i].Wire.ConnectedPort(Ports[i].Name);
                        if (portR.Owner is Host)
                        {
                            Host hostR = (Host)portR.Owner;
                            hostR.Ports[0].Wire.GetThreadToRecieve(hostR.Ports[0]).Value = Ports[i].Wire.GetThreadToSend(Ports[i]).Value;
                            hostR.Receive(portR, time, end);
                        }
                        else
                        {
                            Hub hubR = (Hub)portR.Owner;
                            var currentPort = hubR.Ports[int.Parse(portR.Name[int.Parse(portR.Name[portR.Name.Length - 1].ToString()) - 1].ToString())];
                            currentPort.Wire.GetThreadToRecieve(currentPort).Value = Ports[i].Wire.GetThreadToSend(Ports[i]).Value;
                            hubR.Receive(portR, time, end);
                        }
                    }
                }
            }
        }
        public void Receive(Port receivePort, int time, bool end)
        {//falta escribir el txt
            if (lineToWrite[0] != null && (end || time.ToString() != lineToWrite[0]))
            {
                WriteTxT(lineToWrite);
            }
            ReceivePort = int.Parse(receivePort.Name[receivePort.Name.Length - 1].ToString());
            string bit = receivePort.Wire.GetThreadToRecieve(receivePort).Value.ToString();
            if (bit != "-1")
                lineToWrite[ReceivePort + 1] = bit;
            lineToWrite[0] = time.ToString();
            Send(bit, time, end);
        }
        public void WriteTxT(string[] line)
        {
            for (int i = 1; i < line.Length; i++)
            {
                if (i - 1 == ReceivePort)
                {
                    TxT.WriteLine(line[0] + " " + Ports[i - 1].Name + " receive " + line[i]);
                    //Console.WriteLine(time + " " + Ports[i].Name + " receive " + bit);
                }
                else
                {
                    TxT.WriteLine(line[0] + " " + Ports[i - 1].Name + " send " + line[i]);
                    //Console.WriteLine(time + " " + Ports[i].Name + " send " + bit);
                }
            }
            //TxT.Close();
        }
    }
}
