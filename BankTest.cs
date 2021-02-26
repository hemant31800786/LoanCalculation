using System;

namespace LoanCalculation
{
    class BankTest
    {
        static void Main()
        {

            double amount;
            double rate;
            int years;

            int menuChoice;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            do
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t Banking Application Test\n");

                Console.Write("Enter loan amount :");
                Console.ForegroundColor = ConsoleColor.Yellow;
                amount = ValidateDouble(Console.ReadLine());


                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter annual interest rate :");
                Console.ForegroundColor = ConsoleColor.Yellow;
                rate = ValidateDouble(Console.ReadLine());



                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter number of years :");
                Console.ForegroundColor = ConsoleColor.Yellow;
                years = ValidateInterger(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.Green;
                Loan loan = new Loan(amount, rate, years);

                loan.TotalInterestCalculation();


                Console.WriteLine("\n\t Monthly Installment  =" + loan.GetMonthlyPayment());
                Console.WriteLine("\n\t Total Interest  =" + loan.TotalInterest);
                Console.WriteLine("\n\t Administration Fee =" + loan.AdministrationFee(amount));

                Console.WriteLine("\n");





                Console.WriteLine("Press 3 : Monthly/Yearly Statement ");
                Console.WriteLine("Press 5 : Exit");
                Console.WriteLine("Press Other Numeric key to Main Menu");
                menuChoice = ValidateInterger(Console.ReadLine());
                if (menuChoice == 3)
                {
                    int subchoice;
                    do
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n\t\t Loan Statement\n");
                        Console.WriteLine("\n\t\t 1.Monthly\n");
                        Console.WriteLine("\n\t\t 2.Yearly\n");
                        Console.WriteLine("\n\t\t 3.Exit\n");
                        subchoice = ValidateInterger(Console.ReadLine());


                        if (subchoice == 1) loan.MonthlyStament();
                        if (subchoice == 2) loan.YearlyStament();

                        Console.ReadKey();
                        Console.Clear();

                    } while (subchoice != 3);

                }

             

                Console.Clear();
            } while (menuChoice != 5);




        }


        static double ValidateDouble(dynamic data)
        {
            double inputdata = 0;
            bool itsNumeric = false;
            while (itsNumeric == false)
            {
                itsNumeric = double.TryParse(data, out inputdata);
                if (itsNumeric == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("In Valid Data");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Enter Correct Data  :");
                    itsNumeric = double.TryParse(Console.ReadLine(), out inputdata);
                }


            }

            return inputdata;
        }
        static int ValidateInterger(dynamic data)
        {
            int inputdata = 0;
            bool itsNumeric = false;
            while (itsNumeric == false)
            {
                itsNumeric = int.TryParse(data, out inputdata);
                if (itsNumeric == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("In Valid Data");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Enter Correct Data  :");
                    itsNumeric = int.TryParse(Console.ReadLine(), out inputdata);
                }


            }

            return inputdata;
        }

    }
}
