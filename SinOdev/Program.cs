using Microsoft.Win32;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinOdev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("sin(x) değerini hesaplamak için derece türünden bir sayı giriniz: ");
            double derece = Convert.ToDouble(Console.ReadLine());
            double x = DerecedenRadyanaCevir(derece);

            Console.Write("Taylor Serisinin derecesini giriniz: ");
            int n = Convert.ToInt32(Console.ReadLine());

            double sonuc = TaylorSerisiHesapla(x, n);
            Console.WriteLine($"Taylor serisini kullarak {derece}'in sinüs değeri yaklaşık: {sonuc}");
            Console.WriteLine($"Math.Sin({derece}) = {Math.Sin(x)} (karşılaştırma için)");

            Console.ReadKey();
        }

        static double TaylorSerisiHesapla(double x, int n)
        {
            double toplam = 0;
            double terim = x;
            int isaret = 1;

            for (int sayac = 1; sayac <= n; sayac += 2)
            {
                toplam += isaret * terim;
                terim *= x * x / ((sayac + 1) * (sayac + 2));
                isaret *= -1;
            }

            return toplam;
        }

        static double DerecedenRadyanaCevir(double derece)
        {
            return derece * Math.PI / 180;
        }
    }
}
