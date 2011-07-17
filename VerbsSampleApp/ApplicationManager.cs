using System;
using System.ComponentModel.Composition;

namespace VerbsSampleApp
{
    public class ApplicationManager
    {
        private readonly Action<string> _print;

        [ImportingConstructor]
        public ApplicationManager([Import(Verbs.Print)] Action<string> print)
        {
            _print = print;
        }

        [Export(Verbs.Shutdown)]
        public void ShutDownApplication(int code)
        {
            _print("Shutting down ....");
            Environment.Exit(code);
        }
    }
}