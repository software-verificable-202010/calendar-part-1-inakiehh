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

namespace Calendario
{
    public partial class MainWindow : Window
    {
        #region lists
        List<string> monthsList = new List<string>();
        List<Label> labelsList = new List<Label>();
        List<Button> cellsList = new List<Button>();
        #endregion

        #region methods
        private void GenerateDates(string monthString, string yearString)
        {
            int monthNumber;
            int yearNumber = Convert.ToInt32(yearString);
            monthNumber = monthsList.IndexOf(monthString);
            monthNumber += 1;

            int totalDaysOnMonth = DateTime.DaysInMonth(yearNumber, monthNumber);

            DateTime dateValue = new DateTime(yearNumber, monthNumber, 1);
            int firstDayOfMonth = ((int)dateValue.DayOfWeek);

            //Changes perception of week (Sun - Sat to Mon - Sun).
            if (firstDayOfMonth == 0)
            {
                firstDayOfMonth = 7;
            }

            firstDayOfMonth -= 1;
            int days = 1;

            foreach(Button cell in cellsList)
            {
                cell.Opacity = 1.0;
            }

            //Sets the number and cell opacity of the day from the first day of the month.
            for (int dayIndex = firstDayOfMonth; dayIndex < labelsList.Count; dayIndex++)
            {
                if (days <= totalDaysOnMonth)
                {
                    Label item = labelsList[dayIndex];
                    item.Content = days;
                    days += 1;
                    continue;
                }
                else
                {
                    Label item = labelsList[dayIndex];
                    item.Content = "";
                    Button outOfCalendarGrid = cellsList[dayIndex];
                    outOfCalendarGrid.Opacity = 0.3;
                }
            }

            //Sets to empty and lower opacity of the days before the first day of the month.
            for (int dayIndex = 0; dayIndex < firstDayOfMonth; dayIndex++)
            {
                Label item = labelsList[dayIndex];
                item.Content = "";
                Button outOfCalendarGrid = cellsList[dayIndex];
                outOfCalendarGrid.Opacity = 0.3;
            }
            
        }
        private void FillMonthsList(List<string> monthsList)
        {
            monthsList.Add("January");
            monthsList.Add("February");
            monthsList.Add("March");
            monthsList.Add("April");
            monthsList.Add("May");
            monthsList.Add("June");
            monthsList.Add("July");
            monthsList.Add("August");
            monthsList.Add("September");
            monthsList.Add("October");
            monthsList.Add("November");
            monthsList.Add("Dicember");
        }
        private void FillLabelsList(List<Label> labelsList) {
            labelsList.Add(dateText1);
            labelsList.Add(dateText2);
            labelsList.Add(dateText3);
            labelsList.Add(dateText4);
            labelsList.Add(dateText5);
            labelsList.Add(dateText6);
            labelsList.Add(dateText7);
            labelsList.Add(dateText8);
            labelsList.Add(dateText9);
            labelsList.Add(dateText10);
            labelsList.Add(dateText11);
            labelsList.Add(dateText12);
            labelsList.Add(dateText13);
            labelsList.Add(dateText14);
            labelsList.Add(dateText15);
            labelsList.Add(dateText16);
            labelsList.Add(dateText17);
            labelsList.Add(dateText18);
            labelsList.Add(dateText19);
            labelsList.Add(dateText20);
            labelsList.Add(dateText21);
            labelsList.Add(dateText22);
            labelsList.Add(dateText23);
            labelsList.Add(dateText24);
            labelsList.Add(dateText25);
            labelsList.Add(dateText26);
            labelsList.Add(dateText27);
            labelsList.Add(dateText28);
            labelsList.Add(dateText29);
            labelsList.Add(dateText30);
            labelsList.Add(dateText31);
            labelsList.Add(dateText32);
            labelsList.Add(dateText33);
            labelsList.Add(dateText34);
            labelsList.Add(dateText35);
            labelsList.Add(dateText36);
            labelsList.Add(dateText37);
            labelsList.Add(dateText38);
            labelsList.Add(dateText39);
            labelsList.Add(dateText40);
            labelsList.Add(dateText41);
            labelsList.Add(dateText42);
        }
        private void FillCellsList(List<Button> cellsList) {
            cellsList.Add(dateCell1);
            cellsList.Add(dateCell2);
            cellsList.Add(dateCell3);
            cellsList.Add(dateCell4);
            cellsList.Add(dateCell5);
            cellsList.Add(dateCell6);
            cellsList.Add(dateCell7);
            cellsList.Add(dateCell8);
            cellsList.Add(dateCell9);
            cellsList.Add(dateCell10);
            cellsList.Add(dateCell11);
            cellsList.Add(dateCell12);
            cellsList.Add(dateCell13);
            cellsList.Add(dateCell14);
            cellsList.Add(dateCell15);
            cellsList.Add(dateCell16);
            cellsList.Add(dateCell17);
            cellsList.Add(dateCell18);
            cellsList.Add(dateCell19);
            cellsList.Add(dateCell20);
            cellsList.Add(dateCell21);
            cellsList.Add(dateCell22);
            cellsList.Add(dateCell23);
            cellsList.Add(dateCell24);
            cellsList.Add(dateCell25);
            cellsList.Add(dateCell26);
            cellsList.Add(dateCell27);
            cellsList.Add(dateCell28);
            cellsList.Add(dateCell29);
            cellsList.Add(dateCell30);
            cellsList.Add(dateCell31);
            cellsList.Add(dateCell32);
            cellsList.Add(dateCell33);
            cellsList.Add(dateCell34);
            cellsList.Add(dateCell35);
            cellsList.Add(dateCell36);
            cellsList.Add(dateCell37);
            cellsList.Add(dateCell38);
            cellsList.Add(dateCell39);
            cellsList.Add(dateCell40);
            cellsList.Add(dateCell41);
            cellsList.Add(dateCell42);

        }
        private void SelectDateClick(object sender, RoutedEventArgs e)
        {
            month.Content = monthBox.Text;
            year.Content = yearBox.Text;

            string monthString = month.Content.ToString();
            string yearString = year.Content.ToString();

            GenerateDates(monthString, yearString);

        }
        #endregion

        #region main
        public MainWindow()
        {
            InitializeComponent();

            FillMonthsList(monthsList);
            FillLabelsList(labelsList);
            FillCellsList(cellsList);

            foreach (string month in monthsList)
            {
                monthBox.Items.Add(month);
            }

            int minYear = 1930;
            int maxYear = 2050;

            IEnumerable<int> yearList = Enumerable.Range(minYear, maxYear - minYear + 1);

            foreach (int year in yearList)
            {
                yearBox.Items.Add(year);
            }

            DateTime currentDateTime = DateTime.Now;

            int currentMonthNumber = currentDateTime.Month;
            month.Content = monthsList[currentMonthNumber - 1];
            year.Content = currentDateTime.Year;

            monthBox.SelectedIndex = currentMonthNumber - 1;
            yearBox.SelectedIndex = yearBox.Items.IndexOf(currentDateTime.Year);

            month.Content = monthBox.Text;
            year.Content = yearBox.Text;

            string monthString = month.Content.ToString();
            string yearString = year.Content.ToString();

            GenerateDates(monthString, yearString);

        }
        #endregion
    }
}
