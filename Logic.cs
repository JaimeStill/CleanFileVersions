using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CleanFileVersions
{
    public static class Logic
    {
        public static string GetWorkingDirectory(this string directory) =>
            string.IsNullOrWhiteSpace(directory)
                ? Environment.CurrentDirectory
                : directory.StartsWith("/") || directory.StartsWith(@"\")
                    ? Path.Join(Environment.CurrentDirectory, directory)
                    : directory;

        public static IEnumerable<FileInfo> GetFiles(this string directory) =>
            new DirectoryInfo(directory)
                .EnumerateFiles("*_*");

        public static void WriteFileInfo(this IEnumerable<FileInfo> files) =>
            files.ToList()
                 .ForEach(x => 
                    Console.WriteLine(x.Name)
                 );

        public static void CleanFiles(this IEnumerable<FileInfo> files)
        {
            int result;

            var distinctFiles = files
                .Where(x =>
                    int.TryParse(
                        x.Name.Split('.')[0]
                              .Split('_')[1],
                        out result
                    )
                )
                .Select(x => $"{x.Name.Split('.')[0].Split('_')[0]}.{x.Name.Split('.')[1]}").Distinct();

            Console.WriteLine("Cleaning the following file series:");
            foreach (var file in distinctFiles) Console.WriteLine(file);

            var removeFiles = distinctFiles.GetFilesToRemove(files);

            Console.WriteLine("The following files will be removed:");
            removeFiles.WriteFileInfo();

            removeFiles.DeleteFiles();
        }

        public static List<FileInfo> GetFilesToRemove(this IEnumerable<string> distinctFiles, IEnumerable<FileInfo> files)
        {
            var removeFiles = new List<FileInfo>();

            foreach (var file in distinctFiles)
            {
                var orderedFiles = files.Where(x => 
                    x.Name.ToLower()
                          .StartsWith(file.Split('.')[0].ToLower()) &&
                    x.Name.ToLower()
                          .EndsWith(file.Split('.')[1].ToLower())
                    ).OrderByDescending(x => x.Name);

                removeFiles.AddRange(orderedFiles.Skip(1));
            }

            return removeFiles;
        }

        public static void DeleteFiles(this IEnumerable<FileInfo> files)
        {
            foreach (var file in files)
            {
                file.Delete();
            }
        }
    }
}