using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringReplaceBenchmark
{
    public class FileReportFixture : IDisposable
    {
        public FileReportFixture()
        {
            this.Writer = new StreamWriter($"StringReplace_{DateTime.Now:yyyyMMddHHmmss}.txt");
        }

        public void Dispose()
        {
            this.Writer?.Dispose();
        }

        public StreamWriter Writer { get; }

    }
}
