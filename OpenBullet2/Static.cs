﻿using OpenBullet2.Models;
using OpenBullet2.Models.Debugger;
using OpenBullet2.Models.Logging;
using RuriLib.Models.Configs;
using RuriLib.Models.Environment;
using RuriLib.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenBullet2
{
    // Just for testing
    public static class Static
    {
        public static SecurityOptions SecurityOptions { get; set; } = new SecurityOptions();

        public static List<Config> Configs { get; set; }
        public static event EventHandler<Config> ConfigSelected;

        private static Config config = null;
        public static Config Config
        {
            get => config;
            set
            {
                config = value;
                ConfigSelected.Invoke(null, config);
            }
        }

        public static EnvironmentSettings Environment { get; set; } =
            EnvironmentSettings.FromIni("Environment.ini");

        public static GlobalSettings RuriLibSettings { get; set; } = new GlobalSettings();

        public static DebuggerOptions DebuggerOptions { get; set; } = new DebuggerOptions();
        public static BotLogger DebuggerLog { get; set; } = new BotLogger();

        private static DateTime startTime = DateTime.Now;
        public static TimeSpan UpTime => DateTime.Now - startTime;

        public static string[] GetStatuses()
        {
            return (new string[]
            {
            "SUCCESS", "NONE", "FAIL", "RETRY", "BAN", "ERROR"
                }).Concat(Environment.CustomStatuses.Select(s => s.Name)).ToArray();
        }
    }
}