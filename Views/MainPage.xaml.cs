using MauiLearningApp.ViewModels;
using MauiLearningApp.Models;

namespace MauiLearningApp.Views
{
    public partial class MainPage : ContentPage
    {
        /*  MainPage Constructor:
                Normaly in a simple MVVM this entire class should be basically empty.
                But since this is new to me, and because MAUI is fairly new, i did have to create a few workarounds for my design.
                
                I opted to create my own Initialization process, so i can set some default values, to ensure the correct logic behavior.
                There are likely better ways to achieve the same goal, but again im just messing around trying to learn the basics.

                As the Framework and my skill-set grows, i might end up reworking some of this, but for now it seems to work as expected/desired.

                IsInit code block:
                    Here i set the main App states as defined in the MainPageModel, they all default to false.
                    Because i can't bind Toggled events, or attach Commands, i have to set them to there Definition in the MainPageViewModel.
                    The same goes for the Clicked events, though i could have opted to use Commands in this case.
                    And to finalize the process, i have to switch the IsInit state, otherwhise things would keep being fired during page navigation ?
        */
        public MainPage()
		{
			InitializeComponent();

            // Check the IsInit state, so we don't reset values when not expected.
            if (!MainPageModel.IsInit)
            {
                MainPageModel.IsCounting = false;
                MainPageModel.IsPaused = false;
                MainPageModel.IsReset = false;
                MainPageModel.IsTesting = false;
                MainPageModel.IsDebug = false;
                MainPageModel.IsSeconds = false;
                MainPageModel.IsMinutes = false;
                MainPageModel.IsHours = false;
                MainPageModel.IsDays = false;
                MainPageModel.IsMonths = false;
                MainPageModel.IsYears = false;

                TestingSwitch.Toggled += MainPageViewModel.TestingSwitch_Toggled;
                DebugSwitch.Toggled += MainPageViewModel.DebugSwitch_Toggled;
                SecondsSwitch.Toggled += MainPageViewModel.SecondsSwitch_Toggled;
                MinutesSwitch.Toggled += MainPageViewModel.MinutesSwitch_Toggled;
                HoursSwitch.Toggled += MainPageViewModel.HoursSwitch_Toggled;
                DaysSwitch.Toggled += MainPageViewModel.DaysSwitch_Toggled;
                MonthsSwitch.Toggled += MainPageViewModel.MonthsSwitch_Toggled;
                YearsSwitch.Toggled += MainPageViewModel.YearsSwitch_Toggled;

                ClockButton.Clicked += MainPageViewModel.OnClockButton_Clicked;
                CalenderButton.Clicked += MainPageViewModel.OnCalenderButton_Clicked;

                MainPageModel.IsInit = true;
            }
		}

        /*  Code: Reminder Snippets (To be removed later, needed a place to collect a few reminders)
                
                Print to console for debug reasons (can also be used in Tasks with await):
                    Debug.WriteLine(parameter);

                Change label text to x or y based on true of false variable evaluation:
                    Label.Text = Testing ? y : x;
         */
    }
}