using System;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace StringReplaceBenchmark
{
    [Collection(TestCollections.StringReplace)]
    public class StringBuilderReplaceBenchmark 
    {
        private readonly FileReportFixture fileReportFixture;

        public StringBuilderReplaceBenchmark(FileReportFixture fileReportFixture)
        {
            this.fileReportFixture = fileReportFixture;
        }

        [Theory]
        [MemberData("StringReplaceTestData", MemberType = typeof(TestData))]
        public void StringBuilderTheory(string prefix, string iterationPrefix, int iterations)
        {
            var pattern = StringReplaceBenchmark.BuildPattern(prefix, iterationPrefix, iterations);
            var replacements = StringReplaceBenchmark.BuildReplacements(iterations);

            var resultBuilder = new StringBuilder(pattern);

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < iterations; i++)
            {
                resultBuilder = resultBuilder.Replace($"@{i}", replacements[i]);
            }

            var result = resultBuilder.ToString();
            stopwatch.Stop();

            Assert.DoesNotContain("@", result);

            fileReportFixture.Writer.WriteLine($"StringBuilder.Replace;{iterations};{stopwatch.ElapsedMilliseconds};{stopwatch.ElapsedTicks}");
        }
    }
}
