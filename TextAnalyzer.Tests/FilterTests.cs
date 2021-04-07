using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAnalyzer.Filters;
using Xunit;

namespace TextAnalyzer.Tests
{
    public class FilterTests
    {
        [Fact]
        public void Filter_ShoudFilterWord_WhenRulesMet()
        {
            // Arrange
            IFilter filter = new Filter('a');
            char[] wordArray = new char[] { 'a', 'b', 'c' };
            string word = new string(wordArray);
            //Assert
            Assert.False(filter.CheckWordValid(word));
        }
        [Fact]
        public void Filter_ShoudLetWordPass_WhenRulesNotMet()
        {
            // Arrange
            IFilter filter = new Filter('x');
            char[] wordArray = new char[] { 'a', 'b', 'c' };
            string word = new string(wordArray);
            //Assert
            Assert.True(filter.CheckWordValid(word));
        }
    }
}
