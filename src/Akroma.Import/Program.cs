using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Akroma.Persistence.SQL;

namespace Akroma.Import
{
    class Program
    {
        private static bool _loading;
        private static readonly ManualResetEvent ResetEvent = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            
            var timer = new System.Timers.Timer()
            {
                Interval = 10000
            };
            timer.Elapsed += async (sender, eventArgs) => await LoadBlocks();
            timer.Start();

            Console.WriteLine("Started Background");
            Console.ReadLine();
            Console.CancelKeyPress += (sender, eventArgs) => ResetEvent.Set();
            ResetEvent.WaitOne();
        }

        private static async Task LoadBlocks()
        {
            if (_loading)
            {
                return;
            }

            _loading = true;

            var contextFactory = new AkromaContextFactory();
            var import = new ImportService(contextFactory);
            await import.Execute();

            _loading = false;
        }
    }
}
