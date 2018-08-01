using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AssemblyRebuilder {
	internal static class Program {
		[STAThread]
		private static void Main(string[] args) {
			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			if (args != null && args.Length == 1 && !string.IsNullOrEmpty(args[0]) && File.Exists(args[0]))
				Application.Run(new MainForm(args[0]));
			else
				Application.Run(new MainForm());
		}

		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) => MessageBox.Show(((Exception)e.ExceptionObject).GetRealException().ToFullString());

		/// <summary>
		/// 获取最内层异常
		/// </summary>
		/// <param name="exception"></param>
		/// <returns></returns>
		private static Exception GetRealException(this Exception exception) => exception.InnerException == null ? exception : GetRealException(exception.InnerException);

		/// <summary>
		/// 返回一个字符串，其中包含异常的所有信息。
		/// </summary>
		/// <param name="exception"></param>
		/// <returns></returns>
		private static string ToFullString(this Exception exception) {
			StringBuilder stringBuilder;

			stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Type: " + Environment.NewLine + exception.GetType().FullName);
			stringBuilder.AppendLine("Message: " + Environment.NewLine + exception.Message);
			stringBuilder.AppendLine("Source: " + Environment.NewLine + exception.Source);
			stringBuilder.AppendLine("StackTrace: " + Environment.NewLine + exception.StackTrace);
			stringBuilder.AppendLine("TargetSite: " + Environment.NewLine + exception.TargetSite.ToString());
			return stringBuilder.ToString();
		}
	}
}
