using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Day> daysItems = new ObservableCollection<Day>();
        public MainWindow()
        {
            InitializeComponent();

            InitializYearsList();

            InitializeMonthList();

            //Init work days
            InitializeDays(work_days, 14, 1);

            //Init rest days
            InitializeDays(rest_days, 14, 2);

            last_call.SelectedDate = DateTime.Today;

            InitializeDaysItemsCollection();

            FillCalendar((int)years.SelectedValue, (int)months.SelectedValue );
        }

        private void FillCalendar(int year, int month)
        {
            DateTime targetDate = new DateTime(year, month, 1);
            int offset = Convert.ToInt32(targetDate.DayOfWeek.ToString("D"));
            DateTime date = (offset !=1) ? targetDate.AddDays(-offset) : targetDate;

            foreach (var day in daysItems)
            {
                day.Date = date;
                day.IsCurrentDay = date == DateTime.Today;
                day.IsCurrentMonth = date.Month == targetDate.Month;
                day.IsWorkingDay = CalcWorkingDay(date, last_call.SelectedDate);

                date = date.AddDays(1);
            }
        }

        private bool CalcWorkingDay(DateTime date, DateTime? selectedDate)
        {
            if (selectedDate == null)
                return false;

            int daysDiff = (date - selectedDate.Value).Days;
            int cycle = (int)work_days.SelectedValue + (int)rest_days.SelectedValue;
            int reminder = Math.Abs(daysDiff % cycle);
            if (date < selectedDate.Value)
            {
                if (reminder < (int)work_days.SelectedValue)
                    return true;
                else
                    return false;
            }
            else
            {
                if (reminder < (int)rest_days.SelectedValue)
                    return false;
                else
                    return true;
            }
        }

        private void InitializeDaysItemsCollection()
        {
            for (int i=0; i<35; ++i)
            {
                daysItems.Add(new Day());
            }

            Calendar.ItemsSource = daysItems;
        }

        private void InitializeDays(ComboBox obj, int length, int deffValue)
        {
            List<int> daysList = new List<int>();

            for (int i = 1; i<=length; ++i)
            {
                daysList.Add(i);
            }

            obj.ItemsSource = daysList;
            obj.SelectedItem = deffValue;
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

    }
}
