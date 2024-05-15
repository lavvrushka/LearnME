using System;
using System.Collections.ObjectModel;
using LearnMe.Models;


namespace LearnMe.CustomControls
{
    public partial class HorizontalCalendar : StackLayout
    {
        public ObservableCollection<AchievementsDatePicker> Dates { get; set; } = new ObservableCollection<AchievementsDatePicker>();

        public HorizontalCalendar()
        {
            InitializeComponent();
            BindDates(DateTime.Now);
        }

        private void BindDates(DateTime selectedDate)
        {
            DateTime today = DateTime.Today;
            int daysCount = DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month);

            for (int day = 1; day <= daysCount; day++)
            {
                DateTime date = new DateTime(selectedDate.Year, selectedDate.Month, day);

                
                if (date >= today)
                {
                    Dates.Add(new AchievementsDatePicker { Date = date, IsToday = date == today });
                }
            }
        }
    }
}
