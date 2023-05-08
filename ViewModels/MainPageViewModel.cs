using MauiLearningApp.Models;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MauiLearningApp.ViewModels
{
    /*  MainPageViewModel:
            I'm fairly happy with how this turned out, considering my lack of knowledge on this type of programming.

            For example, the ICommands are not as readable as i would have liked, even though its all very descriptive.
            I feels like to much clutter, for something that should have been one line of code imho.

            And then there is the 'Switch_Toggled' event, it works and is nicely unified.
            But i can't quite seem to grasp, why i have basically use a workaround, to access the inherited data i want to use.

            The GetText functions, could be improved with my LoadSaveModel, so i can load the text from a file instead.
            And i might end up working on that later, but it does do what i wanted it, so it's not really required either.
     */
    public class MainPageViewModel : ContentView
    {
        // Bound Color Properties: The most basic property binding, that i could get to work as i intended.
        public Color HeaderColor
        {
            get => Colors.DarkRed;
        }

        public Color SwitchKnobColor
        {
            get => Colors.Green;
        }

        public Color SwitchBackColor
        {
            get => Colors.LightSkyBlue;
        }

        // Bound Text Properties: A slightly more complex setup, to display some welcome and explanation text.
        public string WelcomeText
        {
            get => GetWelcomeText();
        }
        public string ExplanationText_1
        {
            get => GetExplanationText();
        }
        public string ExplanationText_2
        {
            get => GetExplanationText();
        }
        public string ExplanationText_3
        {
            get => GetExplanationText();
        }
        public string ExplanationText_4
        {
            get => GetExplanationText();
        }

        // Bound ICommands: Use Shell Navigation to navigate pages, don't need to make things overly complex.
        public ICommand ClockButtonCom
        {
            get => new Command(
                execute: async () =>
                {
                    await Shell.Current.GoToAsync("app://MauiLearningApp.Views/ClockPage");
                });
        }

        public ICommand CalenderButtonCom
        {
            get => new Command(
                execute: async () =>
                {
                    await Shell.Current.GoToAsync("app://MauiLearningApp.Views/CalenderPage");
                });
        }

        /*  Switch Toggles:
                The concept itself is rather simple, each switch has a 'x:Name' defined in xaml.
                Each time a switch is Toggled, i want to set the new 'Value' to the associated App State Variable, and seem to be retained when navigating.
                The 'x:Name' is stored as 'StyleId' in the 'Element' class, but can't be directly accessed via the 'sender' object.

                First i set the 'sender' object as the 'Switch' class to a new 'obj' variable ? (other solutions use some kind of type casting)
                Then i can access the 'StyleId', and evaluate that in a switch statement using the 'StyleId'.
                The new 'IsToggled' value is passed along via the 'ToggledEventArgs', making it easy to assign that to the variable i want.
                
                The 'Microsoft.Maui.Controls.Switch' conflicts with 'System.Diagnostics.Switch', a thing to keep in mind when using 'System.Diagnostics'.
                The debug code i used, was left in intentionally, incase i want to further research and try things with this concept.
         */
        internal static void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            var obj = sender as Switch;

            switch (obj.StyleId)
            {
                case "TestingSwitch":
                    MainPageModel.IsTesting = e.Value;
                    //System.Diagnostics.Debug.WriteLine(sender);
                    //System.Diagnostics.Debug.WriteLine(e);
                    //System.Diagnostics.Debug.WriteLine(obj.StyleId);
                    //System.Diagnostics.Debug.WriteLine(e.Value);
                    break;
                case "DebugSwitch":
                    MainPageModel.IsDebug = e.Value;
                    break;
                case "SecondsSwitch":
                    MainPageModel.IsSeconds = e.Value;
                    break;
                case "MinutesSwitch":
                    MainPageModel.IsMinutes = e.Value;
                    break;
                case "HoursSwitch":
                    MainPageModel.IsHours = e.Value;
                    break;
                case "DaysSwitch":
                    MainPageModel.IsDays = e.Value;
                    break;
                case "MonthsSwitch":
                    MainPageModel.IsMonths = e.Value;
                    break;
                case "YearsSwitch":
                    MainPageModel.IsYears = e.Value;
                    break;
            }
        }

        // Get WelcomeText Function: Simple return string, no need to complicate things.
        private string GetWelcomeText()
        {
            return "Welcome to my .NET MAUI App, intended to learn a bit of C# & Maui, counting time without using timers or internal time/date.";
        }

        // Get ExplanationText Function: Return string based on the Caller, return failed text if not resolved.
        private string GetExplanationText([CallerMemberName] string property = null)
        {
            var String_1 = "The App Setting might seem a bit confusing, but are fairly straight forward, and you can mix and match some of them.";
            var String_2 = "Main App Setting are intended to enable some main features, like saving to file to a very odd location, and allowing other then default delay settings.";
            var String_3 = "App Delay Settings are intended to edit delay settings, a 1ms delay can be combined with Move to Days, making each day last 1ms.";
            var String_4 = "Meaning you can pick both Main Settings, and then either move the delay, or shorten the delay and move it.";
            var Failed = "Something went wrong, and the Text was lost in the void.";

            if (property == "ExplanationText_1")
            {
                return String_1;
            }
            else if (property == "ExplanationText_2")
            {
                return String_2;
            }
            else if (property == "ExplanationText_3")
            {
                return String_3;
            }
            else if (property == "ExplanationText_4")
            {
                return String_4;
            }
            else
            {
                return Failed;
            }
        }
    }
}