using System;
using System.ComponentModel.Composition;

namespace VerbsSampleApp
{
    [Export]
    public class Runner
    {
        private readonly Action<string> _print;
        private readonly Func<string> _read;
        private readonly Action<int> _shutDown;

        [ImportingConstructor]
        public Runner(
            [Import(Verbs.Print)] Action<string> print,
            [Import(Verbs.Read)] Func<string> read,
            [Import(Verbs.Shutdown)] Action<int> shutDown)
        {
            _print = print;
            _read = read;
            _shutDown = shutDown;
        }

        public void Run()
        {
            PrintStartupInfo();
            
            InteractWithUser();

            _shutDown(0);
        }

        private void InteractWithUser()
        {
            _print("Please enter your name: ");
            
            var name = _read();
            
            _print("Hello " + name);
            _print("Please press enter to shut down");

             _read();
        }

        private void PrintStartupInfo()
        {
            _print("The super verbs application has started.");
        }
    }
}