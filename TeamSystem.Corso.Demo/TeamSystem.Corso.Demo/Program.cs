using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TeamSystem.Corso.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Test1 = 10;
            string Esempio = "       Prova esempio";
            Console.WriteLine(Esempio.Trim().Substring(6));

            DateTime DataOdierna = DateTime.Now;
            Console.WriteLine(DataOdierna.Hour + ":" + DataOdierna.Minute);

            //Applicazione di un pattern di trasformazione
            Console.WriteLine(DataOdierna.ToString("dd/mm/yy"));

            //Se non specifico il tipo lo riconosce automaticamente
            var Test2 = "prova";

            Console.WriteLine("Primo esempio");
            Console.WriteLine("Premere per uscire:");

            //Conversioni
            string valore1 = "50";
            //int.parse
            int valore2 = int.Parse(valore1);
            Console.WriteLine("Conversione con int.Pars: " + valore2);
            //System.convert
            valore2 = Convert.ToInt32(valore1);
            Console.WriteLine("Conversione con Convert.ToInt32(): " + valore2);
            //TryParse
            bool risp = false;
            risp = int.TryParse(valore1, out valore2);
            Console.WriteLine("TryParse restituisce: " + risp +
                              " e value 2 viene convertito in: " + valore2);

            //Concatenare con String builder
            StringBuilder address = new StringBuilder();
            address.Append("Prova");
            address.Append(" di concatenazione ");
            address.Append("con:");
            address.AppendLine("STRING BUILDER!");
            string concatenatedAddress = address.ToString();
            Console.WriteLine("StringBuilder: " + concatenatedAddress);

            //Fare dei template con string.Format
            string templateString = string.Format("Ciao, mi chiamo {0} ed ho {1} anni!", "Andrea", 35);
            Console.WriteLine(templateString);

            //Validare una string con una regulare expression
            var textToTest = "hell0 w0rld";
            var regularExpression = "\\d";

            var result = Regex.IsMatch(textToTest, regularExpression, RegexOptions.None);

            if (result)
            {
                Console.WriteLine("Regex.IsMatch: " + result);
            }

            textToTest = "hello world";

            result = Regex.IsMatch(textToTest, regularExpression, RegexOptions.None);

            if (!result)
            {
                Console.WriteLine("Regex.IsMatch: " + result);
            }

            //Carattere escape: o uso il doppio back slash o applico la @ davanti
            regularExpression = "\\d";
            Console.WriteLine(regularExpression);
            regularExpression = @"\d";
            Console.WriteLine(regularExpression);

            //Definizione di un array;
            int[] arrayName = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            StringBuilder arrayContent = new StringBuilder();
            for (int i = 0; i < arrayName.Length; i++)
            {
                arrayContent.Append(arrayName[i] + "-");
            }
            Console.WriteLine("ArrayContent: " + arrayContent.ToString().Substring(0, arrayContent.ToString().Length - 1));
            Console.WriteLine("arrayName[0]: " + arrayName[0]);
            arrayName[0] = 2;
            Console.WriteLine("arrayName[0]: " + arrayName[0]);
            string[] nomi = "Andrea,Leonardo,Sacha,Luca,Emanuel".Split(',');
            Console.Write("Lista nomi: |");
            foreach (string nom in nomi)
            {
                Console.Write(nom + "|");
            }
            Console.WriteLine();
            //Stampare a video i paramentri in ingresso
            foreach(string param in args)
            {
                Console.WriteLine(string.Format("Parametro {0}",param));
            }

            //Serve per non far uscire la console e visualizzare i WriteLine precedenti
            Console.ReadKey();
        }
    }
}
