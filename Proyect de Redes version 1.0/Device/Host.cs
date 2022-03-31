﻿using System;
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
        }
        public int CountTime { get; set; }
        public int CurrentBit { get; set; }


        public void Send(string info)
        {
            CountTime = info.Length * 10;
            Ports[0].Send(info[CurrentBit].ToString());
        
        }//metodo para enviar la informacion que se quiere hacia el puerto requerido
        public void Receive(Port receivePort)
        {
            throw new NotImplementedException();
        }

    }
}