using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Clases;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double Primero;
        double Segundo;
        string Operador;
        public MainWindow()
        {
            InitializeComponent();
        }

         Suma obj = new Suma();
         Resta obj2 = new Resta();
         Multiplicacion obj3 = new Multiplicacion();
         Divicion obj4 = new Divicion();

        private void ButtonClick (object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string value = (string)button.Content;

            if (IsNumber(value))
            {
                HandleNumbers(value);

            }
            else if (value == "C" )
            {
                if (Screen.Text.Length > 1)
                {
                    Screen.Text = Screen.Text.Remove(Screen.Text.Length - 1);
                }
                else
                {
                    Screen.Clear();
                }
            }
            else if (value == "CE")
            {
                if (Screen.Text.Length > 0)
                {
                    Screen.Clear();

                }
            }
            
        }
        public bool IsNumber (string PossibleNumber)
        {
            return double.TryParse(PossibleNumber, out _);
        }
        public void HandleNumbers (string values)
        {
            if ( string.IsNullOrEmpty( Screen.Text ) )
            {
                Screen.Text = values;
            }
            else
            {
                Screen.Text += values;
            }
        }


        private void ButtonEq_Click(object sender, RoutedEventArgs e)
        {

            Segundo = double.Parse(Screen.Text);

            double Sum;
            double res;
            double mul;
            double div;

            switch (Operador)
            {
                    case "+":
                    Sum = obj.Sumar((Primero), (Segundo));
                    Screen.Text = Sum.ToString();
                    break;

                    case "-":
                    res = obj2.Restar((Primero), (Segundo));
                    Screen.Text=res.ToString();
                    break ;

                    case "*":
                    mul = obj3.Multiplicar((Primero), (Segundo));
                    Screen.Text=mul.ToString();
                    break ;

                    case "/":
                    div = obj4.Dividir((Primero), (Segundo));
                    Screen.Text =div.ToString();
                    break;
            }
        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            Operador = "+";
            Primero = double.Parse(Screen.Text);
            Screen.Clear();

        }
        private void ButtonMul_Click(object sender, RoutedEventArgs e)
        {
            Operador = "*";
            Primero = double.Parse(Screen.Text);
            Screen.Clear();
        }

        private void ButtonDiv_Click(object sender, RoutedEventArgs e)
        {
            Operador = "/";
            Primero = double.Parse(Screen.Text);
            Screen.Clear();
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            Operador = "-";
            Primero = double.Parse(Screen.Text);
            Screen.Clear();
        }
    }
}
