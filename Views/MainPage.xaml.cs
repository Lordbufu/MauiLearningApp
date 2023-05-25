using MauiLearningApp.ViewModels;

namespace MauiLearningApp.Views
{
    /*  MainPage:
            I wanted to take the most easy route, so i can learn things at my own speed.
            Also designs are not my strongest skill, so i do struggle to make things look nice in the UI.
            Somethings can likely be improved using a Toolkit, but i would rather avoid using that untill i grasp the basics a bit more.
     */
    public partial class MainPage : ContentPage
    {
        // The App Init state: Only used because i can't bind commands to switches via xaml.
        private static bool IsInit { get; set; } = false;

        // MainPage Constructor: Includes a basic initialization code block, to link a toggled event to the switches i used.
        public MainPage()
		{
			InitializeComponent();

            if (!IsInit)
            {
                TestingSwitch.Toggled += MainPageViewModel.Switch_Toggled;
                DebugSwitch.Toggled += MainPageViewModel.Switch_Toggled;
                SecondsSwitch.Toggled += MainPageViewModel.Switch_Toggled;
                MinutesSwitch.Toggled += MainPageViewModel.Switch_Toggled;
                HoursSwitch.Toggled += MainPageViewModel.Switch_Toggled;
                DaysSwitch.Toggled += MainPageViewModel.Switch_Toggled;
                MonthsSwitch.Toggled += MainPageViewModel.Switch_Toggled;
                YearsSwitch.Toggled += MainPageViewModel.Switch_Toggled;

                IsInit = true;
            }
		}

        /*  Reminder Code Snippets: (To be removed later, needed a place to collect a few reminders/learning reminders)
                
                To use functions from 'System.Diagnostics', and not cause conflicts with MAUI stuff, its best to use it like this:
                    System.Diagnostics.Debug.WriteLine("Test");
                
                Print to console for debug reasons (can also be used in Tasks with await):
                    Debug.WriteLine(parameter);

                Change label text to x or y based on true of false variable evaluation:
                    Label.Text = Testing ? y : x;

                Create a simple costum event, without using the build in EventArgs class:
                    Declare event:
                        public event Action<string> TestEvent;
                    Create handler (should work with [CallerMemberName] if required):
                        private void TestEventHandler(string propertyName) { }
                    Connect event to handler in the class constructor:
                        TestEvent += new Action<string>(TestEventHandler);
                    Unsub and/or clear all events:
                        TestEvent += TestEventHandler;
                        TestEvent = null;
         */
    }
}