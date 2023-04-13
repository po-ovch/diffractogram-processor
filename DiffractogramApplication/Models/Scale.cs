namespace DiffractogramApplication.Models
{
	public record Scale(double StartX, double StartY, double EndX, double EndY)
	{
		public override string ToString()
		{
			return $"{StartX} {StartY} {EndX} {EndY}".Replace(",", ".");
		}
	}
}