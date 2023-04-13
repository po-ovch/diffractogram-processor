namespace DiffractogramApplication.Views.Interfaces
{
	public class Moving : IWindowMoving
	{
		public IManageable From { get; set; }
		public IManageable To { get; set; }
	}
}