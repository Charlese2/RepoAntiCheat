using System;
using System.Linq;

namespace RepoAntiCheat
{
    public static class LoaderMessages
    {
        /// <summary>
        /// Default loader message.
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

        private static string Halloween => @"




 ██▀███   ▄▄▄       ▄████▄  
▓██ ▒ ██▒▒████▄    ▒██▀ ▀█  
▓██ ░▄█ ▒▒██  ▀█▄  ▒▓█    ▄ 
▒██▀▀█▄  ░██▄▄▄▄██ ▒▓▓▄ ▄██▒     By Charlese2
░██▓ ▒██▒ ▓█   ▓██▒▒ ▓███▀ ░
░ ▒▓ ░▒▓░ ▒▒   ▓▒█░░ ░▒ ▒  ░
  ░▒ ░ ▒░  ▒   ▒▒ ░  ░  ▒   
  ░░   ░   ░   ▒   ░        
   ░           ░  ░░ ░      
                   ░        



";

        private static string Christmas => @"


        *       *       *       *       *       *       *
            *      🎄 Merry Christmas from RepoAntiCheat 🎄     *
   *      *      *       *       *       *       *       * 

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
        /// Gets the loader message based on current month and command-line args.
        /// </summary>
        public static string GetMessage()
        {
            var args = Environment.GetCommandLineArgs();

            if (args.Contains("--defaultloadmessage"))
                return Default;

            int month = DateTime.Now.Month;

            return month switch
            {
                10 => Halloween,  // October
                12 => Christmas,  // December
                _ => Default
            };
        }
    }
}
