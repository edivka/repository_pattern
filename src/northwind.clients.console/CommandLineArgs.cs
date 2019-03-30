﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace northwind.clients.console
{
    public class CommandLineArgs : Dictionary<string, string>
    {
        private const string Pattern = @"\/(?<argname>\w+):(?<argvalue>.+)";
        private readonly Regex _regex = new Regex(Pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public CommandLineArgs()
        {
            var args = Environment.GetCommandLineArgs();
            foreach (var match in args.Select(arg => _regex.Match(arg)).Where(m => m.Success))
            {
                try
                {
                    Add(match.Groups["argname"].Value, match.Groups["argvalue"].Value);
                }
                catch(Exception) { }
            }
        }
    }
}
