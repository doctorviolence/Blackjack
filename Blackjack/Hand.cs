using System.Collections.Generic;

namespace Blackjack
{
    public class Hand
    {
        private List<Card> _cards = new List<Card>();
        private Player _player;
        private int? _score;

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

        public int CalculateScore()
        {
            int? score = 0;
            foreach (var c in _cards)
            {
                if (c.Value != 11 && c.Value > 9)
                    c.Value = 10;

                score += c.Value;
            }

            if (score > 21)
            {
                score = 0;

                foreach (var c in _cards)
                {
                    if (c.Value == 11)
                        c.Value = 1;

                    score += c.Value;
                }
            }

            return score.GetValueOrDefault();
        }

        public bool Stay { get; set; }

        public bool Bust { get; set; }

        public int Score
        {
            get
            {
                if (_score == null)
                    _score = CalculateScore();

                return _score.GetValueOrDefault();
            }
        }

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