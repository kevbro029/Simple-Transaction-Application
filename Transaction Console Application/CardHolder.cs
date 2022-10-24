using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Transaction_Console_Application
{
    public class CardHolder
    {

        // Variables //

        string firstName;
        string lastName;
        string cardNumber;
        int pin;
        double balance;

        // Public constructor to contain all credentials for the card holder. //

        private CardHolder(string firstName, string lastName, string cardNumber, int pin, double balance)
        {

            this.cardNumber = cardNumber;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;

        }

        // Constructors //

        private string getfirstName() { return firstName; }
        public string getLastName() { return lastName; }
        public string getNum() { return cardNumber; }
        private int getPin() { return pin; }
        private double getBalance() { return balance; }

        // Setters //
        
        public void setFirstName(string newFirstName) { firstName = newFirstName; } 
        public void setLastName(string newLastName) { lastName = newLastName; }
        public void setNum(string newCardNumber) { cardNumber = newCardNumber; }
        public void setPin(int newPin) { pin = newPin; }
        private void setBalance(double newBalance) { balance = newBalance; }

        // Main function argument for the program. //

        public static void Main(string[] args)
        {
            void printOptions()
            {
                WriteLine("Please choose from one of the following options: ");
                WriteLine("1. Deposit.");
                WriteLine("2. Withdraw.");
                WriteLine("3. Show Balance.");
                WriteLine("4. Exit.");
            }

            // Prompts the user to deposit money into the database. //

            void deposit(CardHolder currentUser)
            {
                WriteLine("How much money would you like to deposit? ");
                double deposited = double.Parse(ReadLine());
                currentUser.setBalance(deposited);
                Console.WriteLine("Thank you for your $$. Your new balance is: $" + currentUser.getBalance() + "!");
            }

            // Prompts the user to withdraw money from the database. //

            void withdraw(CardHolder currentUser)
            {
                WriteLine("How much money would you like to withdraw? ");
                double withdrawal = double.Parse(ReadLine());
                if (currentUser.getBalance() > withdrawal)
                {
                    Console.WriteLine("Insufficient balance.");
                }
                else
                {
                    double newBalance = (currentUser.getBalance() - withdrawal);
                    currentUser.setBalance(withdrawal);
                    Console.WriteLine("Thank you for your withdrawal. Your new balance is: $" + currentUser.getBalance() +
                                      "!");
                }
            }

            // Displays the current balance of the user. //

            void balance(CardHolder currentUser)
            {
                Console.WriteLine("Current balance: " + currentUser.getBalance());
            }

            List<CardHolder> cardHolders = new List<CardHolder> {new CardHolder("John", "Griffith", "4738101037632456", 1234, 150.31)};

            Console.WriteLine("Welcome to SimpleATM!");
            Console.WriteLine("Please insert your debit card: ");
            String debitCardNumber = "";
            // currentUser is declared as currentUser2 to satisfy the sustained variable. //
            CardHolder currentUser2;

            // The while loop checks if the input is a valid debit card. //
            
            while (true)
            {
                try
                {
                    debitCardNumber = Console.ReadLine();
                    currentUser2 = cardHolders.FirstOrDefault(a => a.cardNumber == debitCardNumber);
                    if (currentUser2 != null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The card number is not recognized. Please try again.");
                    }
                }
                catch
                {
                    Console.WriteLine("The card number is not recognized. Please try again.");
                }
            }

            Console.WriteLine("Please enter your pin: ");

            // The following while loop checks if the input is a valid pin. //
            
            while(true)
            {
                try
                {
                    var userPin = int.Parse(Console.ReadLine());
                    currentUser2 = cardHolders.FirstOrDefault(a => a.cardNumber == debitCardNumber);
                    if (currentUser2.getPin() == userPin)
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

            Console.WriteLine("Welcome " + currentUser2.getfirstName() + "!");
            int option = 0;

            do
            {
                printOptions();
                try
                {
                    option = int.Parse(ReadLine());
                }
                catch
                {
                    // Ignored.
                }

                // The following if statements execute the following functions that the user selects. //
                
                if (option == 1) { deposit(currentUser2); }
                else if (option == 2) { withdraw(currentUser2); }
                else if (option == 3) { balance(currentUser2); }
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