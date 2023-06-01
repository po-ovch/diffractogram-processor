using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DiffractogramApplication.Models;

namespace DiffractogramApplication.Services
{
	public static class PythonService
	{
		public static async Task DefinePoints(string filePath, Scale scale)
		{
			var directory = new DirectoryInfo(Directory.GetCurrentDirectory());

			using var process = Process.Start(new ProcessStartInfo {
				FileName = "python",
				Arguments = @$"{directory.FullName}\{Utils.ScriptsFolder}\getPoints.py {filePath} {scale}",
				UseShellExecute = false,
				CreateNoWindow = true,
				WindowStyle = ProcessWindowStyle.Hidden
			});
			await process?.WaitForExitAsync()!;
		}
	}
}