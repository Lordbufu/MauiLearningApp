/*  TODO List:
        - Review if i need more functionality, like moving the Init code block inside the View itself.
        - Review the options for binding the Toggled Events, and see if i can still improve on that, or if i need more supported features.
        - Review if Commands are better for the OnClicked Button Events, it might be easier/cleaner to use becuase of Binding support.
 */
using MauiLearningApp.Models;

namespace MauiLearningApp.ViewModels
{
	public class MainPageViewModel : ContentView
	{
		// Bound Color Properties.
        internal static Color HeaderColor = Colors.DarkRed;
        internal static Color SwitchKnobColor = Colors.Green;
        internal static Color SwitchBackColor = Colors.LightSkyBlue;

        //  Settings Switch Toggles: Simply assign the ToggledEventArg value to the associated App state property.
        internal static void TestingSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            MainPageModel.IsTesting = e.Value;
        }

        internal static void DebugSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            MainPageModel.IsDebug = e.Value;
        }

        internal static void SecondsSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            MainPageModel.IsSeconds = e.Value;
        }

        internal static void MinutesSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            MainPageModel.IsMinutes = e.Value;
        }

        internal static void HoursSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            MainPageModel.IsHours = e.Value;
        }

        internal static void DaysSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            MainPageModel.IsDays = e.Value;
        }

        internal static void MonthsSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            MainPageModel.IsMonths = e.Value;
        }

        internal static void YearsSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            MainPageModel.IsYears = e.Value;
        }

        // Page Navigation: Due to a lack of experience, i settled on 'Shell Navigation', seem simple enough for the scope of this project.
        internal static async void OnClockButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("app://MauiLearningApp.Views/ClockPage");
        }

        internal static async void OnCalenderButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("app://MauiLearningApp.Views/CalenderPage");
        }
    }
}