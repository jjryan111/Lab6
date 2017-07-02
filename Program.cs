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
            char[] punctArray = { ',', '.', '/', '?', '<', '>', '-', '_', '+', '=', ':', ';' };
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
        public static char FindPunct(string word, char[] parray)
        {
            char [] pword = word.ToArray();
            int len = pword.Length -1;
            char punct="";
            bool done = false;
            
            foreach (char a in parray)
            {
                 if (pword[len] == a && !done)
                 {
                      punct =a;
                      word = word.Trim(a);
                      done = true;
                 }
                 else if (pword[len] == a)
                 {
                      Console.WriteLine("\n Throw me a bone here. you can't have two punctuation marks in a row!");
                 }
            }
            return punct;
        }
        
        public static void findVowel(string cword, char [] varray)
        {
            string firstChars = "";
            char[] lookIn = cword.ToArray();
            int wordLength = lookIn.Length;
            bool firstVow = false;
            foreach (char i in cword)
            {
                if (firstVow)
                {
                    break;
                }
                foreach(char j in varray)
                {
                    if (i == j)
                    {
                        cword = cword + firstChars;
                        Console.Write(cword+"ay ");
                        firstVow = true;
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
                    bool punct, vowel = false;
                    char pun = FindPunct(i);
                float thing = 0;
                char[] newWord = i.ToCharArray();
                bool num = float.TryParse(i, out thing);
                if (num)
                {
                    PrintSpec(i);
                }
                else if (!num)
                {

                    foreach (char j in sarray)
                    {
                        if (i.IndexOf(j) != -1)
                        {
                            PrintSpec(i);
                            spec = true;
                        }
                    }
                }

                else if (!spec && !num)
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

                if (!num && !spec && !vowel)
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