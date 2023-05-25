/*  DateModel TODO List:
        - Review all code, and resolve any copy and paste issues, as this came from my previous project.
 */
using System.Runtime.CompilerServices;

namespace MauiLearningApp.Models
{
    public class DateModel
    {
        // The main date unit variables
        public int Days
        {
            get => _days;
            set => Set(_days, value);
        }

        public int WeekDays
        {
            get => _weekDays;
            set => Set(_weekDays, value);
        }

        public int Weeks
        {
            get => _weeks;
            set => Set(_weeks, value);
        }

        public int Months
        {
            get => _months;
            set => Set(_months, value);
        }

        public int Years
        {
            get => _years;
            set => Set(_years, value);
        }

        public int LeapYears
        {
            get => _leapYears;
            set => Set(_leapYears, value);
        }

        // Pointer variables for the above defined date units.
        private static int _days = 0;
        private static int _weekDays = 0;
        private static int _weeks = 0;
        private static int _months = 0;
        private static int _years = 0;
        private static int _leapYears = 0;

        // Unified set function to change/check the date units
        public static void Set(int oValue, int nValue, [CallerMemberName] string propertyName = null)
        {
            if (oValue != nValue)
            {
                if (propertyName == "Days")
                {
                    _days = nValue;
                }
                else if (propertyName == "WeekDays")
                {
                    _weekDays = nValue;
                }
                else if (propertyName == "Weeks")
                {
                    _weeks = nValue;
                }
                else if (propertyName == "Months")
                {
                    _months = nValue;
                }
                else if (propertyName == "Years")
                {
                    _years = nValue;
                }
                else if (propertyName == "LeapYears")
                {
                    _leapYears = nValue;
                }
                else
                {
                    return;
                }
            }
        }

        // Function to reset all main date units.
        public void ResetDate()
        {
            Days = 0;
            WeekDays = 0;
            Weeks = 0;
            Months = 0;
            Years = 0;
            LeapYears = 0;
        }
    }
}
