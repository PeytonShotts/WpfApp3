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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 1000; ++i)
            {
                Button button = new Button()
                {
                    Content = string.Format("Button {0}", i),
                    Tag = i,
                    Width = 100,
                    Height = 100
                };
                button.Click += new RoutedEventHandler(button_Click);
                this.grid.Children.Add(button);
            }
        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(string.Format("You clicked on the {0} button.", (sender as Button).Tag));
        }
    }


}
