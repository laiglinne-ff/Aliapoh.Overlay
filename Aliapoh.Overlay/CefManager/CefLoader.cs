﻿using CefSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliapoh.Overlay
{
    public class CefLoader
    {
        public static void Initialize()
        {            
            var userAgent = "Mozilla/5.0 (Windows NT " + (Environment.Is64BitOperatingSystem ? "x64" : "x86") + ") AppleWebKit/537.36 (KHTML, like Gecko) Aliapoh.Overlay/Chrome/63.0.3239.109 Safari/537.36";

            var setting = new CefSettings()
            {
                ExternalMessagePump = false,
                MultiThreadedMessageLoop = true,
                WindowlessRenderingEnabled = true,
                FocusedNodeChangedEnabled = true,
                RemoteDebuggingPort = 9994,
                UserAgent = userAgent,
                CachePath = "Cache",
                LogSeverity = LogSeverity.Disable,
            };

            if (!Cef.Initialize(setting))
            {
                throw new Exception("Unable to Initialize Cef");
            }
        }
    }
}