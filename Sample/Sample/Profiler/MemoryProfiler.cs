using System;
using System.Timers;

namespace SDWebImage.Forms.Sample.Profiler
{
	public class MemoryProfiler : IDisposable
    {
        public static MemoryProfiler Instance;

		readonly string name;
		readonly Timer timer = new Timer ();
		long peakMemory;
        long lowestMemory;

		public MemoryProfiler (string name)
		{
			this.name = name;
			timer.Interval = 3000;
			timer.Elapsed += OnElapsed;
			timer.Start ();
		}

		void OnElapsed (object sender, ElapsedEventArgs e)
		{
            //var runtime = Java.Lang.Runtime.GetRuntime ();
            //long usedMemory = runtime.TotalMemory () - runtime.FreeMemory ();

            var usedMemory = System.Diagnostics.Process.GetCurrentProcess().WorkingSet64;
            if (usedMemory > peakMemory)
                peakMemory = usedMemory;

            if (lowestMemory == 0)
                lowestMemory = usedMemory;

            if (usedMemory < lowestMemory)
                lowestMemory = usedMemory;

            Console.WriteLine(
                "SDWebImage.Sample|{0} Memory, Used: {1}, Peak: {2}, Lowest: {3}, MaxConsumed: {4}",
                name,
                usedMemory,
                peakMemory,
                lowestMemory,
                peakMemory - lowestMemory);

            // Console.WriteLine(APlatformPerformance.Instance.GetMemoryInfo());
        }

		public void Dispose ()
		{
			timer.Stop ();
		}
	}
}