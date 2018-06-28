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
        string directoryName;
        int selectedImage;
        public string[] filePaths;


        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }

        public MainWindow()
        {
            InitializeComponent();
            
            ImageSource imageT = new BitmapImage(new Uri("C:/Users/Public/Pictures/Sample Pictures/Lighthouse.jpg", UriKind.Absolute));


            System.Drawing.Bitmap newBitmap = new System.Drawing.Bitmap("C:/Users/Public/Pictures/Sample Pictures/Lighthouse.jpg");
            System.Drawing.Color pixelColor = newBitmap.GetPixel(0, 0);

            //Console.WriteLine("red: " + pixelColor.R);

            newBitmap.SetPixel(0, 0, System.Drawing.Color.FromArgb(0, 0, 0));
            newBitmap.Save("Lighthouse_edit.jpg");

            //System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            //Console.WriteLine(encoding.GetBytes("t")[0]);

            Console.WriteLine(StringToBinary("test"));
        }

        void Icon_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(string.Format("You clicked on the {0} icon.", (sender as Image).Name));

            selectedImage = Convert.ToInt32((sender as Image).Tag);
            ImageSource iconSource = new BitmapImage(new Uri(filePaths[selectedImage], UriKind.Absolute));
            Image_LargePreview.Source = iconSource;
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
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string fileName = dlg.FileName;
                int strIndex = fileName.LastIndexOf('\\');
                directoryName = fileName.Substring(0, strIndex);
                Label_FilePath.Content = directoryName;

                filePaths = Directory.GetFiles(directoryName, "*",
                                         SearchOption.TopDirectoryOnly);


                string[] fileNames = new string[filePaths.Length];

                for (int i=0; i<filePaths.Length;i++)
                {
                    string s = filePaths[i];

                    fileNames[i] = System.IO.Path.GetFileNameWithoutExtension(filePaths[i]);

                    ImageSource iconSource = new BitmapImage(new Uri(s, UriKind.Absolute));

                    Image icon = new Image()
                    {
                        Name = "image_" + i,
                        Tag = i,
                        Source = iconSource,
                        Width = 100,
                        Height = 100,
                        Stretch = Stretch.Fill,
                        Opacity = 0.85

                    };


                    icon.MouseLeftButtonDown += new MouseButtonEventHandler(Icon_Click);
                    icon.MouseEnter += new MouseEventHandler(Icon_MouseEnter);
                    icon.MouseLeave += new MouseEventHandler(Icon_MouseLeave);

                    this.grid.Children.Add(icon);
                }

            }

        }

        private string StringToBinary(string inputString)
        {
            string output = "";
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

            for (int i = 0; i < inputString.Length; i++)
            {
                int asciiValue = encoding.GetBytes(inputString)[i];
                string binaryChar = Convert.ToString(asciiValue, 2);
                
                string EightBitChar = binaryChar.PadLeft(8, '0');

                output += EightBitChar;
            }
             
            return output;
        }

        private string BinaryToString(string inputBinary)
        {
            return null;
        }

        private void encodeImage(System.Drawing.Bitmap inputImage, string text)
        {
            string binaryText = StringToBinary(text);

            for (int i=0; i<80; i++)
            {
                int r = inputImage.GetPixel(i, 0).R;
                int c = binaryText[i];

                if (r % 2 == )
            }
        }
    }



}
