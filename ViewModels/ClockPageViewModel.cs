using MauiLearningApp.Views;
using MauiLearningApp.Models;
using System.ComponentModel;
using System.Windows.Input;

namespace MauiLearningApp.ViewModels
{
    public class ClockPageViewModel : ContentPage
    {
        // Class object for the load/save model
        //private LoadSaveModel _loadSaveModel = new("DefaultTime.csv", "DefaultDate.csv");
        private static LoadSaveModel _loadSaveModel = new("DefaultTime.csv", "DefaultDate.csv");

        // Class object for the time model:
        private static TimeModel _timeModel = new()
        {
            Seconds = LoadSaveModel.GetResult("time", "seconds"),
            Minutes = LoadSaveModel.GetResult("time", "minutes"),
            Hours = LoadSaveModel.GetResult("time", "hours")
        };

        // Class object for the date model:
        private static DateModel _dateModel = new()
        {
            Days = LoadSaveModel.GetResult("date", "days"),
            WeekDays = LoadSaveModel.GetResult("date", "weekDays"),
            Weeks = LoadSaveModel.GetResult("date", "weeks"),
            Months = LoadSaveModel.GetResult("date", "months"),
            Years = LoadSaveModel.GetResult("date", "years"),
            LeapYears = LoadSaveModel.GetResult("date", "leapYears")
        };

        // Class object for the page model:
        private static ClockPageModel _clockPageModel = new()
        {
            _timeLabelString = $"Time: {_timeModel.Hours:00}:{_timeModel.Minutes:00}:{_timeModel.Seconds:00}",     // Use the TimeModel to load default values.
            _dateLabelString = $"Date: {_dateModel.Days:00}:{_dateModel.Months:00}:{_dateModel.Years:0000}",       // Use the DateModel to load default values.
            _startResumeText = "Start",
            _pauseResetText = "Pause"
        };

        // Bound Time Label Text, redirecting to the page model:
        public string TimeLabelText
        {
            get
            {
                return _clockPageModel._timeLabelString;                         // Return property from page model.
            }
            set
            {
                _clockPageModel._timeLabelString = value;                        // Set property in page model (value checks in the model).
                OnPropertyChanged(nameof(TimeLabelText));
            }
        }

        public string DateLabelText
        {
            get
            {
                return _clockPageModel._dateLabelString;
            }
            set
            {
                _clockPageModel._dateLabelString = value;
                OnPropertyChanged(nameof(DateLabelText));
            }
        }

        // Bound Button Text:
        public string StartResumeButtText
        {
            get
            {
                return _clockPageModel._startResumeText;
            }
            set
            {
                _clockPageModel._startResumeText = value;
                OnPropertyChanged(nameof(StartResumeButtText));
            }
        }

        public string PauseResetButtText
        {
            get
            {
                return _clockPageModel._pauseResetText;
            }
            set
            {
                _clockPageModel._pauseResetText = value;
                OnPropertyChanged(nameof(PauseResetButtText));
            }
        }

        // Bound Button Commands:
        public ICommand StartResumeButtCom
        {
            get
            {
                return new Command(StartResume);
            }
        }

        public ICommand PauseResetButtCom
        {
            get
            {
                return new Command(PauseReset);
            }
        }

        public ICommand NavBackButtonCom
        {
            get => new Command(
                async () => await ClockPageModel.NavBackAsync()
            );
        }

        public ICommand NavCalButtonCom
        {
            get => new Command(
                async () => await ClockPageModel.NavCalAsync()
            );
        }

        // Leaving it empty, because i have a feeling im still going to need it.
        public ClockPageViewModel() { }

        // Potentially Obsolete.
        public void TriggerPropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName);
        }

        // Testing functions to see if it all works as expected.
        private void StartResume()
        {
            _timeModel.Seconds = 10;
            TimeLabelText = $"Time: {_timeModel.Hours:00}:{_timeModel.Minutes:00}:{_timeModel.Seconds:00}";
        }

        private void PauseReset() { }
    }
}