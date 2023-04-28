namespace MauiLearningApp.ViewModels
{
    // More Stuff goes here ... eventually ... perhaps ... maybe ...
    public class ClockPageViewModel : ContentView
	{
		public ClockPageViewModel()
		{
			Content = new VerticalStackLayout
			{
				Children =
				{
					new Label
					{
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center,
						Text = "Welcome to .NET MAUI!"
					}
				}
			};
		}
	}
}