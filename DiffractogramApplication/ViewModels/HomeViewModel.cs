using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.Input;
using DiffractogramApplication.Services.DialogService;
using DiffractogramApplication.Services.FileDialogService;
using DiffractogramApplication.Services.ScaleDialogService;
using DiffractogramApplication.Views.Interfaces;

namespace DiffractogramApplication.ViewModels
{
	public class HomeViewModel : INotifyPropertyChanged
	{
		private IDialogService _dialogService;
		public RelayCommand<IWindowMoving> OpenPictureCommand { get; }

		public HomeViewModel(IManageable window, IDialogService dialogService)
		{
			_dialogService = dialogService;
			OpenPictureCommand = new RelayCommand<IWindowMoving>(OpenPicture);
			
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		public virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private void OpenPicture(IWindowMoving moving)
		{
			const string filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.JPEG;*.PNG";
			if (!_dialogService.OpenFileDialog(filter)) return;
			
			moving.To.DataContext = new UserPictureViewModel(new ScaleDialogService(), _dialogService.FilePath);
			moving.To.Show();
			moving.From.Close();
		}
	}
}