using System.Diagnostics;
using Xunit.Abstractions;

namespace Akroma.Import.Tests
{
    internal class TestTraceListener : TraceListener
    {
        readonly ITestOutputHelper _output;
        public TestTraceListener(ITestOutputHelper output) { _output = output; }
        public override void Write(string message) { _output.WriteLine(message); }
        public override void WriteLine(string message) { _output.WriteLine(message); }
    }
}
