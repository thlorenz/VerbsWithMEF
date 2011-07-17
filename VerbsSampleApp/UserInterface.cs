using System;
using System.ComponentModel.Composition;

namespace VerbsSampleApp
{
    public class UserInterface
    {
        [Export(Verbs.Print)]
        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        [Export(Verbs.Read)]
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}