using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DiffractogramApplication.Models;

namespace DiffractogramApplication.Services
{
	public static class PythonService
	{
		private static readonly string Scripts = @$"{Utils.ProjectFolder}\scripts";

		public static async Task DefinePoints(string filePath, Scale scale)
		{
			using var process = Process.Start(new ProcessStartInfo {
				FileName = "python",
				Arguments = $"{Scripts}\\getPoints.py {filePath} {scale}",
				UseShellExecute = false,
				CreateNoWindow = true,
				WindowStyle = ProcessWindowStyle.Hidden
			});
			await process?.WaitForExitAsync()!;
		}
		
		public static (double, double, double, double) PredictScale(string filePath)
		{
			using var process = Process.Start(new ProcessStartInfo {
				FileName = "python",
				Arguments = $"{Scripts}\\defScale.py {filePath}"
			});
			process.WaitForExit();

			var text = File.ReadAllText(@$"{Utils.ProjectFolder}\resources\scale.txt");
			var scale = text.Replace(".", ",")
				.Split(" ")
				.Select(double.Parse)
				.ToArray();
			return (scale[0], scale[1], scale[2], scale[3]);
		}
	}
}