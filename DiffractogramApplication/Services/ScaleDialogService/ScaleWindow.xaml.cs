using System.Windows;

namespace DiffractogramApplication.Services.ScaleDialogService
{
	// TODO: refactoring
	public partial class ScaleWindow : Window
	{
		public bool IsScaleWindowSuccessed { get; private set; }
		
		public double StartX { get; private set; }
		public double StartY { get; private set; }
		public double EndX { get; private set; }
		public double EndY { get; private set; }

		public ScaleWindow(string picturePath)
		{
			InitializeComponent();
			FillPredictedValues(picturePath);
		}

		private void FillPredictedValues(string picturePath)
		{
			var (startX, startY, endX, endY) = PythonService.PredictScale(picturePath);
			StartXStr.Text = startX.ToString();
			StartYStr.Text = startY.ToString();
			EndXStr.Text = endX.ToString();
			EndYStr.Text = endY.ToString();
		}

		private void CloseWindow(object sender, RoutedEventArgs e)
		{
			const string caption = "Input error";

			if (!double.TryParse(StartXStr.Text, out var startX) ||
			    !double.TryParse(StartYStr.Text, out var startY) ||
			    !double.TryParse(EndXStr.Text, out var endX) ||
			    !double.TryParse(EndYStr.Text, out var endY))
			{
				const string errorTextNotNumber = "One of the values is not a number. Would you like to try input again?";
				var result = ShowErrorWindow(errorTextNotNumber, caption);
				if (result != MessageBoxResult.No) return;
				IsScaleWindowSuccessed = false;
				Close();
				return;
			}

			if (startX >= endX)
			{
				const string errorTextXIncorrect = "Start value is bigger or equal end value. Would you like to try input again?";
				var result = ShowErrorWindow(errorTextXIncorrect, caption);
				if (result != MessageBoxResult.No) return;
				IsScaleWindowSuccessed = false;
				Close();
				return;
			}

			StartX = startX;
			StartY = startY;
			EndX = endX;
			EndY = endY;
			IsScaleWindowSuccessed = true;
			Close();
		}

		private static MessageBoxResult ShowErrorWindow(string errorText, string caption)
			=> MessageBox.Show(errorText, caption, MessageBoxButton.YesNo, MessageBoxImage.Error);
	}
}