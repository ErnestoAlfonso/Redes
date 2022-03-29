﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    class Wire
    {
        public Wire(Port port1, Port port2)
        {
            Port1 = port1;
            Port2 = port2;
            Value = -1; //en caso de que no haya nada en el cable
        }
        public Port Port1 { get; }
        public Port Port2 { get; }
        
        public int Value { get; set; }  
    }
}