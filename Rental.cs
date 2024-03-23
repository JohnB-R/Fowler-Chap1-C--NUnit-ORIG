namespace FowlerChap1
{
    //From book: 'Refactoring' by Martin Fowler
    //This is the original code before refactoring begins

    /**
     * The rental class represents a customer renting a movie.
     */
    public class Rental
    {

        private Movie Movie;
        private int DaysRented;

        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        public int GetDaysRented()
        {
            return DaysRented;
        }

        public Movie GetMovie()
        {
            return Movie;
        }



    }
}
