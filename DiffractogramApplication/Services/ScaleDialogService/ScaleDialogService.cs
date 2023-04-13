using DiffractogramApplication.Models;

namespace DiffractogramApplication.Services.ScaleDialogService
{
	public class ScaleDialogService : IScaleDialogService
	{
		public Scale Scale { get; private set; }

		public bool OpenDialog(string picturePath)
		{
			var scaleWindow = new ScaleWindow(picturePath);
			scaleWindow.ShowDialog();
			if (!scaleWindow.IsScaleWindowSuccessed) return false;

			Scale = new Scale(scaleWindow.StartX, scaleWindow.StartY, 
				scaleWindow.EndX, scaleWindow.EndY);
			return true;
		}
 
		
	}
}