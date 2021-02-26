using LoanCalculation.Core.Repositories;
using System;
using System.Linq;

namespace LoanCalculation
{
    class Loan : ILoan

    {
        private readonly double _loanAmount;
        private readonly double _interestRate;
        private readonly int _noOfYears;
        private readonly int _fixAdministrationFee = 10000;

        double[] _interestPaidStatment;
        double[] _principlePaidStatment;
        double[] _newBalancetatment;
        double[] _totalinterestStatment;
        double[] _monthlyEmiStatment;

        public double TotalInterest { get; set; }

        public Loan(double amount, double rate, int years)
        {
            this._loanAmount = amount;
            this._interestRate = (rate / 100.0) / 12.0;
            this._noOfYears = years;
        }

        public double GetMonthlyPayment()
        {
            int months = _noOfYears * 12;
            return Math.Round((_loanAmount * _interestRate * Math.Pow(1 + _interestRate, months)) / (Math.Pow(1 + _interestRate, months) - 1), 2);
        }

        public double AdministrationFee(double loanAmount)
        {
            var administrationFee = (loanAmount / 100);
            return administrationFee < _fixAdministrationFee ? administrationFee : _fixAdministrationFee;

        }
        public void MonthlyStament()
        {


            try
            {
                double monthlyPayment = GetMonthlyPayment();//calculates monthly payment

                //nonth, payment amount, principal paid, interest paid, total interest paid, balance
                Console.WriteLine("{0,-10}{1,10}{2,10}{3,10}{4,10}", "Month ", " Payment Amt ", " Interest Paid ", " Principal paid ", " Balance Due ");
                for (int month = 1; month <= _noOfYears * 12; month++)
                {

                    Console.WriteLine("{0,-10}{1,10:N2}{2,15:N2}{3,15:N2}{4,16:N2}",
     month, _monthlyEmiStatment[month - 1], _interestPaidStatment[month - 1], _principlePaidStatment[month - 1], _newBalancetatment[month - 1]);
                    // Update the balance

                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        public void YearlyStament()
        {
            try
            {

                double[] _interestYearly = new double[12];
                double[] _principleYearly = new double[12];

                double[] _monthYearly = new double[12];
                int _monthCounter = 0;
                int _noMonths = 12;
                int snrNo = 1;


                Console.WriteLine("{0,-10}{1,10}{2,10}{3,10}{4,10}", "Year", " Payment Amt ", " Interest Paid ", " Principal paid ", " Balance Due ");
                for (int month = 1; month <= _noOfYears * 12; month++)
                {
                    _interestYearly[_monthCounter] = _interestPaidStatment[month - 1];
                    _principleYearly[_monthCounter] = _principlePaidStatment[month - 1];
                    _monthYearly[_monthCounter] = _monthlyEmiStatment[month - 1];
                    _monthCounter += 1;
                    if (month == _noMonths)
                    {
                        _monthCounter = 0;
                        _noMonths += 12;
                        Console.WriteLine("{0,-10}{1,10:N2}{2,15:N2}{3,15:N2}{4,16:N2}",
                        snrNo, _monthlyEmiStatment.Sum(), _interestYearly.Sum(), _principleYearly.Sum(), _newBalancetatment[month - 1]);

                        snrNo += 1;

                    }


                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void TotalInterestCalculation()
        {
            try
            {
                double monthlyPayment = GetMonthlyPayment();//calculates monthly payment
                double principalPaid = 0;
                double newBalance = 0;
                double interestPaid = 0;
                double principal = _loanAmount;
                double totalinterest = 0;
                _interestPaidStatment = new double[_noOfYears * 12];
                _principlePaidStatment = new double[_noOfYears * 12];
                _newBalancetatment = new double[_noOfYears * 12];
                _totalinterestStatment = new double[_noOfYears * 12];
                _totalinterestStatment = new double[_noOfYears * 12];

                _monthlyEmiStatment = new double[_noOfYears * 12];

                for (int month = 1; month <= _noOfYears * 12; month++)
                {

                    interestPaid = Math.Round(principal * _interestRate, 2, MidpointRounding.AwayFromZero);
                 
                    principalPaid = Math.Round(monthlyPayment - interestPaid, 2, MidpointRounding.AwayFromZero);
                 
                    newBalance = Math.Round(principal - principalPaid, 2, MidpointRounding.AwayFromZero);
                 

                    if (newBalance <= 0)
                    {
                        principalPaid += newBalance;
                        monthlyPayment = principalPaid + interestPaid;
                        newBalance = 0;
                    }
                    totalinterest += interestPaid;

                    _interestPaidStatment[month - 1] = interestPaid;
                    _principlePaidStatment[month - 1] = principalPaid;
                    _newBalancetatment[month - 1] = newBalance;
                    _totalinterestStatment[month - 1] = totalinterest;

                    _monthlyEmiStatment[month - 1] = monthlyPayment;

                   
                    principal = newBalance;
                }
                TotalInterest = Math.Round(totalinterest, 2, MidpointRounding.AwayFromZero);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
