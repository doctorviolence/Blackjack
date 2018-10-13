using System.Collections.Generic;

namespace Blackjack
{
    public class Game
    {
        private CardDeck _cardDeck;
        private List<Card> _cards = new List<Card>();
        private List<Player> _players = new List<Player>();

        public Game(CardDeck cardDeck)
        {
            _cardDeck = cardDeck;
            AddDealer();
        }

        private void AddDealer()
        {
            _players.Add(new Dealer());
        }

        public void AddPlayer(Player player)
        {
            bool isUser = player.IsUser();
            bool isDealer = player.IsDealer();

            if (isUser && !isDealer)
                _players.Add(player);

            else if (!isUser && isDealer)
                throw new AddPlayerException("Dealer already exists");
        }

        public void StartGame()
        {
            foreach (Card c in _cardDeck.Cards)
            {
                _cards.Add(c);
            }

            foreach (Player p in _players)
            {
                Card card = _cards[0];
                Card card2 = _cards[1];

                p.Hand = new Hand(p, card, card2);

                _cards.Remove(card);
                _cards.Remove(card2);
            }
        }

        public void DealCard(Player p)
        {
            Hand hand = p.Hand;

            if (!hand.Stay)
            {
                Card card = _cards[0];
                hand.Hit(card);
                _cards.Remove(card);
            }
        }

        public CardDeck CardDeck
        {
            get { return _cardDeck; }
        }

        public List<Card> Cards
        {
            get { return _cards; }
        }

        public List<Player> Players
        {
            get { return _players; }
        }
    }
}