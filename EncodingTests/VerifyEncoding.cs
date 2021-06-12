using System.Text;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace EncodingTests
{
    public class VerifyEncoding
    {
        private const string RightSingleQuoteAkaApostrophe = "�";

        [Fact]
        public void RightSingleQuoteAkaApostropheTest()
        {
            using (new AssertionScope())
            {
                Encoding.Default.GetBytes(RightSingleQuoteAkaApostrophe).Should().Equal(0xE2, 0x80, 0x99);
                Encoding.UTF8.GetBytes(RightSingleQuoteAkaApostrophe).Should().Equal(0xE2, 0x80, 0x99);
                Encoding.ASCII.GetBytes(RightSingleQuoteAkaApostrophe).Should().Equal(0x3F);
            }
        }
    }
}
