using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6LetterWords
{
    public class Helper
    {

        private string path = "../../../Data/input.txt";
        public HashSet<string> combinations = new HashSet<string>();

        public List<string> FindWordCombinations(int targetLength, List<string> words, HashSet<string> fullWords)
        {
            combinations.Clear();

            //Iterate over each incomplete word and compare them with the other incomplete words in the list
            foreach (string word1 in words) 
            {
                foreach (string word2 in words)
                {
                    if (word1 != word2) // Make sure we don't compare the same incomplete words
                    {
                        string combinedWord = word1 + word2; // Combine the two incomplete words to make a complete word
                        if (combinedWord.Length == targetLength && fullWords.Contains(combinedWord)) // If the combined word is equal to six characters and the list of complete words contains it, then we know it's a possible combination
                        {
                            string combination = $"{word1} + {word2} = {combinedWord}";                     
                            combinations.Add(combination);                                                   
                        }
                    }
                }
            }

            return combinations.ToList<string>();
        }

        public List<string> FindWordCombinationsImproved(int targetLength, List<string> words, HashSet<string> fullWords)
        {          
            combinations.Clear();
       
            foreach(string word in words)
            {
                GenerateWordCombination(targetLength, words, fullWords, word);
            }        
            return combinations.ToList<string>();
        }

        private void GenerateWordCombination(int targetLength, List<string> words, HashSet<string> fullWords, string currentWord)
        {
          
            if (fullWords.Contains(currentWord))
            {
                combinations.Add(currentWord);
            }

            foreach(string word in words)
            {

                if((word + currentWord).Length > targetLength)
                {
                    return;
                }

                if(word != currentWord)
                {
                    string updatedCombination = currentWord + word;
                    GenerateWordCombination(targetLength, words, fullWords, updatedCombination);
                }
                
            }
            
        }
    }
}
