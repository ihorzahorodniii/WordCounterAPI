using WordCounterAPI.Core.Interfaces;
using WordCounterAPI.Core.Services;

using Xunit;


namespace WordCounterAPITest
{
    public class WordCountNumTests
    {
        private readonly string wordCountNumTest = "2023 is good ,, year. Also 2023 <! is going well. 2023 now in the middle.";

        Dictionary<string, int> expectWordCountNum = new Dictionary<string, int>() {
            {"2023",3},
            {"is",2},
            {"also",1 },
            {"going",1},
            {"good",1},
            {"in",1},
            {"middle",1},
            {"now",1},
            {"the",1},
            {"well",1},
            {"year",1}
        };

        private readonly ITextProvider _textProvider;
        public WordCountNumTests()
        {
            var textMock = new Moq.Mock<ITextProvider>();
            textMock.Setup(_ => _.GetText()).Returns(new string[] { wordCountNumTest });
            _textProvider = textMock.Object;
        }

        [Fact]
        public void CountWordsWithNumbers()
        {
            var solver = new WordCounterService(_textProvider);
            Assert.True(solver.GetWords().SequenceEqual(expectWordCountNum));
        }
    }
}
