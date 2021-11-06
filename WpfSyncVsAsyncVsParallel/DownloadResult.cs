using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSyncVsAsyncVsParallel
{
    class DownloadResult
    {
        public string Url { get; set; }
        public string Html { get; set; }
        public int ContentLength => Html?.Length ?? 0;
    }
}
