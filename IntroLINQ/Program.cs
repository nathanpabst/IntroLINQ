using System;
using System.IO;
using System.Linq;

namespace IntroLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\windows";
            ShowLargeFilesWithoutLinq(path);
            Console.WriteLine("***");
            ShowLargeFilesWithLinq(path);
            Console.ReadLine();
        }

        //Method to retrieve the five largest files using LINQ
        private static void ShowLargeFilesWithLinq(string path)
        {
            var query = from file in new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending
                        select file;
            foreach (var file in query.Take(5))
            {
                Console.WriteLine($"{file.Name, -20} : {file.Length, 10:N0}");
            }
                        
        }

        //method to retrieve the five largest files without LINQ
        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());

            for (int i = 0; i < 5; i++)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name, -20} : {file.Length, 10:N0}");
            }
            // retrieving all files
            //foreach (FileInfo file in files)
            //{
            //    Console.WriteLine($"{file.Name} : {file.Length}");
            //}

            Console.ReadLine(); 
        }
    }

    public class FileInfoComparer : System.Collections.Generic.IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
