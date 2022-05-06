﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    public class Frame
    {
        private int databits;

        private int Count { get; set; }

        private string _verifbits;
        public Frame(string frame)
        {
            MacAddressDest = frame.Substring(0, 16);
            MacAddressOrigin = frame.Substring(16, 16);
            DataSize = frame.Substring(32, 8);
            VerifSize = frame.Substring(40, 8);
            int dataBytes = Convert.ToInt32(DataSize, 2);
            databits = dataBytes * 8;
            Data = frame.Substring(48, databits);
            VerifBits = frame.Substring(48 + databits);

        }
        public Frame(string destination, string origin, string data)
        {
            databits = data.Length * 4;
            Count = 0;

            MacAddressDest = Tools.HexToBinary(destination);
            MacAddressOrigin = Tools.HexToBinary(origin);
            DataSize = GetSize(data);
            Data = Tools.HexToBinary(data);
            VerifSize = "00000000";
            _verifbits = "";
        }

        public string GetSize(string data)
        {
            int rest = data.Length % 2;
            int bytes = data.Length / 2 + rest;
            string binBytes = Convert.ToString(bytes, 2);
            for (int i = binBytes.Length; i < 8; i++)
                binBytes = "0" + binBytes;
            
            if (rest > 0)
                data = "0" + data;
            return binBytes;
        }

        public string NextBit()
        {
            string bit = CurrentFrame[Count].ToString();
            Count++;
            return bit;
        }

        public string CurrentFrame { get { return MacAddressDest + MacAddressOrigin + DataSize + VerifSize + Data + VerifBits; } }

        public string MacAddressDest { get; set; }

        public string MacAddressOrigin { get; set; }

        public string DataSize { get; set; }

        public string VerifSize { get; set; }

        public string Data { get; set; }

        public string VerifBits {
            get => _verifbits;
            set { 
                _verifbits = value;
                string bytes = Convert.ToString(_verifbits.Length, 2);
                for (int i = bytes.Length; i < 8; i++)
                    bytes = "0" + bytes;
            } 
        }
    }
}
