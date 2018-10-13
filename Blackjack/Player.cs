using System;

namespace Blackjack
{
    public abstract class Player
    {
        public Hand Hand { get; set; }

        public abstract bool IsDealer();

        public abstract bool IsUser();
    }

    public class User : Player
    {
        public override bool IsDealer()
        {
            return false;
        }

        public override Boolean IsUser()
        {
            return true;
        }
    }

    public class Dealer : Player
    {
        public override bool IsDealer()
        {
            return true;
        }

        public override Boolean IsUser()
        {
            return false;
        }
    }
}