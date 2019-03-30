using MyStatWpf.Controls;
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
using System.Windows.Shapes;

namespace MyStatWpf
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            Card c1 = new Card();
            c1.Content = 1;
            Card c2 = new Card();
            c1.Content = 2;
            //Card c3 = new Card();
            //c1.Content = 3;
            List<UIElement> modules = new List<UIElement>
            {
                c1, c2
            };
            foreach(var i in modules)
            {
                pnl.Children.Add(i);
            }
        }
    }
}
