using System;
using System.Windows;
using DiffractogramApplication.Services.FileDialogService;
using Microsoft.Win32;

namespace DiffractogramApplication.Services.DialogService
{
	public class DialogService : IDialogService
	{
		public string FilePath { get; set; }
 
		public bool OpenFileDialog(string? filter)
		{
			var openFileDialog = new OpenFileDialog
			{
				Filter = filter ?? string.Empty
			};

			if (openFileDialog.ShowDialog() != true) return false;
			FilePath = openFileDialog.FileName;
			return true;
		}
 
		public bool SaveFileDialog()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if (saveFileDialog.ShowDialog() == true)
			{
				FilePath = saveFileDialog.FileName;
				return true;
			}
			return false;
		}
 
		public void ShowMessage(string message)
		{
			MessageBox.Show(message);
		}
	}
}