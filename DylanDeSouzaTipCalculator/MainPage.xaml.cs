using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DylanDeSouzaTipCalculator
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        bool decimalButtonPressed;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        Model model = new();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public string BillAmount
        {
            get => model.BillAmount;
            set
            {
                if (model.BillAmount != value)
                {
                    model.BillAmount = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TipAmount));
                    OnPropertyChanged(nameof(Total));
                    OnPropertyChanged(nameof(SplitAmount));
                }
            }
        }

        public double Total => model.Total;

        public double TipAmount => model.TipAmount; 

        public double SplitAmount => model.SplitAmount;

        public int AmountDiners
        {
            get => model.AmountDiners; 
            set
            {
                if (model.AmountDiners != value)
                {
                    model.AmountDiners = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SplitAmount));
                }
            }
        }

        public double TipPercentage
        {
            get => model.TipPercentage;
            set
            {
                if (model.TipPercentage != value)
                {
                    model.TipPercentage = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TipAmount));
                    OnPropertyChanged(nameof(Total));
                    OnPropertyChanged(nameof(SplitAmount));
                }
            }
        }

        void Reset()
        {
            BillAmount = "0";  
            AmountDiners = 0;
            model.AmountDecimalNumbers = 0; 
            decimalButtonPressed = false;
            OnPropertyChanged(nameof(TipAmount));
            OnPropertyChanged(nameof(Total));
            OnPropertyChanged(nameof(AmountDiners));
        }

        void HandleDecimalInput()
        {
            if (decimalButtonPressed) return;
            decimalButtonPressed = true;
            BillAmount += ".";
            return;
        }

        void HandleNumericInput(string value)
        {
            if (decimalButtonPressed)
            {
                model.AmountDecimalNumbers += 1;
                if (model.AmountDecimalNumbers > 2) return;
            }
            if (BillAmount == "0") BillAmount = value;
            else BillAmount += value;

        }

        void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Text)
            {
                case "C":
                    Reset();
                    break;

                case ".":
                    HandleDecimalInput();
                    break;

                case "0":
                    if (BillAmount == "0") break;
                    HandleNumericInput(button.Text); 
                    break;

                default:
                    HandleNumericInput(button.Text); 
                    break;
            }
        }
    }
}