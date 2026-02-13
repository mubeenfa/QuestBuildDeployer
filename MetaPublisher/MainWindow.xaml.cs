using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MetaPublisher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // IMPORTANT: Change this to where your CLI is located
        //private string cliPath = @"C:\Users\Lenovo\Downloads\Programs\ovr-platform-util.exe";
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void APK_Browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "APK Files (*.apk)|*.apk";
            dialog.Title = "Select APK File";

            if (dialog.ShowDialog() == true)
            {
                ApkPathBox.Text = dialog.FileName;
            }
        }

        private void CLI_Browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Executable Files (*.exe)|*.exe";
            dialog.Title = "Select OVR CLI";

            if (dialog.ShowDialog() == true)
            {
                OVRPathBox.Text = dialog.FileName;
            }
        }

        private async void Deploy_Click(object sender, RoutedEventArgs e)
        {
            string appId = AppIdBox.Text.Trim();
            string appSecret = AppSecretBox.Text.Trim();
            string apkPath = ApkPathBox.Text.Trim();
            string cliPath = OVRPathBox.Text.Trim();
            string channel = (ChannelBox.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content.ToString();

            if (!File.Exists(cliPath))
            {
                Log("CLI not found at: " + cliPath);
                return;
            }

            if (!File.Exists(apkPath))
            {
                Log("APK file not found.");
                return;
            }

            if (string.IsNullOrWhiteSpace(appId) || string.IsNullOrWhiteSpace(appSecret) || string.IsNullOrWhiteSpace(channel))
            {
                Log("Please fill all fields.");
                return;
            }

            string arguments =
                $"upload-quest-build --app-id {appId} --app-secret {appSecret} --apk \"{apkPath}\" --channel {channel} --draft true";

            await RunProcess(cliPath, arguments);
        }

        private async Task RunProcess(string fileName, string arguments)
        {
            Log("Starting upload...");
            Log(arguments);

            Process process = new Process();
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;

            process.OutputDataReceived += (s, e) =>
            {
                if (e.Data != null)
                    Dispatcher.Invoke(() => Log(e.Data));
            };

            process.ErrorDataReceived += (s, e) =>
            {
                if (e.Data != null)
                    Dispatcher.Invoke(() => Log("ERROR: " + e.Data));
            };

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            await process.WaitForExitAsync();

            Log("Finished with exit code: " + process.ExitCode);
        }

        private void Log(string message)
        {
            LogBox.AppendText(message + Environment.NewLine);
            LogBox.ScrollToEnd();
        }
    }
}