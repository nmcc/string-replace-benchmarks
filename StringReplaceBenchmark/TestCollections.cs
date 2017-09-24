using Xunit;

namespace StringReplaceBenchmark
{

    public static class TestCollections
    {
        public const string StringReplace = "Collection.StringReplace";
    }

    [CollectionDefinition(TestCollections.StringReplace)]
    public class StringReplaceBenchmarkCollection : ICollectionFixture<FileReportFixture>
    {
    }
}
