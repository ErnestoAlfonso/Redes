using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    public class Frame
    {
        public Frame()
        {
            CurrentFrame = "";
        }

        public Frame(string destination, string origin, string data)
        {
            SizeData = GetSize(data);

            CurrentFrame = Tools.HexToBinary(destination + origin + data);
        }

        public string GetSize(string data)
        {
            int rest = data.Length % 2;
            int bytes = data.Length / 2 + rest;
            string binBytes = Convert.ToString(bytes, 2);
            for (int i = binBytes.Length; i < 8; i++)
                binBytes = "0" + binBytes;
            return binBytes;
        }

        public static Frame operator +(Frame frame1, string frame2)
        {
            frame1.CurrentFrame += frame2;
            return frame1;
        }
        public string CurrentFrame { get; set; }

        public string MacAddressDest { get { return CurrentFrame.Substring(0, 16); } }
         
        public string MacAddressOrigin { get { return CurrentFrame.Substring(16, 16); } }

        public string SizeData { get; }

    }
}
