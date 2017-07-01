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

            // Pig Latin Rules
            //Starts w/vowel + "way"
            // Starts w/consonant chop off first letter, add it to the end + "ay"

            char[] vowelArray = { 'a', 'e', 'i', 'o', 'u','A','E','I','O','U' };
            char[] specArray = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')' };
            string yesNo = "y";
            while (yesNo == "y")
            {

                string inputString = GetInputString("Enter the text to be translated: ");
//                inputString = inputString.TrimEnd('?', '.', ',');
                string[] words = inputString.Split(' ');
                PrintArray(words, vowelArray,specArray);
                yesNo = ynInput();
            }
        }
        public static void findVowel(string cword, char [] varray)
        {
            string firstChars = "";
            char[] lookIn = cword.ToArray();
            int wordLength = lookIn.Length;
            foreach (char i in cword)
            {
                foreach(char j in varray)
                {
                    if (i == j)
                    {
                        cword = cword + firstChars;
                        Console.Write(cword+"ay ");
                        break;
                    }
                }
                firstChars = firstChars + i;
                cword = cword.Substring(1);
            }

        }

        public static void PrintSpec(string specWord)
        {
            Console.Write(specWord + " ");
        }

        public static void PrintVowelFirst(string vowelWord)
        {
            Console.Write(vowelWord + "way ");
        }

        public static void PrintArray(string[] inputToPrint, char[] varray, char[] sarray)
        {
            foreach (string i in inputToPrint)
            {
                bool spec = false;
                bool vowel = false;

                char[] newWord = i.ToCharArray();
                for (int j = 0; j < sarray.Length; j++)
                {
                    if (i.IndexOf(sarray[j]) != -1)
                    {
                        PrintSpec(i);
                        spec = true;
                    }
                }
                if (!spec)
                    {
                        foreach (char k in varray)
                        {
                            if (newWord[0] == k)
                            {
                                PrintVowelFirst(i);
                                vowel = true;
                            }
                        }
                    }

                    if (!spec && !vowel)
                    {
                        findVowel(i, varray);
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
                input = input.ToLower();
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