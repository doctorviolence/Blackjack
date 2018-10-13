using System.Collections.Generic;
using Xunit;

namespace Blackjack.Tests
{
    public class Game
    {
        [Fact]
        public void WhenInitialized_GameContainsCardDeck()
        {
            Blackjack.CardDeck deck = new Blackjack.CardDeck();
            Blackjack.Game game = new Blackjack.Game(deck);

            Assert.NotNull(game.CardDeck);
        }

        [Fact]
        public void WhenInitialized_GameContains1Dealer()
        {
            Blackjack.CardDeck deck = new Blackjack.CardDeck();
            Blackjack.Game game = new Blackjack.Game(deck);

            IList<Blackjack.Player> players = game.Players;

            Assert.Equal(players.Count, 1);
        }

        [Fact]
        public void When1PlayerAdded_ThenReturn2TotalPlayers()
        {
            Blackjack.CardDeck deck = new Blackjack.CardDeck();
            Blackjack.Game game = new Blackjack.Game(deck);

            User user = new User();

            game.AddPlayer(user);

            IList<Blackjack.Player> players = game.Players;

            // Note that a dealer is always initialized in the game
            Assert.Equal(players.Count, 2);
        }

        [Fact]
        public void WhenGameStartsWith2Players_ThenThereAre48CardsLeft()
        {
            Blackjack.CardDeck deck = new Blackjack.CardDeck();
            Blackjack.Game game = new Blackjack.Game(deck);
            User user = new User();
            game.AddPlayer(user);

            game.StartGame();

            int cards = game.Cards.Count;

            Assert.Equal(cards, 48);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void WhenPlayerRequests2Cards_ThenReturnExpectedTotalNumberOfCards(int value)
        {
            Blackjack.CardDeck deck = new Blackjack.CardDeck();
            Blackjack.Game game = new Blackjack.Game(deck);

            game.StartGame();
            Blackjack.Player p = game.Players[0];

            int total = 2;

            for (int i = 0; i < value; i++)
            {
                game.DealCard(p);
                total++;
            }

            int cards = p.Hand.Cards.Count;

            Assert.Equal(cards, total);
        }

        [Fact]
        public void WhenAnotherDealerAdded_ThenThrowAddPlayerException()
        {
            Blackjack.CardDeck deck = new Blackjack.CardDeck();
            Blackjack.Game game = new Blackjack.Game(deck);

            Dealer dealer = new Dealer();

            try
            {
                game.AddPlayer(dealer);
            }
            catch (AddPlayerException e)
            {
                Assert.Equal(e.Message, "Dealer already exists");
                Assert.True(e.GetType() == typeof(AddPlayerException));
            }
        }
    }
}