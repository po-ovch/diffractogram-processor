namespace DiffractogramApplication.Services.FileDialogService
{
	public interface IDialogService
	{
		void ShowMessage(string message);
		string FilePath { get; }
		bool OpenFileDialog(string filter);
		bool SaveFileDialog();
	}
}