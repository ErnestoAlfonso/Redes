using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    public static class Tools
    {
        public const string root = "D:\\Cibernética\\!!!!Tercer año\\Proyecto de Redes\\Redes 2.0\\solutionsTxt\\";
        public static string HexToBinary(string hexValue)
        {
            string binValue = "";
            if (hexValue[0] == '0')
                binValue = "0000";
            binValue += Convert.ToString(Convert.ToInt32(hexValue, 16), 2);
            return binValue;
        }
        public static string BinaryToHex(string binValue)
        {
            string hexValue = "";
            hexValue = Convert.ToString(Convert.ToInt64(binValue, 2), 16);
            return hexValue;
        }


    }
}
