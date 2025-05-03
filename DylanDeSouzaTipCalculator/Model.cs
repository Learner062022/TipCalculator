using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DylanDeSouzaTipCalculator
{
    public partial class Model : INotifyPropertyChanged
    {
        string billAmount = "0";
        int amountDiners = 1;
        int amountDecimalNumbers = 0;
        double tipPercentage;
        bool decimalButtonPressed;

        public event PropertyChangedEventHandler? PropertyChanged;

        void NotifyMultiplePropertiesChanged(params string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
                NotifyPropertyChanged(propertyName);
        }

        bool UpdateField<T>(ref T field, T value, params string[] dependencies)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false; 

            field = value;
            NotifyMultiplePropertiesChanged(dependencies);
            return true;
        }

        void UpdateDecimalState()
        {
            decimalButtonPressed = BillAmount.Contains('.');
            amountDecimalNumbers = decimalButtonPressed ? BillAmount.Length - BillAmount.IndexOf('.') - 1 : 0;
        }

        protected void NotifyPropertyChanged([CallerMemberName] string? propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public string BillAmount
        {
            get => billAmount;
            set
            {
                if (UpdateField(ref billAmount, value, nameof(BillAmount), nameof(TipAmount), nameof(Total), nameof(SplitAmount)))
                    UpdateDecimalState();
            }
        }

        public int AmountDecimalNumbers
        {
            get => amountDecimalNumbers;
            set => amountDecimalNumbers = value;
        }

        public double TipPercentage
        {
            get => tipPercentage;
            set => UpdateField(ref tipPercentage, value, nameof(TipPercentage), nameof(TipAmount), nameof(Total), nameof(SplitAmount));
        }

        public int AmountDiners
        {
            get => amountDiners;
            set => UpdateField(ref amountDiners, value, nameof(AmountDiners), nameof(SplitAmount));
        }

        public void Reset()
        {
            BillAmount = "0";
            AmountDiners = 1;
            AmountDecimalNumbers = 0;
            decimalButtonPressed = false;
            NotifyMultiplePropertiesChanged(nameof(BillAmount), nameof(TipAmount), nameof(Total), nameof(SplitAmount)); 
        }

        public void HandleNumericInput(string value)
        {
            if (decimalButtonPressed && AmountDecimalNumbers == 2) return;
           
            if (decimalButtonPressed) amountDecimalNumbers++;

            BillAmount = BillAmount == "0" ? value : BillAmount + value;
        }

        public void HandleDecimalInput()
        {
            if (decimalButtonPressed) return;
            decimalButtonPressed = true;
            BillAmount += ".";
            return;
        }

        public double TipAmount => TipPercentage * double.Parse(BillAmount);

        public double Total => TipAmount + double.Parse(BillAmount);

        public double SplitAmount => AmountDiners > 0 ? Total / AmountDiners : 0;
    }
}