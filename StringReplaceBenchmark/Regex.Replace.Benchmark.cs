using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Xunit;

namespace StringReplaceBenchmark
{
    [Collection(TestCollections.StringReplace)]
    public class RegexReplaceBenchmark
    {
        private readonly FileReportFixture fileReportFixture;

        public RegexReplaceBenchmark(FileReportFixture fileReportFixture)
        {
            this.fileReportFixture = fileReportFixture;
        }

        [Theory]
        [MemberData("StringReplaceTestData", MemberType = typeof(TestData))]
        public void RegexReplaceTheory(string prefix, string iterationPrefix, int iterations)
        {
            var pattern = StringReplaceBenchmark.BuildPattern(prefix, iterationPrefix, iterations);
            var replacements = StringReplaceBenchmark.BuildReplacements(iterations);

            var regex = new Regex(@"@(\d+)");

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var result = regex.Replace(pattern, (match) => replacements[Convert.ToInt32(match.Groups[1].Value)]);

            stopwatch.Stop();

            Assert.DoesNotContain("@", result);

            fileReportFixture.Writer.WriteLine($"Regex.Replace;{iterations};{stopwatch.ElapsedMilliseconds};{stopwatch.ElapsedTicks}");
        }
    }
}
