using System.Collections.Generic;

namespace Blackjack
{
    public class Hand
    {
        private List<Card> _cards = new List<Card>();
        private Player _player;

        public Hand(Player player, Card card1, Card card2)
        {
            _player = player;
            _cards.Add(card1);
            _cards.Add(card2);
        }

        public void Hit(Card card)
        {
            _cards.Add(card);
        }

        public bool Stay { get; set; }

        public List<Card> Cards
        {
            get { return _cards; }
        }

        public Player Player
        {
            get { return _player; }
        }
    }
}