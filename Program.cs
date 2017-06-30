using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6a
{
    class Program
    {

        static void Main(string[] args)
        {
            char[] vowelArray = {'a','e','i','o','u' };
            int strLength = 0;
            string yesNo = "y";
            while (yesNo == "y")
            {

                string inputString = GetInputString("Enter the text to be translated: ");
                inputString = inputString.TrimEnd('?', '.', ',');
                string[] words = inputString.Split(' ');
                PrintArray(words,vowelArray);
                yesNo = ynInput();
            }
        }

    public static void PrintArray(string [] inputToPrint, char[]varray)
    {
       // foreach (string i in inputToPrint)
       for (int i=0;i<inputToPrint.Length;i++)
        {
                bool vowel = false;
                char [] newWord = inputToPrint[i].ToCharArray();
                //               Console.WriteLine(newWord[0]);

                for (int l=0; l< varray.Length;l++)
                {
                    if (newWord[0].Equals(varray[l]))
                    {
                        vowel = true;
                    }
                }
                if (vowel)
                {
                    Console.Write(inputToPrint[i]+"ay ");
                }
                else
                {
                    char[] nvArray = inputToPrint[i].ToArray();
                    for (int m = 1; m < nvArray.Length; m++)
                    {
                        Console.Write(nvArray[m]);
                    }
                    Console.Write(nvArray[0]+"ay ");
                }
        }
    }
    public static string ynInput()
    {
        string input = "";
        bool invalid = true;
        while (invalid)
        {
            Console.WriteLine("");
            Console.WriteLine("Continue? (y/n): ");
            input = Console.ReadLine();
//            input = input.ToLower;
            if (input == "y" || input == "n")
            {
                invalid = false;
            }
            else
            {
                Console.WriteLine("Please enter y or n.");
            }
        }

        return input;
    }
        public static string GetInputString(string question)
        {
            bool input = false;
            string exitString = "";
            while (!input)
            {
                Console.Write(question);
                exitString = Console.ReadLine();
                if (exitString == "")
                {
                    Console.WriteLine("That's not valid input!");
                }
                else
                {
                    input = true;
                }
            }
            return exitString;
        }
    }
}
