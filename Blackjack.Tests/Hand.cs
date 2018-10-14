using Xunit;

namespace Blackjack.Tests
{
    public class HandTest
    {
        [Theory]
        [InlineData(5, 9)]
        [InlineData(2, 4)]
        [InlineData(6, 8)]
        [InlineData(9, 9)]
        public void WhenHandHas2GivenValues_ReturnExpectedScore(int value, int value2)
        {
            CardDeck deck = new CardDeck();
            Card card = new Card();
            Card card2 = new Card();

            card.Value = value;
            card2.Value = value2;

            deck.Cards[0] = card;
            deck.Cards[1] = card2;

            Game game = new Game(deck);
            game.StartGame();

            Player player = game.Players[0];
            Hand hand = player.Hand;

            int score = hand.CalculateScore();
            int expected = value + value2;

            Assert.Equal(expected, score);
        }

        [Fact]
        public void WhenAceAndWhenNotBust_Return11()
        {
            CardDeck deck = new CardDeck();
            Card card = new Card();
            Card card2 = new Card();

            card.Value = 2;
            card2.Value = 11;

            deck.Cards[0] = card;
            deck.Cards[1] = card2;

            Game game = new Game(deck);
            game.StartGame();

            Player player = game.Players[0];
            Hand hand = player.Hand;

            Assert.Equal(13, hand.Score);
        }

        [Fact]
        public void WhenAceAndWhenBust_Return1()
        {
            CardDeck deck = new CardDeck();
            Card card = new Card();
            Card card2 = new Card();

            card.Value = 11;
            card2.Value = 11;

            deck.Cards[0] = card;
            deck.Cards[1] = card2;

            Game game = new Game(deck);
            game.StartGame();

            Player player = game.Players[0];
            Hand hand = player.Hand;

            Assert.Equal(2, hand.Score);
        }

        [Fact]
        public void WhenHandHasOver21_ReturnIsBustTrue()
        {
            CardDeck deck = new CardDeck();
            Card card = new Card();
            card.Value = 10;
            Card card2 = new Card();
            card2.Value = 10;
            Card card3 = new Card();
            card2.Value = 10;

            deck.Cards[0] = card;
            deck.Cards[1] = card2;
            deck.Cards[2] = card3;

            Game game = new Game(deck);
            game.StartGame();

            Player player = game.Players[0];
            Hand hand = player.Hand;
            game.DealCard(player);

            bool isBust = hand.IsBust();

            Assert.True(isBust);
        }

        [Fact]
        public void WhenHandHasBelow21_ReturnIsBustFalse()
        {
            CardDeck deck = new CardDeck();
            Card card = new Card();
            card.Value = 10;
            Card card2 = new Card();
            card2.Value = 10;

            deck.Cards[0] = card;
            deck.Cards[1] = card2;

            Game game = new Game(deck);
            game.StartGame();

            Player player = game.Players[0];
            Hand hand = player.Hand;

            bool isBust = hand.IsBust();

            Assert.False(isBust);
        }

        //[Fact]
        //public void WhenFirstDealt_ThenStartWith2Cards()
        //{
        //    Blackjack.Game game = new Blackjack.Game(new Blackjack.CardDeck());
        //
        //    game.StartGame();
        //
        //    Blackjack.Player p = game.Players[0];
        //    List<Blackjack.Card> cards = p.Hand.Cards;
        //
        //   Assert.Equal(cards.Count, 2);
        //}
    }
}