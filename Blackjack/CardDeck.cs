namespace Blackjack
{
    public class CardDeck
    {
        private Card[] _cards = new Card[52];

        public CardDeck()
        {
            InitializeCardDeck();
        }

        // Note that this is an unneccesary convoluted solution to initialize the card deck
        // Code below represents my 3rd solution (practicing different implementations) for getting four of a kind in the card deck
        private void InitializeCardDeck()
        {
            for (int i = 0; i < _cards.Length; i++)
            {
                _cards[i] = CreateNewCard();
            }
        }

        private Card CreateNewCard()
        {
            Card card = new Card();
            int? value = card.Value;
            bool isFourOfAKind = CheckOccurenceOfCard(value.GetValueOrDefault());

            if (isFourOfAKind)
            {
                return CreateNewCard();
            }

            return card;
        }

        private bool CheckOccurenceOfCard(int value)
        {
            int occurence = 0;

            for (int i = 0; i < _cards.Length; i++)
            {
                if (_cards[i] != null && value == _cards[i].Value)
                {
                    occurence++;
                }
            }

            return occurence == 4;
        }

        public Card[] Cards
        {
            get { return _cards; }
        }
    }
}