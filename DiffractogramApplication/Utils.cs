using System;
using System.Windows.Media.Imaging;

namespace DiffractogramApplication
{
	public static class Utils
	{
		public const string ProjectFolder = @"C:\Users\Polina\RiderProjects\DiffractogramApplication\DiffractogramApplication";

		public static BitmapImage CreateBitmap(string filePath)
		{
			var bitmap = new BitmapImage();  
			bitmap.BeginInit();  
			bitmap.UriSource = new Uri(filePath);  
			bitmap.EndInit();
			return bitmap;
		}
	}
}
