using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAnalyzer.Readers;
using Xunit;

namespace TextAnalyzer.Tests
{
    public class ReaderTests
    {
        MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes("abcdefgh"));
        [Fact]
        public void Skip_ShouldSkipCharsFromStream_WhenCalled()
        {
            // Arrange

            string testWord = new string(new char[] { 'f', 'g', 'h' });
            IReader reader = new Reader(new StreamReader(ms), 3);
            // Act
            reader.Skip(5);
            reader.TryRead(out string result);

            // Assert
            Assert.Equal(testWord, result);
           
        }
        [Fact]
        public void TryRead_ShouldReturnFalse_WhenLessWhenRequiredCharsdRed()
        {
            // Arrange
            IReader reader = new Reader(new StreamReader(ms), 3);

            // Act
            reader.Skip(7);

            // Assert
            Assert.False(reader.TryRead(out string result));

            
        }
        [Fact]
        public void CanRead_ShouldReturnFalse_WhenStreamAtEnd()
        {
            // Arrange
            Reader reader = new Reader(new StreamReader(ms), 3);

            // Act
            reader.Skip(8);

            // Assert
            Assert.False(reader.CanRead);
        }

    }
}
