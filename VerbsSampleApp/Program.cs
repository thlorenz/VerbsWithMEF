using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace VerbsSampleApp
{
    public class Program
    {
        private CompositionContainer _container;

        public static void Main(string[] args)
        {
            var p = new Program();
            p.Run();
        }

        public void Run()
        {
            Compose();

            var runner = _container.GetExport<Runner>().Value;
            runner.Run();
        }

        private void Compose()
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            _container = new CompositionContainer(catalog);
            _container.ComposeParts(this);
        }
    }
}