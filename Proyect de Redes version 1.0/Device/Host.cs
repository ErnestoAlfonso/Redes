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
        }
        public int CountTime { get; set; }
        public int CurrentBit { get; set; }
        public bool IsSending { get; set; }

        public string MacAddress { get; set; }


        public void Send(string info, int time)
        {
            CountTime = info.Length * 10;
            WriteTxT(time, info[CurrentBit].ToString(), false, true);
            Ports[0].Send(info[CurrentBit].ToString(), time);
        }//metodo para enviar la informacion que se quiere hacia el puerto requerido
        public void Receive(Port receivePort, int time)
        {
            WriteTxT(time, receivePort.Wire.GetThreadToRecieve(receivePort).Value.ToString(), false, false);
        }
        public void WriteTxT(int time, string bit, bool collision, bool send)
        {
            if (!collision)
            {
                if (send)
                {
                    TxT.WriteLine(time + " " + Name + " send " + bit + " ok");
                    //Console.WriteLine(time + " " + Name + " send " + bit + " ok");
                    //TxT.Close();
                }
                else
                {
                    if (bit != "-1")
                    {
                        TxT.WriteLine(time + " " + Name + " receive " + bit + " ok ");
                        //Console.WriteLine(time + " " + Name + " receive " + bit + " ok ");
                        //TxT.Close();
                    }
                }
            }
            else
            {
                TxT.WriteLine(time + " " + Name + " send " + bit + " collision ");
                //Console.WriteLine(time + " " + Name + " send " + bit + " collision ");
            }
               //TxT.Close();
        }
    }
}
