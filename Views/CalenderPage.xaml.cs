namespace MauiLearningApp.Views
{
    public partial class CalenderPage : ContentPage
    {
        public CalenderPage()
        {
            InitializeComponent();
        }

        // Temp solution for navigating back to the main page.
        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("app://MauiLearningApp.Views/MainPage");
        }
    }
}