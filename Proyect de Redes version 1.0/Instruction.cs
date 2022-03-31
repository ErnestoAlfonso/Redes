namespace Proyect_de_Redes_version_1._0
{
    public abstract class Instruction
    {
        public Instruction(int time, string[] args)
        {
            Time = time;
            Args = args;
        }
        

        public int Time { get; set; }
        public string[] Args { get; set; }

        public abstract void Execute();
       
            //if (Inst_type == "create")
            //{
            //    if (Args[0] == "host")
            //    {
            //        Host host = new Host(Args[1]);
            //        NameLogicDevice.Add(host.Name, host);
            //    }
            //    if (Args[0] == "hub")
            //    {
            //        Hub hub = new Hub(Args[1], int.Parse(Args[2]));
            //        NameLogicDevice.Add(hub.Name, hub);
            //    }
            //}
            //if (Inst_type == "connect")
            //{
            //    string device1 = GetName(Args[0]);
            //    string device2 = GetName(Args[1]);
            //    NameLogicDevice[device1].Ports[int.Parse(device1[device1.Length - 1].ToString()) - 1].Connect(
            //    NameLogicDevice[device2].Ports[int.Parse(device2[device2.Length - 1].ToString()) - 1]);
            //}
            //if (Inst_type == "disconnect")
            //{
            //    string device1 = GetName(Args[0]);
            //    NameLogicDevice[device1].Ports[int.Parse(device1[device1.Length - 1].ToString()) - 1].Disconnect();


            //}
            //if (Inst_type == "send")
            //{
            //    Host aux = (Host)NameLogicDevice[Args[0]];
            //    aux.Send(Args[1]);
            //}
        
    }
}
