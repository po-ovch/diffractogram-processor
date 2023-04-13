using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.Input;
using DiffractogramApplication.Models;
using Microsoft.Win32;

namespace DiffractogramApplication.ViewModels
{
	public class BothPicturesViewModel : INotifyPropertyChanged
	{
		private BitmapImage _inputBitmapImage;
		private BitmapImage _processedBbitmapImage;
		private List<Point> _points;

		public BitmapImage InputBitmap
		{
			get
			{
				return _inputBitmapImage;
			}
			init
			{
				_inputBitmapImage = value;
				OnPropertyChanged();
			}
		}
		
		public BitmapImage ProcessedBitmap
		{
			get
			{
				return _processedBbitmapImage;
			}
			init
			{
				_processedBbitmapImage = value;
				OnPropertyChanged();
			}
		}

		public List<Point> Points
		{
			get
			{
				return _points;
			}
			set
			{
				OnPropertyChanged();
				_points = value;
			}
		}
		
		public RelayCommand SavePointsCommand { get; }
		
		public BothPicturesViewModel(string picturePath)
		{
			InputBitmap = Utils.CreateBitmap(picturePath);
			ProcessedBitmap = Utils.CreateBitmap(@$"{Utils.ProjectFolder}/resources/graphic.png");
			SavePointsCommand = new RelayCommand(SavePoints);
			Points = ReadPoints();
		}

		private List<Point> ReadPoints()
		{
			var allLines = File.ReadAllLines(@$"{Utils.ProjectFolder}/resources/points.txt");

			return allLines.Select(line => line.Replace(".", ",").Split(" "))
				.Select(splitted => new Point()
				{
					X = double.Parse(splitted[0]),
					Y = double.Parse(splitted[1])
				})
				.ToList();
		}
		
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}

		private void SavePoints()
		{
			var fileDialog = new SaveFileDialog();
			fileDialog.Filter = "Text file(*.TXT)|*.txt";
			if (fileDialog.ShowDialog() != true) return;

			var text = File.ReadAllText(@$"{Utils.ProjectFolder}/resources/points.txt");
			var filePath = fileDialog.FileName;
			File.WriteAllText(filePath, text);
		}
	}
}