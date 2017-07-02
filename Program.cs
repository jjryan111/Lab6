using System;
using System.Linq;

namespace Lab6a
{
    class Program
    {

        static void Main()
        {
            // Pig Latin Rules
            // Starts w/vowel = word+ "way"
            // Starts w/consonant chop off letters until vowel, add chopped off letters to the end + "ay"
            // Keep punctuation
            // Allow for contractions, numbers & special characters
            // Keep word case
            char[] vowelArray = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            char[] specArray = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')' };
            char[] punctArray = { ',', '.', '/', '?', '<', '>', '-', '_', '+', '=', ':', ';' };
            string yesNo = "y";
            while (yesNo == "y")
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Pig Latin translator!\n");
                string inputString = GetInputString("Enter the text to be translated: ");
                inputString = inputString.Trim(); // Trailing spaces cause weird things to happen.
                string[] words = inputString.Split(' ');
                Console.WriteLine();
                ClassifyWord(words, vowelArray, specArray, punctArray);
                yesNo = ynInput();
            }
        }

        public static string ynInput()
        // Gets a y or n.
        {
            string input = "";
            bool invalid = true;
            while (invalid)
            {
                Console.Write("\n\nTranslate another line? (y/n): ");
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "y" || input == "n")
                {
                    invalid = false;
                }
                else
                {
                    Console.WriteLine("\nPlease enter y or n.");
                }
            }
            return input;
        }

        public static char FindPunct(string word, char[] parray)
        // Finds the last puctuation mark after any word. 
        {
            char[] pword = word.ToArray();
            char punct = 'a';

            foreach (char a in parray)
            {
                if (pword[(pword.Length - 1)] == a)
                {
                    punct = a;
                }
            }
            return punct;
        }

        public static void Translate(string cword, char[] varray, char p)
        // Translates the word into Pig Latin
        {
            string firstChars = "";
            string initWord = cword;
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
                                    if (initWord == cword) //The word started with a vowel and there was punctuation.
                                    {
                                        cword = cword + "way" + p;
                                        PrintIt(cword);
                                    }
                                    else //The word started with one or more consonants and there was punctuation.
                                    {
                                        cword = cword + "ay" + p;
                                        PrintIt(cword);
                                    }
                                }
                                else
                                {
                                    if (initWord == cword) //The word started with a vowel.
                                    {
                                        cword = cword + "way";
                                        PrintIt(cword);
                                    }
                                    else  //The word started with one or more consonants.
                                    {
                                        cword = cword + "ay";
                                        PrintIt(cword);
                                    }

                                }
                                firstVow = true;
                            }
                        }
                    }
                }
                firstChars = firstChars + i; // Add the indexed letter to the string of characters to save.
                cword = cword.Substring(1); // Chop that letter off the word.
            }
            if (firstVow == false) // Otherwise the word doesnt have a vowel in it.
            {
                if (p != 'a')
                {
                    PrintIt(firstChars + "ay" + p);
                }
                else
                {
                    PrintIt(firstChars + "ay");
                }
            }
        }
        public static bool FindSpec(string sword, char[] sarray)
        {
            bool spec = false;
            foreach (char j in sarray)
            {
                if (sword.IndexOf(j) != -1)
                {
                    PrintIt(sword); //The word had special characters in it. Ignore it.
                    spec = true;
                }
            }
            return spec;
        }
        public static void PrintIt(string word)
        {
            Console.Write(word + " ");
        }

        public static void ClassifyWord(string[] inputToPrint, char[] varray, char[] sarray, char[] parray)
        // Determines whether a word needs to be translated or not.
        {
            foreach (string i in inputToPrint)
            {
                bool spec = false;
                char pun = 'a';
                string m = "";
                float thing = 0;
                char[] newWord = i.ToCharArray();
                bool num = float.TryParse(i, out thing);
                if (num)
                {
                    PrintIt(i); //The word was a number. Ignore it.
                }
                else
                {
                    spec = FindSpec(i, sarray); // Does the word have special characters?
                }
                if (!num && !spec)
                {
                    pun = FindPunct(i, parray); //Is there punctuation?
                    if (pun != 'a')
                    {
                        m = i.TrimEnd(pun);
                    }
                    else
                    {
                        m = i;
                    }
                    Translate(m, varray, pun); //The word needs translation!
                }
            }
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
                    Console.WriteLine("\nPlease enter some text.\n");
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
