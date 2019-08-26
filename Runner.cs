using System;
using System.Linq;
using System.Reflection;

namespace Closures
{
    public static class Runner
    {
        public static void Run()
        {
            var types =
                from type in Assembly
                    .GetCallingAssembly()
                    .GetExportedTypes()
                let run = (RunAttribute) type.GetCustomAttribute(
                    typeof(RunAttribute))
                where run != null
                orderby run.Priority descending, type.Name
                let constructor = type.GetConstructor(Type.EmptyTypes)
                select type;

            var runType = types.FirstOrDefault();
            if (runType == null)
                return;

            Console.WriteLine($"Running {runType.Name}-Example:");

            try
            {
                Activator.CreateInstance(runType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}