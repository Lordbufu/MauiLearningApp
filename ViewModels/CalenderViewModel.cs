namespace MauiLearningApp.ViewModels
{
    // More Stuff goes here ... eventually ... perhaps ... maybe ...
    public class CalenderViewModel : ContentView
	{
		public CalenderViewModel()
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