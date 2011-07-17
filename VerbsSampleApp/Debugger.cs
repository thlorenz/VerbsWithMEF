using System;
using System.ComponentModel.Composition;
using System.Diagnostics;

namespace VerbsSampleApp
{
    public class Debugger
    {
        [Export(Verbs.CompositePrint)]
        public void Print(string message)
        {
            Debug.WriteLine(DateTime.Now + " - " + message);
        }
    }
}