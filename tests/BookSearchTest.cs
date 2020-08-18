using BookSearch;
using Xunit;

namespace tests
{
    public class BookSearchTest
    {
        [Fact]
        public async void BookSearch_ShouldReturnBookTitle()
        {
            var searchParameter = "isbn:9780748120154";
            var fieldRestriction = "&fields=items(volumeInfo/title)";
            var expectedResult = "{\n  \"items\": [\n    {\n      \"volumeInfo\": {\n        \"title\": \"The Thousandfold Thought\"\n      }\n    }\n  ]\n}\n";
            
            var result = await BookSearch.BookSearch.Search(searchParameter, fieldRestriction);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async void InvalidBookSearch_ShouldReturnEmptyBraces()
        {
            var searchParameter = "isbn:978074812015";
            var fieldRestriction = "&fields=items(volumeInfo/title)"; 
            var expectedResult = "{}\n";

            var result = await BookSearch.BookSearch.Search(searchParameter, fieldRestriction);
            Assert.Equal(expectedResult, result);           
                   
        }
    }
}
