using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Task4
{
    /*
    Створіть текстовий файл-чек на кшталт «Найменування товару – 0.00(ціна)грн.» 
    з певною кількістю найменувань товарів та датою здійснення покупки. 
    Виведіть на екран інформацію з чека у форматі поточної локалі користувача та у форматі локалі en-US.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            var my = CultureInfo.CurrentCulture;
            var ua = new CultureInfo("uk-UA");

            string sentence = File.ReadAllText("product.txt", Encoding.Default);

            Console.WriteLine(sentence);

            Console.WriteLine(new string('-', 25));

            string pattern = @"[0-9]+[\.\,][0-9]+";

            string sentenceMy = Regex.Replace(sentence, pattern, (m) => double.Parse(m.Value).ToString("C", my));
            string sentenceUa = Regex.Replace(sentence, pattern, (m) => double.Parse(m.Value).ToString("C", ua));

            Console.WriteLine(sentenceMy);

            Console.WriteLine(new string('-', 25));

            Console.WriteLine(sentenceUa);

            Console.ReadKey();
        }
    }
}
