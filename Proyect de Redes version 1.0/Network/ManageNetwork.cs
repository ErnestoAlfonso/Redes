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
            _NetWork.PriorityQueue = Parser.ReadFile(new System.IO.StreamReader("D:\\Universidad\\Tercer año\\Primer semestre\\Redes\\Proyecto de Redes\\Redes\\Scripts.txt"));
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
                    end = true;
                    foreach (var item in _NetWork.NameLogicDevice.Values)
                    {
                        item.TxT.Close();
                    }
                }
            }

        }





    }
}
