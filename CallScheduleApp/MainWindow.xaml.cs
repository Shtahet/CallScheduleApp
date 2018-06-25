using System;
using System.Collections.Generic;
using System.Globalization;
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

            InitializYearsList();

            InitializeMonthList();
            
        }

        private void InitializYearsList()
        {
            DateTime currDate = DateTime.Now;

            List<ComboItem> yearList = new List<ComboItem>();

            for (int i = currDate.Year; i < currDate.Year + 5; ++i)
            {
                yearList.Add(new ComboItem(i, i.ToString()));
            }

            years.ItemsSource = yearList;
            years.SelectedValuePath = "Id";
            years.DisplayMemberPath = "DisplayName";
            years.SelectedValue = currDate.Year;
            
        }

        private void InitializeMonthList()
        {
            List<ComboItem> monthList = new List<ComboItem>();
            for (int i = 1; i<=12; ++i)
            {
                monthList.Add(new ComboItem(i, new DateTime((int)years.SelectedValue, i, 1).ToString("MMMM", CultureInfo.CurrentCulture)));
            }

            months.ItemsSource = monthList;
            months.SelectedValuePath = "Id";
            months.DisplayMemberPath = "DisplayName";
            months.SelectedValue = DateTime.Now.Month;

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
