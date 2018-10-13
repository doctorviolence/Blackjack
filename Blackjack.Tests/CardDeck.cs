using Xunit;

namespace Blackjack.Tests
{
    public class CardDeck
    {
        [Fact]
        public void WhenInitialized_CardDeckContains52Cards()
        {
            Blackjack.CardDeck deck = new Blackjack.CardDeck();

            Blackjack.Card[] cards = deck.Cards;

            Assert.NotEmpty(cards);
            Assert.Equal(cards.Length, 52);
        }

        [Fact]
        public void WhenInitialized_SingleCardContainsValidNumber()
        {
            Blackjack.CardDeck deck = new Blackjack.CardDeck();

            Blackjack.Card[] cards = deck.Cards;

            foreach (Blackjack.Card c in cards)
            {
                var valid = c.IsCardValid();
                Assert.True(valid);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        public void WhenInitialized_CardDeckContains4CardsOfEachValue(int value)
        {
            Blackjack.CardDeck deck = new Blackjack.CardDeck();

            Blackjack.Card[] cards = deck.Cards;

            int i = 0;

            foreach (Blackjack.Card c in cards)
            {
                if (value == c.Value)
                    i++;
            }

            Assert.Equal(i, 4);
        }
    }
}