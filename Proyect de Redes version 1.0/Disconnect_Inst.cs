using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    public class Disconnect_Inst : Instruction
    {
        public Disconnect_Inst(int time, string[] args) : base(time, args)
        {
        }

        public override void Execute()
        {
            //    string device1 = GetName(Args[0]);
            //    NameLogicDevice[device1].Ports[int.Parse(device1[device1.Length - 1].ToString()) - 1].Disconnect();
            throw new NotImplementedException();
        }
    }
}
