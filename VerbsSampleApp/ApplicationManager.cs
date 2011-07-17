using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace VerbsSampleApp
{
    public class ApplicationManager
    {
        private readonly IEnumerable<Action<string>> _printToMany;

        [ImportingConstructor]
        public ApplicationManager(
            [ImportMany(Verbs.CompositePrint, AllowRecomposition = true)] IEnumerable<Action<string>> printToMany)
        {
            _printToMany = printToMany;
        }

        [Export(Verbs.Shutdown)]
        public void ShutDownApplication(int code)
        {
            ApplicationPrint("Shutting down ....");
            Environment.Exit(code);
        }

        [Export(Verbs.Print)]
        public void ApplicationPrint(string msg)
        {
            foreach (var print in _printToMany)
            {
                print(msg);
            }
        }
    }
}