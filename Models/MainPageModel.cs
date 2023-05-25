using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLearningApp.Models
{
    // MainPageModel: There isn't much to this atm, only a few states i needed to store, so i could use them in ViewModels to direct logic behavior.
    class MainPageModel
    {
        // Main App States, set to false by default, static so its shared between instances.
        internal static bool IsCounting { get; set; } = false;
        internal static bool IsPaused { get; set; } = false;
        internal static bool IsReset { get; set; } = false;
        internal static bool IsTesting { get; set; } = false;
        internal static bool IsDebug { get; set; } = false;
        internal static bool IsSeconds { get; set; } = false;
        internal static bool IsMinutes { get; set; } = false;
        internal static bool IsHours { get; set; } = false;
        internal static bool IsDays { get; set; } = false;
        internal static bool IsMonths { get; set; } = false;
        internal static bool IsYears { get; set; } = false;
    }
}
