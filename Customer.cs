﻿using System;
using System.Collections.Generic;

namespace FowlerChap1
{
    //From book: 'Refactoring' by Martin Fowler
    //This is the original code before refactoring begins

    public class Customer
    {
        public string Name { get; }
        public List<Rental> Rentals { get; } = new List<Rental>();

        public Customer(string name)
        {
            Name = name;
        }

        public void AddRental(Rental arg)
        {
            Rentals.Add(arg);
        }

        public String GetName()
        {
            return Name;
        }

        public string Statement()
        {
            var totalAmount = 0.0;
            int frequentRenterPoints = 0;
            String result = "Rental Record for " + GetName() + "\n";

            foreach (Rental each in Rentals)
            {
                double thisAmount = 0;

                //determine amounts for each line
                switch (each.GetMovie().GetPriceCode())
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (each.GetDaysRented() > 2)
                            thisAmount += (each.GetDaysRented() - 2) * 1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += each.GetDaysRented() * 3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (each.GetDaysRented() > 3)
                            thisAmount += (each.GetDaysRented() - 3) * 1.5;
                        break;
                }

                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if ((each.GetMovie().GetPriceCode() == Movie.NEW_RELEASE) && each.GetDaysRented() > 1)
                    frequentRenterPoints++;

                // show figures for this rental
                result += "\t" + each.GetMovie().Title + "\t" + thisAmount + "\n";
                totalAmount += thisAmount;
            }

            // add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";

            return result;
        }
    }
}
