using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyect_de_Redes_version_1._0
{
    public class Host : LogicDevice, IActions
    {
        public Host(string name) : base(name, 1)
        {
            CurrentBit = 0;
            IsSending = false;
            string root = Tools.root + this.Name + "_data.txt";
            DataTxT = File.AppendText(root);
            lineToWrite = new string[2];
        }

        private string[] lineToWrite;
        public int CountTime { get; set; }
        public int CurrentBit { get; set; }
        public bool IsSending { get; set; }
        public string MacAddress { get; set; }
        public Frame FrameToSend { get; set; }
        public string RecieveFrame { get; set; }
        public StreamWriter DataTxT { get; set; }
        public void Send(string info, int time, bool end)
        {
            CountTime = info.Length * 10;
            WriteTxT(new string[] {time.ToString(), info[CurrentBit].ToString()}, false, true);
            if (CurrentBit == FrameToSend.CurrentFrame.Length - 1)
            {
                end = true;
                FrameToSend = null;
            }

            Ports[0].Send(info[CurrentBit].ToString(), time, end);
        }//metodo para enviar la informacion que se quiere hacia el puerto requerido
        public void Receive(Port receivePort, int time, bool end)
        {
            string bit = receivePort.Wire.GetThreadToRecieve(receivePort).Value.ToString();
            if (bit != "-1")
            {
                RecieveFrame += bit;
                if (end)
                {
                    Frame Rframe = new Frame(RecieveFrame);
                    string error = "";
                    VRC verifyError = new VRC();
                    if (!verifyError.IsCorrect(Rframe))
                        error = "ERROR";
                    string hexMacAddress = Tools.BinaryToHex(Rframe.MacAddressOrigin);
                    string hexData = Tools.BinaryToHex(Rframe.Data);
                    string toWrite = time + " " + hexMacAddress + " " + hexData + " " + error;
                    DataTxT.WriteLine(toWrite.ToUpper());
                    RecieveFrame = "";
                }
            }
            if (lineToWrite[0] != null  && (end || time.ToString() != lineToWrite[0]))
            {
                WriteTxT(lineToWrite, false, false);
            }
            lineToWrite[0] = time.ToString();
            lineToWrite[1] = bit;
        }

  
        public void WriteTxT(string[] line, bool collision, bool send)
        {
            if (!collision)
            {
                if (send)
                {
                    TxT.WriteLine(line[0] + " " + Name + " send " + line[1] + " ok");
                    //Console.WriteLine(time + " " + Name + " send " + bit + " ok");
                    //TxT.Close();
                }
                else
                {
                    if (line[1] != "-1")
                    {
                        TxT.WriteLine(line[0] + " " + Name + " receive " + line[1] + " ok ");
                        //Console.WriteLine(time + " " + Name + " receive " + bit + " ok ");
                        //TxT.Close();
                    }
                }
            }
            else
            {
                TxT.WriteLine(line[0] + " " + Name + " send " + line[1] + " collision ");
                //Console.WriteLine(time + " " + Name + " send " + bit + " collision ");
            }
            //TxT.Close();
        }
    }
}
