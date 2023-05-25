/*  ClockPageModel:
        This model is a bit more empty then i would have wanted, but i was unable to find a working solution for my MVVM design.
        For some reason i can not, without a Toolkit or other API, report back to the VM for say PropertyChanged Events.
        This is likely more related to a lack of experience with Xamarin or .NET, then a lack of proper documentation.
        If i ever get around to learning more about this type of programming, ill change how things work.
        For now the main logic will have to be inside the VM.
 */
namespace MauiLearningApp.Models
{
    public class ClockPageModel
    {
        // Private Property Pointer Variables:
        public string _timeLabelString { get; set; }
        public string _dateLabelString { get; set; }
        public string _startResumeText { get; set; }
        public string _pauseResetText { get; set; }

        // Navigation function for the VM Commands.
        public static async Task<Task> NavBackAsync()
        {
            await Shell.Current.GoToAsync("app://MauiLearningApp.Views/MainPage");
            return Task.CompletedTask;
        }

        public static async Task<Task> NavCalAsync()
        {
            await Shell.Current.GoToAsync("app://MauiLearningApp.Views/CalenderPage");
            return Task.CompletedTask;
        }

        // Leaving this here for testing purposes.
        public ClockPageModel() { }
    }
}
