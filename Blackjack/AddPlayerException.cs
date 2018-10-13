using System;

namespace Blackjack
{
    public class AddPlayerException : Exception
    {
        public AddPlayerException()
        {
        }

        public AddPlayerException(string message) : base(message)
        {
        }

        public AddPlayerException(string message, Exception e) : base(message, e)
        {
        }
    }
}