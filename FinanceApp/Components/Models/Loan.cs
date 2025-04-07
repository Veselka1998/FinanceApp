using FinanceApp.Components.Helpers;
using System.ComponentModel.DataAnnotations;
namespace FinanceApp.Components.Models;

public class Loan
{
    [Range(1, double.MaxValue, ErrorMessage = "Úvěr musí být větší něž nula")]
    public double LoanAmount { get; set; } 
    [Range(1, 1000, ErrorMessage = "Doba splatnosti musí být větší než nula")]
    public int LoanTerm { get; set; } = 30;
    [Range(0, 10000, ErrorMessage = "Úrok musí být kladný")]
    public double InterestRate { get; set; }
    public string ResultMoney { get; set; } = "0";

    public List<string> CalculateTotalDebt()
    {
        List<string> yearlyDebts = new();
        int months = LoanTerm * 12;

        if (LoanAmount <= 0)
            return yearlyDebts;

        double debt = LoanAmount;
        double monthlyInterest = InterestRate / 100 / 12;

        double monthlyPayment;

        if (InterestRate == 0)
        {
            monthlyPayment = LoanAmount / months;
        }
        else
        {
            double numerator = monthlyInterest * Math.Pow(1 + monthlyInterest, months);
            double denominator = Math.Pow(1 + monthlyInterest, months) - 1;
            monthlyPayment = LoanAmount * (numerator / denominator);
        }

        for (int month = 1; month <= months; month++)
        {
            if (InterestRate != 0)
            {
                double interest = debt * monthlyInterest;
                double principal = monthlyPayment - interest;
                debt -= principal;
            }
            else
            {
                debt -= monthlyPayment;
            }

            if (month % 12 == 0)
            {
                yearlyDebts.Add(NumberFormatter.FormatWithSpaces(Math.Abs(Math.Round(debt)).ToString()));
            }
        }
        ResultMoney = NumberFormatter.FormatWithSpaces(Math.Round(monthlyPayment, 2).ToString());
        return yearlyDebts;
    }

    public List<string> CalculateTotalInterest()
    {
        List<string> yearlyInterests = new();
        double debt = LoanAmount;
        int months = LoanTerm * 12;

        double monthlyInterestRate = InterestRate / 12 / 100;
        double monthlyPayment;

        if (InterestRate == 0)
        {
            monthlyPayment = 0;
        }
        else
        {
            double numerator = monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, months);
            double denominator = Math.Pow(1 + monthlyInterestRate, months) - 1;
            monthlyPayment = LoanAmount * (numerator / denominator);
        }

        double yearlyInterest = 0;

        for (int month = 1; month <= months; month++)
        {
            double monthlyInterestAmount = monthlyInterestRate * debt;
            yearlyInterest += monthlyInterestAmount;

            double principalPayment = monthlyPayment - monthlyInterestAmount;
            debt -= principalPayment;

            if (month % 12 == 0)
            {
                yearlyInterests.Add(NumberFormatter.FormatWithSpaces(Math.Round(yearlyInterest).ToString()));
                yearlyInterest = 0;
            }
        }
        return yearlyInterests;
    }

    public List<string> CalculateTotalPayments()
    {
        List<string> yearlyPayments = new();
        double totalPaid = 0;
        int months = LoanTerm * 12;

        double monthlyPayment;

        if (InterestRate == 0)
        {
            monthlyPayment = LoanAmount / months;
        }
        else
        {
            double monthlyInterest = InterestRate / 12 / 100;
            double numerator = monthlyInterest * Math.Pow(1 + monthlyInterest, months);
            double denominator = Math.Pow(1 + monthlyInterest, months) - 1;
            monthlyPayment = LoanAmount * (numerator / denominator);
        }

        for (int month = 1; month <= months; month++)
        {
            totalPaid += monthlyPayment;

            if (month % 12 == 0)
            {
                yearlyPayments.Add(NumberFormatter.FormatWithSpaces(Math.Round(totalPaid).ToString()));
            }
        }
        return yearlyPayments;
    }
}
