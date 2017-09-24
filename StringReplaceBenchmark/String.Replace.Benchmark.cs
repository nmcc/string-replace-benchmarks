using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace StringReplaceBenchmark
{
    [Collection(TestCollections.StringReplace)]
    public class StringReplaceBenchmark
    {
        private readonly FileReportFixture fileReportFixture;

        public StringReplaceBenchmark(FileReportFixture fileReportFixture)
        {
            this.fileReportFixture = fileReportFixture;
        }

        [Theory]
        [MemberData("StringReplaceTestData", MemberType = typeof(TestData))]
        public void StringReplaceTheory(string prefix, string iterationPrefix, int iterations)
        {
            var pattern = BuildPattern(prefix, iterationPrefix, iterations);
            var replacements = BuildReplacements(iterations);

            var result = pattern;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < iterations; i++)
            {
                result = result.Replace($"@{i}", replacements[i]);
            }

            stopwatch.Stop();

            Assert.DoesNotContain("@", result);

            fileReportFixture.Writer.WriteLine($"String.Replace;{iterations};{stopwatch.ElapsedMilliseconds};{stopwatch.ElapsedTicks}");
        }

        internal static string BuildPattern(string prefix, string iterationPrefix, int iterations)
        {
            var builder = new StringBuilder(prefix);

            for (int i = 0; i < iterations; i++)
            {
                builder.Append($"{iterationPrefix}@{i} ");
            }

            return builder.ToString();
        }

        internal static Dictionary<int, string> BuildReplacements(int iterations)
        {
            var result = new Dictionary<int, string>();

            for (int i = 0; i < iterations; i++)
            {
                result.Add(i, $"!!{i}!!");
            }

            return result;
        }
    }
}
