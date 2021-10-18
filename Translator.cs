using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7.TextChange
{
    class Translator
    {
        private Dictionary<string, string> dictionary;

        public Translator()
        {
            dictionary = new Dictionary<string, string>();
        }

        public Translator(Dictionary<string, string> dictionary)
        {
            this.dictionary = dictionary;
        }

        public void InitializeDictionary(string initWord, string replaceWord)
        {
            if (!dictionary.ContainsKey(initWord))
            {
                dictionary.Add(initWord, replaceWord);
            }
        }

        private StringBuilder ToStringBuilder(string text)
        {
            return new StringBuilder(text);
        }

        private string StringBuilderToString(StringBuilder text)
        {
            return text.ToString();
        }

        private char[] GetSeparators(string str)
        {
            List<char> separators = new List<char>();

            for (int i = 0; i < str.Length; ++i)
            {
                if (!char.IsLetterOrDigit(str[i]))
                {
                    separators.Add(str[i]);
                }
            }

            char[] uniqueSeparators = separators.Distinct().ToArray<char>();
            return uniqueSeparators;
        }

        private string UserRequest(string initWord)
        {
            Console.WriteLine($"Enter word to replace \"{initWord}\"");
            string replaceWord = Console.ReadLine();
            return replaceWord;
        }

        public string TranslateText(string text)
        {
            if(text.Length == 0)
            {
                throw new FormatException("Text is empty. Impossible to translate!");
            }
            StringBuilder sb = new StringBuilder();
            sb = ToStringBuilder(text);
            string result = "";

            char[] separators = GetSeparators(text);

            string[] allWords = text.Split(separators);
            string[] uniqueWords = allWords.Where(word => !string.IsNullOrEmpty(word)).ToArray<string>();

            for (int j = 0; j < uniqueWords.Length; ++j)
            {
                if (dictionary.ContainsKey(uniqueWords[j]))
                {
                    sb.Replace(uniqueWords[j], dictionary[uniqueWords[j]]);
                }
                else
                {
                    string replaceWord = UserRequest(uniqueWords[j]);
                    sb.Replace(uniqueWords[j], replaceWord);
                }

            }
            result = StringBuilderToString(sb);

            return result;
        }
    }
}
