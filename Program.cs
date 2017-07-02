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
            // Starts w/vowel = word+ "way"
            // Starts w/consonant chop off letters until vowel, add chopped off letters to the end + "ay"
            // Keep punctuation
            // Allow for numbers & special characters

            char[] vowelArray = { 'a', 'e', 'i', 'o', 'u','A','E','I','O','U' };
            char[] specArray = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')' };
            char[] punctArray = { ',', '.', '/', '?', '<', '>', '-', '_', '+', '=', ':', ';' };
            string yesNo = "y";
            while (yesNo == "y")
            {
                string inputString = GetInputString("Enter the text to be translated: ");
                string[] words = inputString.Split(' ');
                PrintPig(words, vowelArray,specArray, punctArray);
                yesNo = ynInput();
            }
        }
        public static char FindPunct(string word, char[] parray)
        {
            char [] pword = word.ToArray();
            int len = pword.Length -1;
            char punct='a';
            bool done = false;
            
            foreach (char a in parray)
            {
                 if (pword[len] == a && !done)
                 {
                      punct = a;
                      word = word.Trim(a);
                      done = true;
                 }
            }
            return punct;
        }
        
        public static void FindVowel(string cword, char [] varray, char p)
        {
            string firstChars = "";
            bool firstVow = false;
            foreach (char i in cword)
            {
                if (!firstVow)
                {

                    foreach (char j in varray)
                    {
                        if (!firstVow)
                        {
                            if (i == j)
                            {
                                cword = cword + firstChars;
                                if (p != 'a')
                                {
                                    Console.Write(cword + "ay" + p + " ");
                                }
                                else
                                {
                                    Console.Write(cword + "ay ");
                                }
                                firstVow = true;
                            }
                        }
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

        public static void PrintVowelFirst(string vowelWord, char p)
        {
            if (p != 'a')
            {
                Console.Write(vowelWord+"way"+p+" ");
            }
            else
            {
                Console.Write(vowelWord + "way ");
            }
        }

        public static void PrintPig(string[] inputToPrint, char[] varray, char[] sarray, char [] parray)
        {
            foreach (string i in inputToPrint)
            {
                bool spec = false;
                bool vowel = false;
                bool punct = false;
                char pun = 'a';
                string m = "";    
                float thing = 0;
                char[] newWord = i.ToCharArray();
                bool num = float.TryParse(i, out thing);
                if (num)
                {
                    PrintSpec(i);
                }
                else if (!num)
                {
                    pun = FindPunct(i, parray);
                    if (pun != 'a')
                    {
                        m = i.TrimEnd(pun);
                        punct = true;
                    }
                    else
                    {
                        m = i;
                    }
                    foreach (char j in sarray)
                    {
                        if (m.IndexOf(j) != -1)
                        {
                            PrintSpec(m);
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
                            PrintVowelFirst(m, pun);
                            vowel = true;
                        }
                    }
                    
                }

                if (!num && !spec && !vowel)
                {
                    FindVowel(m, varray, pun);
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