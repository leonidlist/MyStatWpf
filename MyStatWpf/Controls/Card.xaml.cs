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

namespace MyStatWpf.Controls
{
    /// <summary>
    /// Логика взаимодействия для Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        public Card()
        {
            InitializeComponent();
        }

        private void Border_DragEnter(object sender, DragEventArgs e)
        {
            DragDrop.DoDragDrop(e.Source as Card, e.Source as Card, DragDropEffects.Move);
        }

        //private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    Cad btn = (Card)e.Source;
        //    int where_to_drop = Pnl.Children.IndexOf(btn);
        //    Pnl.Children.Remove(btn_to_drag);
        //    Pnl.Children.Insert(where_to_drop, btn_to_drag);
        //}
    }
}
