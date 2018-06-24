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

namespace CallScheduleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            Label lbSend = sender as Label;
            if (lbSend == null)
                return;
            lbSend.BorderThickness = new Thickness(5);
            lbSend.BorderBrush = Brushes.LightBlue;
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            Label lbSend = sender as Label;
            if (lbSend == null)
                return;
            lbSend.BorderThickness = new Thickness();
        }
    }
}
