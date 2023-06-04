using _6LetterWords;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Helper helper = new Helper();
        int targetLength = 6;
        string path = "../../../Data/input.txt";
        List<string> words = new List<string>();
        HashSet<string> fullWords = new HashSet<string>();


        //Read input
        try
        {
            //Iterate through all the lines in the .txt file
            foreach (string line in File.ReadAllLines(path))
            {
                string word = line.Trim(); // Remove white space characters from line

                if (word.Length == targetLength) // If the length of a word is equal to (in this case) 6 characters we know it's a complete word
                {
                    fullWords.Add(word);
                }
                else if (word.Length > 0 && word.Length < targetLength) // If it's not equal to 6 then we know its an incomplete word
                {
                    words.Add(word);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }



        //Find word combinations 
        List<string> combinations = helper.FindWordCombinations(targetLength, words, fullWords);


        //Sort the list of combinations alphabetically
        combinations.Sort();

        //Write the combinations to the console
        foreach (string combination in combinations)
        {
            Console.WriteLine(combination);
        }

        Console.WriteLine(combinations.Count());


        //Find word combinations (improved)
        List<string> combinations2 = helper.FindWordCombinationsImproved(targetLength, words, fullWords);

        foreach (string combination in combinations2)
        {
            Console.WriteLine(combination);
        }

        Console.WriteLine(combinations2.Count());


    }
}