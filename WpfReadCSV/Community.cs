using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfReadCSV
{
   public class Community
    {
        // Gemeindekennziffer;Gemeindename;Ortschaftkennziffer;Ortschaftsname;Postleitzahl
        public int Gemeindekennziffer { get; set; }
        public string Gemeindename { get; set; }
        public string Ortschaftkennziffer { get; set; }
        public string Ortschaftsname { get; set; }
        public string Postleitzahl { get; set; }

    }
}
