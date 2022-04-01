using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    public class Connect_Inst : Instruction
    {
        public Connect_Inst(int time, string[] args) : base(time, args, 2)
        {
        }

        public override void Execute(NetWork network)
        {
            //    string device1 = GetName(Args[0]);
            //    string device2 = GetName(Args[1]);
            //    NameLogicDevice[device1].Ports[int.Parse(device1[device1.Length - 1].ToString()) - 1].Connect(
            //    NameLogicDevice[device2].Ports[int.Parse(device2[device2.Length - 1].ToString()) - 1]);
            throw new NotImplementedException();
        }
    }
}
