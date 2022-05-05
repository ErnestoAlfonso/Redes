using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    public static class Tools
    {
        public const string root = @"D:\Universidad\Tercer año\Primer semestre\Redes\Proyecto de Redes\Redes\solutionsTxt\";
        public static string HexToBinary(string hexValue)
        {
            string binValue = "";
            binValue = Convert.ToString(Convert.ToInt32(hexValue, 16), 2);
            return binValue;
        }
        public static string BinaryToHex(string binValue)
        {
            string hexValue = "";
            hexValue = Convert.ToString(Convert.ToInt32(binValue, 2), 16);
            return hexValue;
        }
     

    }
}
