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
        public MainWindow()
        {
            InitializeComponent();

            var img1 = CreateImage("C:/Users/Public/Pictures/Sample Pictures/lighthouse.jpg");
            var img2 = CreateImage("C:/Users/Public/Pictures/Sample Pictures/desert.jpg");

            Image newImage = new Image();
            ImageSource Image1 = new BitmapImage(new Uri("C:/Users/Public/Pictures/Sample Pictures/lighthouse.jpg"));
            image1.Source = Image1;
            image2.Source = Image1;
            image3.Source = Image1;
            image4.Source = Image1;


        }



        private Image CreateImage(string imagePath)
        {
            Image newImage = new Image();
            ImageSource MoleImage = new BitmapImage(new Uri(imagePath));
            newImage.Source = MoleImage;
            return newImage;
        }
    }


}
