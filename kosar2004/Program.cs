using kosar2004.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace kosar2004
{
    class Program
    {
        static List<Eredmeny> eredmenyek = new List<Eredmeny>();
        static void Main(string[] args)
        {
            BeolvasasF02();
            F03();
            F04();
            F05();
            F06();
            F07();
            Console.ReadLine();
        }

        private static void F07()
        {
            Console.WriteLine("7. feladat:");
            eredmenyek.GroupBy(a => a.helyszin).Where(y => y.Count() >= 20).ToList().ForEach(b => Console.WriteLine($"\t{b.Key} {b.Count()}"));
        }

        private static void F06()
        {
            Console.WriteLine("6. feladat:");
            eredmenyek.Where(a => a.idopont == "2004-11-21").ToList().ForEach(a => Console.WriteLine($"\t{a.hazai} - {a.idegen} ({a.hazai_pont}:{a.idegen_pont})"));
        }

        private static void F05()
        {
            Console.WriteLine($"5. feladat: barcelonai csapat neve: {eredmenyek.Where(a => a.hazai.Contains("Barcelona")).FirstOrDefault().hazai}");
        }

        private static void F04()
        {
            Console.WriteLine($"4. feladat: Volt döntetlen? {(eredmenyek.All(a => a.hazai_pont == a.idegen_pont)? "igen" : "nem")}");
        }

        private static void F03()
        {
            Console.WriteLine($"3. feladat: Real Madrid: Hazai: {eredmenyek.Count(a => a.hazai.Equals("Real Madrid"))} Idegen: {eredmenyek.Count(a => a.idegen.Equals("Real Madrid"))}");
        }

        private static void BeolvasasF02() => Resources.eredmenyek.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Skip(1).ToList().ForEach(a => eredmenyek.Add(new Eredmeny(a)));

    }
    class Eredmeny
    {
        public string hazai { get; set; }
        public string idegen { get; set; }
        public int hazai_pont { get; set; }
        public int idegen_pont { get; set; }
        public string helyszin { get; set; }
        public string idopont { get; set; }

        public Eredmeny(string sor)
        {
            string[] darab = sor.Split(';');

            this.hazai = darab[0];
            this.idegen = darab[1];
            this.hazai_pont = int.Parse(darab[2]);
            this.idegen_pont = int.Parse(darab[3]);
            this.helyszin = darab[4];
            this.idopont = darab[5];
        }
    }
}