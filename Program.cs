using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CleanFileVersions
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = (
                args.Length > 0
                    ? args[0]
                    : string.Empty
            ).GetWorkingDirectory();

            Console.WriteLine($"Retrieving files from {directory}...");

            var files = directory.GetFiles();

            if (files.Count() > 0)
            {
                files.CleanFiles();
                Console.WriteLine("Files successfully cleaned.");
            }
            else
            {
                Console.WriteLine("No files found matching the pattern *_*");
            }
        }
    }
}
