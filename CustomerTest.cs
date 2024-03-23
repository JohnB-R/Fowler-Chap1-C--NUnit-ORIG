using System;
using NUnit.Framework;

namespace FowlerChap1
{

    [TestFixture]
    public class CustomerTest
    {

        [Test]
        public void TestGetName()
        {
            Customer c = new Customer("David");
            Assert.AreEqual("David", c.GetName());
        }

        [Test]
        public void TestStatementForRegularMovie()
        {
            Customer customer2 = new Customer("Sallie");
            Movie movie1 = new Movie("Gone with the Wind", Movie.REGULAR);
            Rental rental1 = new Rental(movie1, 3); // 3 day rental
            customer2.AddRental(rental1);
            String expected = "Rental Record for Sallie\n" +
                                "\tGone with the Wind\t3,5\n" +
                                "Amount owed is 3,5\n" +
                                "You earned 1 frequent renter points";

            String statement = customer2.Statement();

            Assert.AreEqual(expected, statement);
        }

        [Test]
        public void TestStatementForNewReleaseMovie()
        {
            Customer customer2 = new Customer("Sallie");
            Movie movie1 = new Movie("Star Wars", Movie.NEW_RELEASE);
            Rental rental1 = new Rental(movie1, 3); // 3 day rental
            customer2.AddRental(rental1);
            String expected = "Rental Record for Sallie\n" +
                                "\tStar Wars\t9\n" +
                                "Amount owed is 9\n" +
                                "You earned 2 frequent renter points";
            String statement = customer2.Statement();
            Assert.AreEqual(expected, statement);
        }

        [Test]
        public void TestStatementForChildrensMovie()
        {
            Customer customer2 = new Customer("Sallie");
            Movie movie1 = new Movie("Madagascar", Movie.CHILDRENS);
            Rental rental1 = new Rental(movie1, 3); // 3 day rental
            customer2.AddRental(rental1);
            String expected = "Rental Record for Sallie\n" +
                                "\tMadagascar\t1,5\n" +
                                "Amount owed is 1,5\n" +
                                "You earned 1 frequent renter points";
            String statement = customer2.Statement();
            Assert.AreEqual(expected, statement);
        }

        [Test]
        public void TestStatementForManyMovies()
        {
            Customer customer1 = new Customer("David");
            Movie movie1 = new Movie("Madagascar", Movie.CHILDRENS);
            Rental rental1 = new Rental(movie1, 6); // 6 day rental
            Movie movie2 = new Movie("Star Wars", Movie.NEW_RELEASE);
            Rental rental2 = new Rental(movie2, 2); // 2 day rental
            Movie movie3 = new Movie("Gone with the Wind", Movie.REGULAR);
            Rental rental3 = new Rental(movie3, 8); // 8 day rental
            customer1.AddRental(rental1);
            customer1.AddRental(rental2);
            customer1.AddRental(rental3);
            String expected = "Rental Record for David\n" +
                                "\tMadagascar\t6\n" +
                                "\tStar Wars\t6\n" +
                                "\tGone with the Wind\t11\n" +
                                "Amount owed is 23\n" +
                                "You earned 4 frequent renter points";
            String statement = customer1.Statement();
            Assert.AreEqual(expected, statement);
        }
    }
}
