using System;
using Xunit;

namespace Blackjack.Tests
{
    public class Card
    {
        [Fact]
        public void WhenInitialized_ReturnValue()
        {
            Blackjack.Card card = new Blackjack.Card();

            int value = card.Value.GetValueOrDefault();

            Assert.NotNull(value);
        }

        [Fact]
        public void WhenInitialized_ReturnValueBetween1And13()
        {
            Blackjack.Card card = new Blackjack.Card();

            int value = card.Value.GetValueOrDefault();

            Assert.InRange(value, 1, 14);
        }

        [Fact]
        public void WhenInitialized_ReturnValueIsValid()
        {
            Blackjack.Card card = new Blackjack.Card();

            bool isValid = card.IsCardValid();

            Assert.True(isValid);
        }

        [Fact]
        public void WhenSettingValue_ReturnExpected()
        {
            Blackjack.Card card = new Blackjack.Card();

            card.Value = 4;

            Assert.Equal(card.Value, 4);
        }

        [Fact]
        public void WhenSettingInvalidValue_ThrowArgumentOutOfRangeException()
        {
            Blackjack.Card card = new Blackjack.Card();

            try
            {
                card.Value = 16;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.True(e.GetType() == typeof(ArgumentOutOfRangeException));

                bool invalid = card.IsCardValid();
                Assert.True(invalid);
            }
        }
    }
}