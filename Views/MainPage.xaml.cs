namespace MauiLearningApp.Views
{
    public partial class MainPage : ContentPage
    {
        internal static bool IsInit { get; set; }                       // App state to indicate if the MainPage finished its initial configurations.
        internal static bool IsCounting { get; set; }                   // App state to indicate if the Counting process is active or not.
        internal static bool IsPaused { get; set; }                     // App state to indicate if the Counting process is paused or not.
        internal static bool IsReset { get; set; }                      // App state to indicate if the Counting process was reset during the IsPaused state.

        internal static bool IsTesting { get; set; }                    // App main config, to enable save to file testing.
        internal static bool IsDebug { get; set; }                      // App main config, to enable the Debug mode.
        internal static bool IsSeconds { get; set; }                    // App main config, to change the default 1ms delay to 1s.
        internal static bool IsMinutes { get; set; }                    // App main config, to move the delay to minutes instead of seconds.
        internal static bool IsHours { get; set; }                      // App main config, to move the delay to hours instead of seconds.
        internal static bool IsDays { get; set; }                       // App main config, to move the delay to days instead of seconds.
        internal static bool IsMonths { get; set; }                     // App main config, to move the delay to months instead of seconds.
        internal static bool IsYears { get; set; }                      // App main config, to move the delay to years instead seconds.

        public MainPage()
		{
			InitializeComponent();
		}

        // Testing state button.
        private void OnTestingClicked(object sender, EventArgs e)
        {
            // Change IsTesting state variable to "true" or "false" based on the current value.
            // Change button color to red or green based on the variable its state ?
        }

        // Debug state button.
        private void OnDebugClicked(object sender, EventArgs e)
        {
            // Change IsDebug state variable to "true" or "false" based on the current value.
            // Change button color to red or green based on the variable its state ?
        }

        // Seconds delay button.
        private void OnSecondsClicked(object sender, EventArgs e)
        {
            // Change IsSeconds state variable to "true" or "false" based on the current value.
            // Change button color to red or green based on the variable its state ?
        }

        // Minutes delay button.
        private void OnMinutesClicked(object sender, EventArgs e)
        {
            // Change IsMinutes state variable to "true" or "false" based on the current value.
            // Change button color to red or green based on the variable its state ?
        }

        // Hours delay button.
        private void OnHoursClicked(object sender, EventArgs e)
        {
            // Change IsHours state variable to "true" or "false" based on the current value.
            // Change button color to red or green based on the variable its state ?
        }

        // Days delay button.
        private void OnDaysClicked(object sender, EventArgs e)
        {
            // Change IsDays state variable to "true" or "false" based on the current value.
            // Change button color to red or green based on the variable its state ?
        }

        // Months delay button.
        private void OnMonthsClicked(object sender, EventArgs e)
        {
            // Change IsMonths state variable to "true" or "false" based on the current value.
            // Change button color to red or green based on the variable its state ?
        }

        // Years delay button.
        private void OnYearsClicked(object sender, EventArgs e)
        {
            // Change IsYears state variable to "true" or "false" based on the current value.
            // Change button color to red or green based on the variable its state ?
        }

        /* Page Navigation:
            Due to a lack of experience, and there for documentation that makes sense to me, i settled on Shell Navigation.
            This was easy to attach to a onclick Button event, and allows me to define where and how the buttons are displayed.
            There are various other ways to achieve the same end goal, but this seems to fit my simple design the best.
        
            OnClockClicked:
                The onclicked event for the ClockBtn.

            OnCalenderClicked:
                The onclicked event for the CalenderBtn.
         */
        private async void OnClockClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("app://MauiLearningApp.Views/ClockPage");
        }

        private async void OnCalenderClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("app://MauiLearningApp.Views/CalenderPage");
        }
    }
}