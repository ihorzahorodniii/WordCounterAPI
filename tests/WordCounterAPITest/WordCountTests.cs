using WordCounterAPI.Core.Interfaces;
using WordCounterAPI.Core.Services;
using Xunit;


namespace WordCounterAPITest
{
    public class WordCountTests
    {
        private readonly string wordCountTest = "This is the test, and it is only test. Test is good!";

        Dictionary<string, int> expectWordCount = new Dictionary<string, int>() {
            {"is",3},
            {"test",3}, 
            {"and",1 },
            {"good",1},
            {"it",1},
            {"only",1},
            {"the",1},
            {"this",1}
        };

        private readonly ITextProvider _textProvider;
        public WordCountTests()
        {
            var textMock = new Moq.Mock<ITextProvider>();
            textMock.Setup(_ => _.GetText()).Returns(new string[] { wordCountTest });
            _textProvider = textMock.Object;
        }

        [Fact]
        public void CountWordsNormal()
        {
            var solver = new WordCounterService(_textProvider);
            Assert.True(solver.GetWords().SequenceEqual(expectWordCount));
        }
    }
}
