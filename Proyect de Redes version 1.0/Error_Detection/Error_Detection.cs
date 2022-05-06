using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0.Error_Detection
{
    public abstract class Error_Detection
    {
        public abstract void CodeFrame(Frame frame);
        public abstract string DecodeFrame(Frame frame);
        public abstract bool IsCorrect(Frame frame);
    }
}
