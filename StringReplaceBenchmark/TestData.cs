using System.Collections.Generic;

namespace StringReplaceBenchmark
{
    public static class TestData
    {
        private static readonly List<object[]> simpleCase = new List<object[]>
        {
            new object[] {string.Empty, string.Empty, 10},
            new object[] {string.Empty, string.Empty, 100},
            new object[] {string.Empty, string.Empty, 1000},
            new object[] {string.Empty, string.Empty, 10000},
            new object[] {string.Empty, string.Empty, 100000},
        };

        private static readonly List<object[]> longRun = new List<object[]>
        {
            new object[] {"Hello ", "Bye", 10},
            new object[] {"Hello ", "Bye", 100},
            new object[] {"Hello ", "Bye", 1000},
            new object[] {"Hello ", "Bye", 10000},
            new object[] {"Hello ", "Bye", 100000},
        };

        // Replace the property with the test data variable according to the test you wish to run
        public static IEnumerable<object[]> StringReplaceTestData => longRun;
    }
}
