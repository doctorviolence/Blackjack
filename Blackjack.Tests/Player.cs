using Xunit;

namespace Blackjack.Tests
{
    public class PlayerTest
    {
        [Fact]
        public void WhenUserIsInitialized_ReturnCorrectType()
        {
            var user = new User();

            bool isUser = user.IsUser();
            bool isDealer = user.IsDealer();

            Assert.True(isUser);
            Assert.False(isDealer);
        }

        [Fact]
        public void WhenDealerIsInitialized_ReturnCorrectType()
        {
            var dealer = new Dealer();

            bool isUser = dealer.IsUser();
            bool isDealer = dealer.IsDealer();

            Assert.False(isUser);
            Assert.True(isDealer);
        }
    }
}