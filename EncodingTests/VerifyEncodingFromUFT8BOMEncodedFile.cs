using System.Text;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace EncodingTests
{
    public class VerifyEncodingFromUFT8BOMEncodedFile
    {
        private const string RightSingleQuoteAkaApostrophe = "’";

        [Fact]
        public void RightSingleQuoteAkaApostropheTest()
        {
            using (new AssertionScope())
            {
                Encoding.UTF8.GetBytes(RightSingleQuoteAkaApostrophe).Should().Equal(new[] { 0xE2, 0x80, 0x99 }, "because UTF8 supports unicode so it encodes U+2019 ’ RIGHT SINGLE QUOTATION MARK correctly");
                Encoding.ASCII.GetBytes(RightSingleQuoteAkaApostrophe).Should().Equal(new[] { 0x3F }, "because it is outside of ASCII range the result is a question mark");
            }
        }
    }
}
