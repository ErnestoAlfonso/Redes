using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHeap;


namespace Proyect_de_Redes_version_1._0
{
    public class NetWork
    {
        public NetWork()
        {
            NameLogicDevice = new Dictionary<string, LogicDevice>();
        }
        public Heap<Instruction> PriorityQueue { get; set; }
        public Dictionary<string, LogicDevice> NameLogicDevice { get; set; }
        public int SendTime { get; set; }   
    
      

    }
}
