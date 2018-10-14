using Xunit;

namespace Blackjack.Tests
{
    public class HandTest
    {
        [Fact]
        public void WhenHandHas2GivenValues_ReturnExpectedScore()
        {
            CardDeck deck = new CardDeck();
            Card card = new Card();
            Card card2 = new Card();

            card.Value = 5;
            card2.Value = 9;

            deck.Cards[0] = card;
            deck.Cards[1] = card2;

            Game game = new Game(deck);
            game.StartGame();

            Player player = game.Players[0];
            Hand hand = player.Hand;

            int score = hand.CalculateScore();

            Assert.Equal(score, 14);
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

            Assert.Equal(hand.Score, 13);
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

            Assert.Equal(hand.Score, 2);
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