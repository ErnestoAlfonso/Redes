using System;
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
        private int Count { get; set; }
        public Frame(string currentFrame)
        {
            CurrentFrame = "";
        }
        public Frame(string destination, string origin, string data)
        {
            databits = data.Length * 4;
            string sizeData = GetSize(data);
            string verifSize = "00000000";
            CurrentFrame = Tools.HexToBinary(destination + origin) + sizeData + verifSize + Tools.HexToBinary(data);
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

        public static Frame operator +(Frame frame1, string frame2)
        {
            frame1.CurrentFrame += frame2;
            return frame1;
        }
        public string CurrentFrame { get; set; }

        public string MacAddressDest { get; set; }

        public string MacAddressOrigin { get; set; }

        public string DataSize { get; set; }

        public string VerifSize { get; set; }

        public string Data { get; set; }

    }
}
