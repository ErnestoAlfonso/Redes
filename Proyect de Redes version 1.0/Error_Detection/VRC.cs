using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0.Error_Detection
{
    public class VRC : Error_Detection
    {
        public override string CodeFrame(Frame frame)
        {
            string verification_bits = "";

            for(int i = 0; i < frame.CurrentFrame.Length; i += 8)
            {
                int parity = frame.CurrentFrame[i];
                for(int j = 1; j<8; j++)
                {
                    parity^=frame.CurrentFrame[i+j];
                }
                verification_bits += parity;
            }

            return verification_bits;
        }

        public override string DecodeFrame(Frame frame)
        {
            return frame.CurrentFrame.Substring(16 * 3 + Convert.ToInt32(
                frame.SizeData, 2) * 8);
        }

        public override bool IsCorrect(Frame frame)
        {
            //return CodeFrame(frame).Substring()
        }
    }
}
