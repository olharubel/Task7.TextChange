using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7.TextChange
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string text = "I go,to school!     *      Girl runs to school?";
                Console.WriteLine("Text before translating:");
                Console.WriteLine(text);
                Translator translator = new Translator();
                translator.InitializeDictionary("I", "boy");
                translator.InitializeDictionary("go", "run");
                translator.InitializeDictionary("to", "to");
                translator.InitializeDictionary("school", "cinema");
                Console.WriteLine("\nText after translating:\n");
                string translatedText = translator.TranslateText(text);
                Console.WriteLine(translatedText);
                
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
