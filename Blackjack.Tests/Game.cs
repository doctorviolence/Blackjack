using System.Collections.Generic;
using Xunit;

namespace Blackjack.Tests
{
    public class GameTest
    {
        [Fact]
        public void WhenInitialized_GameContainsCardDeck()
        {
            CardDeck deck = new CardDeck();
            Game game = new Game(deck);

            Assert.NotNull(game.CardDeck);
        }

        [Fact]
        public void WhenInitialized_GameContains1Dealer()
        {
            CardDeck deck = new CardDeck();
            Game game = new Game(deck);

            List<Player> players = game.Players;

            Assert.Equal(players.Count, 1);
        }

        [Fact]
        public void When1PlayerAdded_ThenReturn2TotalPlayers()
        {
            CardDeck deck = new CardDeck();
            Game game = new Game(deck);

            User user = new User();

            game.AddPlayer(user);

            List<Player> players = game.Players;

            // Note that a dealer is always initialized in the game
            Assert.Equal(players.Count, 2);
        }

        [Fact]
        public void WhenGameStartsWith2Players_ThenThereAre48CardsLeft()
        {
            CardDeck deck = new CardDeck();
            Game game = new Game(deck);
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
            CardDeck deck = new CardDeck();
            Game game = new Game(deck);

            game.StartGame();
            Player p = game.Players[0];

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
            CardDeck deck = new CardDeck();
            Game game = new Game(deck);

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