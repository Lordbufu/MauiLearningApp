/*  TimeModel TODO List:
        - Review all code, and resolve any copy and paste issues, as this came from my previous project.
 */
using System.Runtime.CompilerServices;

namespace MauiLearningApp.Models
{
    public class TimeModel
    {
        // Declare the time units, static so they are shared between instances.
        public int Seconds
        {
            get => _seconds;
            set => Set(_seconds, value);
        }

        public int Minutes
        {
            get => _minutes;
            set => Set(_minutes, value);
        }

        public int Hours
        {
            get => _hours;
            set => Set(_hours, value);
        }

        // Pointer variables to assist the above defined properties.
        private static int _seconds = 0;
        private static int _minutes = 0;
        private static int _hours = 0;

        // A unified Set function, for the time units 
        private static void Set(int oValue, int nValue, [CallerMemberName] string propertyName = null) {
            if (oValue != nValue)
            {
                if (propertyName == "Seconds")
                {
                    _seconds = nValue;
                }
                else if (propertyName == "Minutes")
                {
                    _minutes = nValue;
                }
                else if (propertyName == "Hours")
                {
                    _hours = nValue;
                }
                else
                {
                    return;
                }
            }
        }

        // And to reduce code clutter, i also need a reset function.
        public void ResetTime()
        {
            Seconds = 0;
            Minutes = 0;
            Hours = 0;
        }
    }
}