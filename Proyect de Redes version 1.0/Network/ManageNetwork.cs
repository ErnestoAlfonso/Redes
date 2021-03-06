using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyect_de_Redes_version_1._0
{
    public class ManageNetWork
    {
        public ManageNetWork()
        {
            _NetWork = new NetWork();
            Time = 0;
        }
        public NetWork _NetWork { get; }
        public int Time { get; private set; }
        public void Manage()
        {
            _NetWork.PriorityQueue = Parser.ReadFile(new System.IO.StreamReader("D:\\Cibernética\\!!!!Tercer año\\Proyecto de Redes\\Redes 2.0\\Scripts.txt"));
            bool end = false;
            while (!end)
            {
                while (_NetWork.PriorityQueue.Size > 0 && _NetWork.PriorityQueue.Root.Time == Time)
                {
                    Instruction currentInstruction = _NetWork.PriorityQueue.Pop();
                    currentInstruction.Execute(_NetWork);
                }
                Time++;
                if (_NetWork.PriorityQueue.Size == 0)
                {

                    foreach (var item in _NetWork.Switches)
                    {
                        bool endF = false;
                        if (item.FramesToSend.Count > 0)
                        {
                            item.ActualFrame = item.FramesToSend.Peek();
                        }
                        while (item.ActualFrame != null)
                        {
                            item.Send(item.ActualFrame.NextBit(ref endF), Time, endF);
                            if (endF)
                            {
                                item.FramesToSend.Dequeue();
                                if (item.FramesToSend.Count > 0)
                                    item.ActualFrame = item.FramesToSend.Peek();
                                else item.ActualFrame = null;
                            }
                            Time += 10;
                        }
                    }
                    end = true;
                    foreach (var item in _NetWork.NameLogicDevice.Values)
                    {
                        item.TxT.Close();
                        if (item is Host)
                        {
                            Host aux = (Host)item;
                            aux.DataTxT.Close();
                        }
                    }
                }
            }
        }
    }
}
