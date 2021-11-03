using AsyncWpfDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void executeSync_Click(object sender, RoutedEventArgs e)
        {
            ReportProgress("executeSync_Click...");
            resultsWindow.Text = "";
            var watch = System.Diagnostics.Stopwatch.StartNew();

            RunDownloadSync();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            resultsWindow.Text += $"Total execution time: { elapsedMs }";
        }

        private async void executeASync_Click(object sender, RoutedEventArgs e)
        {
            ReportProgress("executeASync_Click...");
            resultsWindow.Text = "";
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // await RunDownloadAsync();
            await RunDownloadParallelAsync();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            resultsWindow.Text += $"Total execution time: { elapsedMs } ms";
        }

        private List<string> PrepData()
        {
            ReportProgress("PrepData...");
            List<string> output = new List<string>();
            resultsWindow.Text = "";

            output.Add("https://www.yahoo.com");
            output.Add("https://www.google.com");
            output.Add("https://www.microsoft.com");
            output.Add("https://www.cnn.com");
            output.Add("https://www.codeproject.com");
            output.Add("https://www.stackoverflow.com");

            return output;
        }

        private async Task RunDownloadAsync()
        {
            ReportProgress("RunDownloadAsync...");
            List<string> websites = PrepData();

            foreach (string site in websites)
            {
                WebsiteDataModel results = await Task.Run(() => DownloadWebsite(site));
                ReportWebSiteInfo(results);
            }
        }

        private async Task RunDownloadParallelAsync()
        {
            ReportProgress("RunDownloadAsync...");
            List<string> websites = PrepData();
            List<Task<WebsiteDataModel>> tasks = new List<Task<WebsiteDataModel>>();

            foreach (string site in websites)
            {
                //tasks.Add(Task.Run(() => DownloadWebsite(site)));
                tasks.Add(DownloadWebsiteAsync(site));
            }

            var results = await Task.WhenAll(tasks);

            foreach (var item in results)
            {
                ReportWebSiteInfo(item);
            }
        }

        private void RunDownloadSync()
        {
            ReportProgress("RunDownloadSync...");
            List<string> websites = PrepData();

            foreach (string site in websites)
            {
                WebsiteDataModel results = DownloadWebsite(site);
                ReportWebSiteInfo(results);
            }
        }

        private WebsiteDataModel DownloadWebsite(string websiteURL)
        {
            ReportProgress("DownloadWebsite " + websiteURL + "...");
            WebsiteDataModel output = new WebsiteDataModel();
            WebClient client = new WebClient();

            output.WebsiteUrl = websiteURL;
            output.WebsiteData = client.DownloadString(websiteURL);  // Not used here: DownloadStringTaskAsync

            return output;
        }

        private async Task<WebsiteDataModel> DownloadWebsiteAsync(string websiteURL)
        {
            ReportProgress("DownloadWebsite " + websiteURL + "...");
            WebsiteDataModel output = new WebsiteDataModel();
            WebClient client = new WebClient();

            output.WebsiteUrl = websiteURL;
            output.WebsiteData = await client.DownloadStringTaskAsync(websiteURL);  // Used here: DownloadStringTaskAsync

            return output;
        }

        private void ReportWebSiteInfo(WebsiteDataModel data)
        {
            ReportProgress("ReportWebSiteInfo...");
            resultsWindow.Text += $"{ data.WebsiteUrl } downloaded: { data.WebsiteData.Length } characters long. { Environment.NewLine }";
        }

        object lockObject = new Object();

        private void ReportProgress(string text)
        {
            // progressWindow.Text = text;
            lock (lockObject) {
                progressWindow.Text = text;
            }
        }
    }
}
