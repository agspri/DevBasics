using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;

namespace WpfSyncVsAsyncVsParallel
{
    class MainWindowViewModel : NotifyableBaseObject
    {
        string[] urls = new string[]
        {
            "https://www.stackoverflow.com",
            "https://docs.microsoft.com",
            "https://www.youtube.com",
            "https://www.asp.net",
            "https://www.yahoo.com",
            "https://www.bing.com"
        };

        public MainWindowViewModel()
        {
            this.DownloadCmd = new DelegateCommand((o) => Download());
            this.DownloadAsyncCmd = new DelegateCommand((o) => DownloadAsync());
            this.DownloadParallelAsyncCmd = new DelegateCommand((o) => DownloadParallelAsync());
        }


        private string _infoText;

        public string InfoText
        {
            get { return _infoText; }
            set
            {
                if (_infoText != value)
                {
                    _infoText = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        public DelegateCommand DownloadCmd { get; private set; }
        public DelegateCommand DownloadAsyncCmd { get; private set; }
        public DelegateCommand DownloadParallelAsyncCmd { get; private set; }

        void Download()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<DownloadResult> results = new List<DownloadResult>(urls.Length);

            foreach (string url in urls)
            {
                // results.Add(DownloadUrlV1(url));       // V1
                results.Add(DownloadUrlV2(url).Result);   // V2
                ShowResults(results);
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            InfoText += $"Total Execution Time: {elapsedMs} ms";
        }

        private void ShowResults(List<DownloadResult> results)
        {
            StringBuilder text = new StringBuilder();
            foreach (var result in results)
            {
                text.Append(result.Url);
                text.Append('\t');
                text.Append(result.ContentLength);
                text.Append(Environment.NewLine);
            }

            this.InfoText = text.ToString();
        }

        async Task DownloadAsync()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<DownloadResult> results = new List<DownloadResult>(urls.Length);

            foreach (string url in urls)
            {
                // results.Add(await Task.Run(() => DownloadUrlV1(url)));     // V1
                results.Add(await DownloadUrlV2(url));     // V2
                ShowResults(results);
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            InfoText += $"Total Execution Time: {elapsedMs} ms";
        }

        async Task DownloadParallelAsync()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            ////List<DownloadResult> results = new List<DownloadResult>(urls.Length);
            List<Task<DownloadResult>> taskList = new List<Task<DownloadResult>>(urls.Length);

            foreach (string url in urls)
            {
                // taskList.Add(Task.Run(() => DownloadUrlV1(url)));     // V1
                taskList.Add(DownloadUrlV2(url));     // V2
            }

            var results = await Task.WhenAll(taskList);

            ////foreach(var task in taskList) {}

            ShowResults(results.ToList());
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            InfoText += $"Total Execution Time: {elapsedMs} ms";
        }

        DownloadResult DownloadUrlV1(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                string html = client.GetStringAsync(url).Result;
                return new DownloadResult() { Url = url, Html = html };
            }
        }

        async Task<DownloadResult> DownloadUrlV2(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                string html = await client.GetStringAsync(url);
                return new DownloadResult() { Url = url, Html = html };
            }
        }
    }
}
