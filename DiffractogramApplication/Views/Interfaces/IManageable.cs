namespace DiffractogramApplication.Views.Interfaces
{
	public interface IManageable
	{
		void Close();
		void Show();
		object DataContext { set; }
	}
}