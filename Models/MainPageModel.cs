using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLearningApp.Models
{
    class MainPageModel
    {
        // Main App States.
        internal static bool IsInit { get; set; }
        internal static bool IsCounting { get; set; }
        internal static bool IsPaused { get; set; }
        internal static bool IsReset { get; set; }
        internal static bool IsTesting { get; set; }
        internal static bool IsDebug { get; set; }
        internal static bool IsSeconds { get; set; }
        internal static bool IsMinutes { get; set; }
        internal static bool IsHours { get; set; }
        internal static bool IsDays { get; set; }
        internal static bool IsMonths { get; set; }
        internal static bool IsYears { get; set; }
    }
}
