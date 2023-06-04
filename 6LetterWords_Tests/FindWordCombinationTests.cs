using _6LetterWords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6LetterWords_Tests
{
    public class FindWordCombinationTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void FindWordCombinations_ReturnsCorrectCombinations()
        {
            // Arrange
            List<string> words = new List<string> { "cat", "dog", "hat", "ca", "tdog" };
            HashSet<string> fullWords = new HashSet<string> { "catdog", "doghat" };

            Helper _helper = new Helper();

            // Act
            List<string> combinations = _helper.FindWordCombinations(6, words, fullWords);
            int expectedCount = 3;


            // Assert
            Assert.That(combinations.Count, Is.EqualTo(expectedCount));
            Assert.Contains("cat + dog = catdog", combinations);
            Assert.Contains("dog + hat = doghat", combinations);
            Assert.Contains("ca + tdog = catdog", combinations);
        }

        [Test]
        public void FindWordCombinations_ReturnsNoCombinations()
        {
            // Arrange
            List<string> words = new List<string> { "ca", "do", "ht", "ca", "dog" };
            HashSet<string> fullWords = new HashSet<string> { "catdog", "doghat" };

            Helper _helper = new Helper();

            // Act
            List<string> combinations = _helper.FindWordCombinations(6, words, fullWords);
            int expectedCount = 0;

            // Assert
            Assert.That(combinations.Count, Is.EqualTo(expectedCount));
        }
    }
}
