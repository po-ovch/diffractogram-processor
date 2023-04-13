using System.Windows;
using DiffractogramApplication.Views.Interfaces;

namespace DiffractogramApplication.Views
{
	public partial class UserPictureWindow : Window, IManageable
	{
		public IWindowMoving Move { get; }
		public UserPictureWindow()
		{
			Move = new Moving()
			{
				From = this,
				To = WindowRegistartion.BothPicturesWindow
			};
			InitializeComponent();
		}
	}
}