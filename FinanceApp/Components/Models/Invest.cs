using FinanceApp.Components.Helpers;
using System.ComponentModel.DataAnnotations;
namespace FinanceApp.Components.Models;

public class Invest
{
    [Range(0, double.MaxValue, ErrorMessage = "Částka musí být kladná")]
    public double StartingAmount { get; set; }
    [Range(0, double.MaxValue, ErrorMessage = "Částka musí být kladná")]
    public double MonthlyDeposit { get; set; }
    [Range(0, double.MaxValue, ErrorMessage = "Částka musí být kladná")]
    public double ReturnRate { get; set; }
    [Range(1, double.MaxValue, ErrorMessage = "Doba spoření musí být větši než nula")]
    public int InvestmentTime { get; set; }
    public string ResultMoney { get; set; } = "0";

    public List<string> CalculateTotalInvestment()
    {
        List<string> yearlyInvestments = new();
        double currentBalance = StartingAmount;
        int months = InvestmentTime * 12;

        for (int month = 1; month <= months; month++)
        {
            double monthlyGrowth = MonthlyDeposit + (currentBalance * ReturnRate / 100) / 12;
            currentBalance += monthlyGrowth;

            if (month % 12 == 0)
            {
                yearlyInvestments.Add(NumberFormatter.FormatWithSpaces(Math.Round(currentBalance).ToString()));
            }
        }
        ResultMoney = yearlyInvestments.LastOrDefault();
        return yearlyInvestments;
    }

    public List<string> CalculateInvestedAmount()
    {
        List<string> investedAmounts = new();
        double totalInvested = StartingAmount;
        int months = InvestmentTime * 12;

        for (int month = 1; month <= months; month++)
        {
            totalInvested += MonthlyDeposit;

            if (month % 12 == 0)
            {
                investedAmounts.Add(NumberFormatter.FormatWithSpaces(totalInvested.ToString()));
            }
        }
        return investedAmounts;
    }

    public List<string> CalculateProfit()
    {
        List<string> yearlyProfits = new();
        double balance = StartingAmount;
        int months = InvestmentTime * 12;

        for (int month = 1; month <= months; month++)
        {
            double monthlyGrowth = MonthlyDeposit + (balance * ReturnRate / 100) / 12;
            balance += monthlyGrowth;

            if (month % 12 == 0)
                yearlyProfits.Add(NumberFormatter.FormatWithSpaces(Math.Round(balance - (StartingAmount + MonthlyDeposit * month)).ToString()));
        }
        return yearlyProfits;
    }
}
