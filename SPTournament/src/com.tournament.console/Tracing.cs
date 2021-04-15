using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPTournament.src.com.tournament.console
{
    public static class Tracing
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int pid);

       
        public static void SetupDebugConsole()
        {
            if (!AttachConsole(-1))  // Attach to a parent process console
                AllocConsole(); // Alloc a new console

            _process = System.Diagnostics.Process.GetCurrentProcess();
            System.Console.WriteLine();
        }

        public static void Trace(string format, params object[] args)
        {
            System.Console.Write("{0:D5} ", _process.Id);
            System.Console.WriteLine(format, args);
        }

        private static System.Diagnostics.Process _process;
    }
}
