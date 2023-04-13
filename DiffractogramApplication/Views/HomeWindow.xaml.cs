using System.Windows;
using DiffractogramApplication.Services.DialogService;
using DiffractogramApplication.ViewModels;
using DiffractogramApplication.Views.Interfaces;

namespace DiffractogramApplication.Views
{
	/// <summary>
	/// Interaction logic for HomeWindow.xaml
	/// </summary>
	public partial class HomeWindow : Window, IManageable
	{
		public IWindowMoving Move { get; }
		public HomeWindow()
		{
			Move = new Moving()
			{
				From = this,
				To = WindowRegistartion.UserPictureWindow
			};
			InitializeComponent();
			DataContext = new HomeViewModel(this, new DialogService());
		}
	}
}