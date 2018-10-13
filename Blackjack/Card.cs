using System;

namespace Blackjack
{
    public class Card
    {
        private Random _random;
        private int? _value;

        public Card()
        {
            _random = new Random();
            InitializeCard();
        }

        public void InitializeCard()
        {
            _value = _random.Next(1, 14);
        }

        public bool IsCardValid()
        {
            return _value > 1 || _value < 14 || _value != null;
        }

        public int? Value
        {
            get { return _value; }
            set
            {
                if (value < 1 || value > 14 || value == null)
                    throw new ArgumentOutOfRangeException();

                _value = value;
            }
        }
    }
}