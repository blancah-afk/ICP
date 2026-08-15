using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWMXPCI
{
    public class UOM
    {

        public static int Segundos(int i)
        {
            return i * 1000;
        }

        public static int Minutos(int i)
        {
            return i * 60000;
        }


        public static int Horas(int hrs)
        {
            return Minutos((hrs * 60));
        }
    }

}
