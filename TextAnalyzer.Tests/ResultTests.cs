using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TextAnalyzer.Results;
using TextAnalyzer.Filters;

namespace TextAnalyzer.Tests
{
    public class ResultTests
    {
        FilterList filterList = new FilterList(new char[] { '\n', ' ', '.', ',', '[', ']' });
        [Fact]
        public void AddWord_ShouldAddWord_WhenWordIsNotAlreadyThere ()
        {
            // Arrange 
            IResult result = new Result(filterList);
            char [] wordArray = new char[] { 'a', 'b', 'c' };

            string word = new string(wordArray);
            // Act
            result.AddWord(word);
            // Assert
            Assert.Contains(word, result.Select(pair => pair.Key));
        }
        [Fact]
        public void AddWord_ShouldAddWordAndSumValue_WhenWordIsAlreadyThere()
        {
            // Arrange 
            IResult result = new Result(filterList);
            char[] wordArray = new char[] { 'a', 'b', 'c' };

            string word = new string(wordArray);
            // Act
            result.AddWord(word);
            result.AddWord(word);
            // Assert
            Assert.Contains(word, result.Select(pair => pair.Key));
            Assert.Equal(2, result.Where(pair => pair.Key == word).Select(pair => pair.Value).Single());
        }
        [Fact]
        public void Merge_ShouldMerge_WhenResultsIntersect()
        {
            // Arrange 
            IResult result1 = new Result(filterList);
            IResult result2 = new Result(filterList);
            char[] wordArray = new char[] { 'a', 'b', 'c' };

            string word = new string(wordArray);
            // Act
            result1.AddWord(word);
            result2.AddWord(word);
            result1.Merge(result2);
            // Assert
            Assert.Contains(word, result1.Select(pair => pair.Key));
            Assert.Equal(2, result1.Where(pair => pair.Key == word).Select(pair => pair.Value).Single());
        }
        [Fact]
        public void Merge_ShouldMerge_WhenResultsDoNotIntersect()
        {
            // Arrange 
            IResult result1 = new Result(filterList);
            IResult result2 = new Result(filterList);
            char[] wordArray1 = new char[] { 'a', 'b', 'c' };
            char[] wordArray2 = new char[] { 'c', 'd', 'e' };

            string word1 = new string(wordArray1);
            string word2 = new string(wordArray2);
            // Act
            result1.AddWord(word1);
            result2.AddWord(word2);
            result1.Merge(result2);
            // Assert
            Assert.Contains(word1, result1.Select(pair => pair.Key));
            Assert.Contains(word2, result1.Select(pair => pair.Key));
            Assert.Equal(1, result1.Where(pair => pair.Key == word1).Select(pair => pair.Value).Single());
            Assert.Equal(1, result1.Where(pair => pair.Key == word2).Select(pair => pair.Value).Single());
        }
        [Fact]
        public void RunFilter_ShouldFilter_WhenWordHaveBannedSymbols()
        {
            // Arrange 
            IResult result = new Result(filterList);

            char[] wordArray1 = new char[] { 'a', 'b', 'c' };
            char[] wordArray2 = new char[] { ',', 'd', 'e' };

            string word1 = new string(wordArray1);
            string word2 = new string(wordArray2);
            // Act
            result.AddWord(word1);
            result.AddWord(word2);
            result.RunFilter();
            // Assert
            Assert.Contains(word1, result.Select(pair => pair.Key));
            Assert.DoesNotContain(word2, result.Select(pair => pair.Key));
        }
        [Fact]
        public void OrderAndCut_ShouldOrderDescending()
        {
            // Arrange 
            IResult result = new Result(filterList);

            char[] wordArray1 = new char[] { 'a', 'b', 'c' };
            char[] wordArray2 = new char[] { 'a', 'd', 'e' };
            char[] wordArray3 = new char[] { 'g', 'd', 'e' };

            string word1 = new string(wordArray1);
            string word2 = new string(wordArray2);
            string word3 = new string(wordArray2);
            // Act
            result.AddWord(word1);
            result.AddWord(word1);
            result.AddWord(word1);
            result.AddWord(word1);
            result.AddWord(word2);
            result.AddWord(word2);
            result.AddWord(word3);
            result.AddWord(word3);
            result.AddWord(word3);
            result.AddWord(word3);
            result.AddWord(word3);
            result.AddWord(word3);
            result.AddWord(word3);

            result.OrderAndCut(2);
            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal(word3, result.Select(pair => pair.Key).First());
        }
    }
}
