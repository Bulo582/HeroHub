using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Projekt.Scripts.System.Debug
{
    public static class GameDebug
    {
        public static void Log(string message)
        {
            if (!DebugSettings.DebugEnabled) return;
            UnityEngine.Debug.Log(message);
        }

        public static void Log(string message, UnityEngine.Object context)
        {
            if (!DebugSettings.DebugEnabled) return;
            UnityEngine.Debug.Log(message, context);
        }

        public static void LogWarning(string message)
        {
            if (!DebugSettings.DebugEnabled) return;
            UnityEngine.Debug.LogWarning(message);
        }

        public static void LogError(string message)
        {
            UnityEngine.Debug.LogError(message);
        }

        public static void LogError(string message, UnityEngine.Object context)
        {
            UnityEngine.Debug.LogError(message, context);
        }
    }
}
