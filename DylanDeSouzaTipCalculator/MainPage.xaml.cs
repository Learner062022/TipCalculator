using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DylanDeSouzaTipCalculator
{
    public partial class MainPage : ContentPage
    {
        Model model = new();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = model;
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Text)
            {
                case "C":
                    model.Reset();
                    break;

                case ".":
                    model.HandleDecimalInput();
                    break;

                case "0":
                    model.HandleNumericInput(button.Text);
                    break;

                default:
                    model.HandleNumericInput(button.Text);
                    break;
            }
        }
    }
}