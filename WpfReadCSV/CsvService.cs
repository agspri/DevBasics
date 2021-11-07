using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfReadCSV
{
    class CsvService : IDisposable
    {
        //System.IO.TextReader reader;
        TextReader reader;
        CsvHelper.CsvReader csvReader;

        public CsvService(string filename)
        {
            this.reader = new StreamReader(filename);
            CsvConfiguration config = new CsvConfiguration(CultureInfo.CurrentCulture);
            config.Delimiter = ",";
            config.HasHeaderRecord = false;
           csvReader = new CsvHelper.CsvReader(reader, config);
        }

        public void Dispose()
        {
            this.reader.Dispose();
            this.csvReader.Dispose();
        }

        public IAsyncEnumerable<Community> ReadCSV()
        {
            var communities = csvReader.GetRecordsAsync<Community>();
            //System.Threading.Thread.Sleep(1000);
            return communities;
        }

        // string filename;

     
      
    }
}
