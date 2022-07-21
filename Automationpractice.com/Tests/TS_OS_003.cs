using Automationpractice.com.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automationpractice.com.Tests
{
    public class TS_OS_003 : Base_Test
    {
        [TestCase("dress")]
        [TestCase("summer")]
        public void Test_SearchBox_ValidKeywords(string keyword)
        {

            // Arrange
            var search = new SearchBox(driver);
            // Act
            search.Search_Keyword(keyword);
            var result = search.checkResult.Text;
            // Assert
            Assert.That(result, Is.GreaterThan("0"));
        }
        [TestCase("!@#$%^&*()_+{}")]
        [TestCase("1234asdASD")]
        public void Test_SearchBox_InvalidKeywords(string keyword)
        {
            // Arrange
            var search = new SearchBox(driver);
            // Act
            search.Search_Keyword(keyword);
            var result = search.checkResult.Text;
            // Assert
            Assert.That(result, Is.EqualTo("0 results have been found."));
        }
    }
}
