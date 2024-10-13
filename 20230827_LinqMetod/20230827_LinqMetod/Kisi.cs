using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230827_LinqMetod
{
    internal class Kisi
    {
        public string ad, soyad, sehir;

        public void Yazdir()
        {
            Console.WriteLine("{0} {1} - {2}",ad,soyad,sehir);
        }
    }
}
