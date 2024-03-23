using System;

namespace FowlerChap1
{
    // From book: 'Refactoring' by Martin Fowler
    // This is the original code before refactoring begins

    public class Movie
    {

        public const int CHILDRENS = 2;
        public const int NEW_RELEASE = 1;
        public const int REGULAR = 0;

        public string Title { get; }
        public int PriceCode { get; private set; }

        public Movie(string title, int priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }

        public int GetPriceCode()
        {
            return PriceCode;
        }

    }
}
