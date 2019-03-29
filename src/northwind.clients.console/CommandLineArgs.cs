using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace northwind.clients.console
{
    /// <summary>
    /// Dictionary with input parameters of console application
    /// </summary>
    public class CommandLineArgs : Dictionary<string, string>
    {
        private const string Pattern = @"\/(?<argname>\w+):(?<argvalue>.+)";
        private readonly Regex _regex = new Regex(Pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /// <summary>
        /// Determine if the user pass at least one valid parameter
        /// </summary>
        /// <returns></returns>
        public bool ContainsValidArguments()
        {
            return (this.ContainsKey("load") || this.ContainsKey("create"));
        }

        /// <summary>
        /// Constructor
        /// </summary>
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
