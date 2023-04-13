using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.Input;
using DiffractogramApplication.Services;
using DiffractogramApplication.Services.ScaleDialogService;
using DiffractogramApplication.Views.Interfaces;

namespace DiffractogramApplication.ViewModels
{
	public class UserPictureViewModel : INotifyPropertyChanged
	{
		private IScaleDialogService _scaleService;
		public AsyncRelayCommand<IWindowMoving> GetPointsCommand { get; }

		private string _picturePath;
		private BitmapImage _bitmapImage;

		public BitmapImage Bitmap
		{
			get
			{
				return _bitmapImage;
			}
			init
			{
				_bitmapImage = value;
				OnPropertyChanged();
			}
		}

		private Visibility _isLoading;
		public Visibility IsLoading
		{
			get
			{
				return _isLoading;
			}
			set
			{
				_isLoading = value;
				OnPropertyChanged();
			}
		}

		public UserPictureViewModel(IScaleDialogService scaleDialogService, string picturePath)
		{
			// TODO: path to model?
			_picturePath = picturePath;
			_scaleService = scaleDialogService;
			Bitmap = Utils.CreateBitmap(picturePath);
			IsLoading = Visibility.Hidden;
			GetPointsCommand = new AsyncRelayCommand<IWindowMoving>(GetPoints);
		}

		private async Task GetPoints(IWindowMoving moving)
		{
			if (!_scaleService.OpenDialog(_picturePath)) return;
			
			IsLoading = Visibility.Visible;
			await PythonService.DefinePoints(_picturePath, _scaleService.Scale);
			IsLoading = Visibility.Hidden;
			
			moving.From.Close();
			moving.To.DataContext = new BothPicturesViewModel(_picturePath);
			moving.To.Show();
		}
		
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}