using System;
using System.Collections.Generic;
using System.Text;

namespace SDWebImage.Forms.Sample.Profiler
{
    public abstract class APlatformPerformance
    {
        public static APlatformPerformance Instance { get; set; }

        public abstract string GetMemoryInfo();
    }
}
