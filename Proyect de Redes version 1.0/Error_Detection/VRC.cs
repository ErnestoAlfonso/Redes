using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    public class VRC : Error_Detection
    {
        private string _ParityCount(string s)
        {
            string verification_bits = "";

            for(int i = 0; i < s.Length-8; i += 8)
            {
                int parity = s[i];
                for(int j = 1; j<8; j++)
                {
                    parity^=s[i+j];
                }
                verification_bits += parity;
            }

            return verification_bits;
        }
        public override void CodeFrame(Frame frame)
        {
            
            string bytes = Convert.
                ToString(6 + Convert.ToInt64(frame.DataSize,2)/8, 2);
            for (int i = bytes.Length; i < 8; i++)
                bytes = "0" + bytes;
            frame.VerifSize = bytes;

            frame.VerifBits = _ParityCount(frame.CurrentFrame);
        }

        public override string DecodeFrame(Frame frame)
        {
            return frame.VerifBits;
        }

        public override bool IsCorrect(Frame frame)
        {
            return frame.VerifBits == _ParityCount(frame.CurrentFrame.
                Substring(0,48 + Convert.ToInt32(frame.DataSize, 2)));
        }
    }
}
