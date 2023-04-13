using DiffractogramApplication.Models;

namespace DiffractogramApplication.Services.ScaleDialogService
{
	public interface IScaleDialogService
	{
		Scale Scale { get; }
		bool OpenDialog(string picturePath);
	}
}