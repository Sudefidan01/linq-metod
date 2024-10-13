using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230827_LinqMetod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Linq metod sorgulamaları koleksiyonlar içerisindeki verileri metod yöntemi ile sorgulama , filtreleme , grupmala vs işlemlerini yapabildiğimiz modern sorgu yöntemidir

            List<Kisi> kisiler = new List<Kisi>()
            {
                new Kisi() {ad="Hakan",soyad="Sarı",sehir="Manisa"},
                new Kisi() {ad="Ayşe",soyad="Yılmaz",sehir="Bilecik"},
                new Kisi() {ad="Mehmet",soyad="Sönmez",sehir="Malatya"},
                new Kisi() {ad="Halil",soyad="Taşçı",sehir="İstanbul"},
                new Kisi() {ad="Fatma",soyad="Bilgi",sehir="İstanbul"},
                new Kisi() {ad="Elif",soyad="Taşçı",sehir="İstanbul"},
                new Kisi() {ad="Elif",soyad="Çetiner",sehir="İzmir"},
                new Kisi() {ad="Ahmet",soyad="Kaçar",sehir="Ankara"},
                new Kisi() {ad="Elif",soyad="Kaçar",sehir="Ankara"}

            };

            #region OrderBy(ASC)
            Console.WriteLine("OrderBy");
            Console.WriteLine("------------------");
            //Verileri ad verisine göre küçükten büyüğe sıralayalım

            //Klasik Linq Sorgulaması

            var kbListe = from k in kisiler
                          orderby k.ad ascending
                          select k;
            foreach (var item in kbListe)
            {
                item.Yazdir();
            }
            Console.WriteLine("Metod Sorgulaması");
            Console.WriteLine("-------------------");

            //Linq metod sorgulaması
            var kbListe2 = kisiler.OrderBy(k => k.ad);
            foreach (var item in kbListe2)
            {
                item.Yazdir();
            }
            #endregion
            Console.Clear();
            #region OrderBy(Descending)
            Console.WriteLine("Orderby Descending");
            //Koleksiyon içerisindeki verileri büyükten küçüğe doğru yazdıralım
            //Klasik Lİnq
            var bkListe = from k
                          in kisiler
                          orderby k.ad descending
                          select k;
            foreach (var item in bkListe)
            {
                item.Yazdir();
            }
            Console.WriteLine("----------------------");
            //Linq Metod Sorgulaması
            var bkListe2=kisiler.OrderByDescending(k => k.ad);
            foreach (var item in bkListe2)
            { item.Yazdir(); }
                       #endregion
            Console.Clear();
            #region ThenBy ve ThenByDescending
            //Linq metod yönteminde birden fazla sıralama işlemi kullanılacak ise orderby kullanımından sonraki kullanımlarda Then() metodunu kullanmanız gerekmektedir

            //KOleksiyon içerisindeki verileri ad a göre küçükten büyüğe soyad a göre büyükten küçüğe sıralayalım
            //Klasik Linq
            var kbAListe = from k in kisiler
                           orderby k.ad ascending, k.soyad descending
                           select k;
            foreach (var item in kbAListe)
            {
                item.Yazdir();
            }

            //Linq Metod Sorgulaması
            Console.WriteLine("----------");
            var kbAListe2=kisiler.OrderBy(k=>k.ad).ThenByDescending(k => k.soyad);
            foreach (var item in kbAListe2)
            {
                item.Yazdir();
            }

            #endregion

            Console.Clear();

            #region Where
            //Koleksiyon içerisinde şehiri "İstanbul" olan kişileri listeleyelim

            //Klasik Linq
            var fListe = from k in kisiler
                         where k.sehir.ToLower() == "istanbul"
                         select k;
            foreach (var item in fListe)
            {
                item.Yazdir();
            }

            Console.WriteLine("----------------------");
            var fListe2 = kisiler.Where(k => k.sehir.ToLower() == "istanbul");
            foreach (var item in fListe2)
            {
                item.Yazdir();
            }
            #endregion
            Console.Clear();
            #region Groupby
            //Koleksiyon içerisindeki verileri gruplamak için kullanırız
            //Koleksiyon içerisindeki kişileri şehir bilgilerine göre gruplayalım
            var gListe = kisiler.GroupBy(k => k.sehir);
            foreach (var item in gListe)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine("----------------");
                foreach (var kisi in item.OrderBy(k => k.ad))
                {
                    kisi.Yazdir();
                }
            }
            #endregion
            Console.ReadKey();
        }
    }
}
