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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBlock lastTextBlockClicked;
        bool findingMatch = false;
        public MainWindow()
        {
            InitializeComponent();

            SetUpGame();
        }

        private void SetUpGame()
        {
            List<string> animalemoji = new List<string>()
            {  "🐶" , "🐶",
                "🐺" ,  "🐺" ,
                "🐱" , "🐱" ,
                "🦁" , "🦁" ,
                "🦊" , "🦊" ,
                "🐯" , "🐯" ,
                "🐭" , "🐭" ,
                "🦝" , "🦝" ,
            };

            Random random = new Random();

            foreach (TextBlock textblock in maingrid.Children.OfType<TextBlock>())
            {
                int index = random.Next(animalemoji.Count);
                string nextemoji = animalemoji[index];
                textblock.Text = nextemoji;
                animalemoji.RemoveAt(index);

            };

        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;

            }
        }
    }
}
