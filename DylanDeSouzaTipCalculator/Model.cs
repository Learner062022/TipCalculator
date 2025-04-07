using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DylanDeSouzaTipCalculator
{
    public class Model
    {
        string billAmount = "0";
        int amountDiners = 0;
        int amountDecimalNumbers = 0;
        double tipPercentage;

        public string BillAmount
        {
            get => billAmount;
            set => billAmount = value;
        }

        public int AmountDiners
        {
            get => amountDiners;
            set => amountDiners = value;
        }

        public int AmountDecimalNumbers
        {
            get => amountDecimalNumbers;
            set => amountDecimalNumbers = value;
        }

        public double TipPercentage
        {
            get => tipPercentage;
            set => tipPercentage = value;
        }

        public double TipAmount => TipPercentage * double.Parse(BillAmount);

        public double Total => TipAmount + double.Parse(BillAmount);

        public double SplitAmount => AmountDiners > 0 ? Total / AmountDiners : 0;
    }
}