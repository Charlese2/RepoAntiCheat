using System;
using System.Linq;

namespace RepoAntiCheat
{

    public static class LoaderMessages
    {
        /// <summary>
        /// Gets the default loader message.
        /// </summary>
        public static string Default => @"


 /$$$$$$$   /$$$$$$   /$$$$$$ 
| $$__  $$ /$$__  $$ /$$__  $$
| $$  \ $$| $$  \ $$| $$  \__/
| $$$$$$$/| $$$$$$$$| $$          By Charlese2
| $$__  $$| $$__  $$| $$      
| $$  \ $$| $$  | $$| $$    $$
| $$  | $$| $$  | $$|  $$$$$$/
|__/  |__/|__/  |__/ \______/ 



";


        /// <summary>
        /// Gets the loader message according to the current month and flags.
        /// </summary>
        /// <returns>The corresponding loader message.</returns>
        public static string GetMessage()
        {
            var args = Environment.GetCommandLineArgs();

            if (args.Contains("--defaultloadmessage"))
                return Default;


            return Default;
        }
    }
}
