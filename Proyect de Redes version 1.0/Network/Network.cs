using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHeap;


namespace Proyect_de_Redes_version_1._0
{
    class NetWork
    {
        public NetWork()
        {
            NameLogicDevice = new Dictionary<string, LogicDevice>();
            AllWires = new LinkedList<Wire>(); 
        }
        public Heap<Instruction> PriorityQueue { get; set; }
        public Dictionary<string, LogicDevice> NameLogicDevice { get; set; }

        public int TimeToClean { get; set; }
        public LinkedList<Wire> AllWires { get; set; }    

        public void CleanNetWork()
        {
            foreach (var wire in AllWires)
            {
                wire.Value = -1;    
            }


        }
      

    }
}
