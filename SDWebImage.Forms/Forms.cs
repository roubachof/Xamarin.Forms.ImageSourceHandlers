﻿using System;

namespace SDWebImage.Forms
{
    public static class Forms
    {
        private const string WarningSeverity = "WNG";
        private const string DebugSeverity = "DBG";

        private const string LogTag = "|SDWebImage.Forms|";

        /// <summary>
        /// A flag indicating if Debug logging is enabled
        /// </summary>
        public static bool IsDebugEnabled {
            get;
            private set;
        }

        public static void Init(bool debug = false)
        {
            IsDebugEnabled = debug;
        }

        internal static void Warn(string format, params object [] args)
        {
            Console.WriteLine(GetLogPrefix(WarningSeverity) + format, args);
        }

        internal static void Debug(string format, params object [] args)
        {
            if (IsDebugEnabled)
            {
                Console.WriteLine(GetLogPrefix(DebugSeverity) + format, args);
            }
        }

        private static string GetLogPrefix(string logSeverity)
        {
            return DateTime.Now.ToString("MM-dd H:mm:ss.fff") + LogTag + logSeverity + ":\t";
        }
    }
}
