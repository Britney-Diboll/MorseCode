using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 -Prompt to type anything to translate to morse code...
 -Uppercase letters
 */

namespace MorseCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var morseCode = new Dictionary<char, string>();
            const string FILE_PATH = "../../morse.csv";
            using (var reader = new StreamReader(FILE_PATH))
            {
                while (reader.Peek() > -1)
                {
                    var line = reader.ReadLine().Split(',');
                    morseCode.Add(Convert.ToChar(line[0]), (line[1]));
                }
            }
            Console.WriteLine("Type anything to translate to Morse Code!");
            string input;
            input = Console.ReadLine();
            input = input.ToUpper();
            Console.ReadLine();

            string result = translate(input, morseCode);
            GetReturn(result);
            Console.ReadLine();

            var stillGoing = true;
            while (stillGoing)
            {
                Console.WriteLine("Would you like to convert another word? (yes) or (no)");
                var read = Console.ReadLine();
                if (read == "yes")
                {
                    Console.WriteLine("Type anything to translate to Morse Code!");
                    input = Console.ReadLine();
                    input = input.ToUpper();
                    Console.ReadLine();
                    result = translate(input, morseCode);
                    GetReturn(result);
                    Console.ReadLine();
                }
                else stillGoing = false;

            }
        }

   

        static void GetReturn(string input)
        {
            Console.WriteLine("Your output in morse code is: " + input);

        }

        static string translate(string input, Dictionary<char, string> morseCode)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char character in input)
            {
                if (morseCode.ContainsKey(character))
                {
                    sb.Append(morseCode[character] + " ");
                } else if (character == ' ')
                {
                    sb.Append("/ ");
                } else
                {
                    sb.Append(character + " ");
                }
            }
            return sb.ToString();
        } 
    }
}
