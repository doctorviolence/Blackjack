using System;
using Xunit;

namespace Blackjack.Tests
{
    public class CardTest
    {
        [Fact]
        public void WhenInitialized_ReturnValue()
        {
            Card card = new Card();

            int value = card.Value.GetValueOrDefault();

            Assert.NotNull(value);
        }

        [Fact]
        public void WhenInitialized_ReturnValueBetween1And13()
        {
            Card card = new Card();

            int value = card.Value.GetValueOrDefault();

            Assert.InRange(value, 2, 14);
        }

        [Fact]
        public void WhenInitialized_ReturnValueIsValid()
        {
            Card card = new Card();

            bool isValid = card.IsCardValid();

            Assert.True(isValid);
        }

        [Fact]
        public void WhenSettingValue_ReturnExpected()
        {
            Card card = new Card();

            card.Value = 4;

            Assert.Equal(card.Value, 4);
        }

        [Fact]
        public void WhenSettingInvalidValue_ThrowArgumentOutOfRangeException()
        {
            Card card = new Card();

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