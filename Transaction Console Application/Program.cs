#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Transaction_Console_Application
{
    public class CardHolder
    {

        // Variables //

        static string firstName;
        string lastName;
        static string cardNumber;
        int pin;
        double balance;

        private static string? _lastName = null;
        private static string? _firstName = null;
        private static string _debitCardNumber;
        private static int _pin;
        private static int _pinConfirm;

        // Public constructor to contain all credentials for the card holder. //

        private CardHolder(string firstName, string lastName, string cardNumber, int pin, double balance)
        {

            CardHolder.cardNumber = cardNumber;
            this.pin = pin;
            CardHolder.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;

        }

        // Constructors //

        /*
        public string getNewFirstName() { return _firstName; }

        public string getNewLastName() { return _lastName; }

        public string getNewNum() { return _debitCardNumber; }

        public int getNewPin() { return _pin; } 
        */

        // Local Constructors //

        private string getfirstName() { return firstName; }
        public string getLastName() { return lastName; }
        public string getNum() { return cardNumber; }
        private int getPin() { return pin; }
        private double getBalance() { return balance; }

        // Setters //

        private void setBalance(double newBalance) { balance = newBalance; }

        // Main function argument for the program. //

        // ReSharper disable once InconsistentNaming. //
        public static void Main(string[] args)
        {
            
            void PrintOptions()
            {
                WriteLine("Please choose from one of the following options: ");
                WriteLine("1. Deposit.");
                WriteLine("2. Withdraw.");
                WriteLine("3. Show Balance.");
                WriteLine("4. Exit.");
            }

            // Prompts the user to deposit money into the database. //

            void Deposit(CardHolder currentUser)
            {
                WriteLine("How much money would you like to deposit? Please enter a number.");
                double deposited = double.Parse(ReadLine());
                double newBalance = currentUser.getBalance() + deposited;
                currentUser.setBalance(newBalance);
                Console.WriteLine("Thank you for your $$. Your new balance is: $" + newBalance + "!");
            }

            // Prompts the user to withdraw money from the database. //

            void Withdraw(CardHolder currentUser)
            {
                WriteLine("How much money would you like to withdraw? Please enter a number.");
                double withdrawal = double.Parse(ReadLine());
                if (currentUser.getBalance() < withdrawal)
                {
                    Console.WriteLine("Insufficient balance.");
                }
                else
                {
                    currentUser.setBalance(currentUser.getBalance() - withdrawal);
                    Console.WriteLine("Thank you for your withdrawal. Your new balance is: $" + currentUser.getBalance() + "!");
                }
            }

            // Displays the current balance of the user. //

            void Balance(CardHolder currentUser)
            {
                Console.WriteLine("Current balance: " + currentUser.getBalance());
            }

            var cardHolders = new List<CardHolder> {new CardHolder("John", "Smith","1234567890123456", 1234, 500.00)};

            Console.WriteLine("Welcome to SimpleATM!");
            Console.WriteLine("Please insert your debit card.");
            var debitCardNumber = "";
            CardHolder currentUser;

            // The while loop checks if the input is a valid debit card. //

            while (true)
            {
                try
                {
                    debitCardNumber = int.Parse(Console.ReadLine()).ToString();
                    currentUser = cardHolders.FirstOrDefault(a => CardHolder.cardNumber == debitCardNumber);
                    if (currentUser != null)
                    {
                        break;
                    }
                    /* else
                    {
                        Console.WriteLine("An error has occured. Please try again.");
                    } */
                }
                catch
                {
                    Console.WriteLine("An error has occured. Please try again.");
                }
            }
            
            // The following while loop checks if the input is a valid pin. //
            
            while(true)
            {
                try
                {
                    Console.WriteLine("Please enter your pin: ");
                    var userPin = int.Parse(Console.ReadLine());
                    currentUser = cardHolders.FirstOrDefault(a => CardHolder.cardNumber == debitCardNumber);
                    // ReSharper disable once PossibleNullReferenceException. //
                    if (currentUser.getPin() == userPin)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The given pin is incorrect. Please try again.");
                    }
                }
                catch
                {
                    Console.WriteLine("The given pin is incorrect. Please try again.");
                }
            }
            
            Console.WriteLine("Welcome " + currentUser.getfirstName() + "!");
            int option = 0;

            do
            {
                PrintOptions();
                try
                {
                    option = int.Parse(ReadLine());
                }
                catch
                {
                    // Ignored.
                }

                // The following if statements execute the following functions that the user selects. //
                
                if (option == 1) { Deposit(currentUser); }
                else if (option == 2) { Withdraw(currentUser); }
                else if (option == 3) { Balance(currentUser); }
                else if (option == 4) { break; }
                else
                {
                    option = 0;
                    Console.WriteLine("I couldn't understand that. Please try again.");
                }
            }

            while (option != 4);
            Console.WriteLine("Thank you for doing business with us!");
        
        }
    }
}