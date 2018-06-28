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
using System.IO;

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
            
            ImageSource imageT = new BitmapImage(new Uri("C:/Users/Public/Pictures/Sample Pictures/Lighthouse.jpg", UriKind.Absolute));

            for (int i = 0; i < 100; ++i)
            {
                Image icon = new Image()
                {
                    Name = "icon" + i.ToString(),
                    Source = imageT,
                    Tag = i,
                    Width = 100,
                    Height = 100,
                    Stretch = Stretch.UniformToFill,
                    Opacity = 0.85
                    
                };
                icon.MouseLeftButtonDown += new MouseButtonEventHandler(Icon_Click);
                icon.MouseEnter += new MouseEventHandler(Icon_MouseEnter);
                icon.MouseLeave += new MouseEventHandler(Icon_MouseLeave);

                this.grid.Children.Add(icon);
            }
        }

        void Icon_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(string.Format("You clicked on the {0} icon.", (sender as Image).Tag));
        }

        void Icon_MouseEnter(object sender, RoutedEventArgs e)
        {
            (sender as Image).Opacity = 1.0;
        }

        void Icon_MouseLeave(object sender, RoutedEventArgs e)
        {
            (sender as Image).Opacity = 0.85;
        }

        private void Button_ChooseFolder_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                //textBox1.Text = filename;
            }

        }
    }


}
