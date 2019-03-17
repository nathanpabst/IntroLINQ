using System;
using System.IO;

namespace IntroLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\windows";
            ShowLargeFilesWithoutLinq(path);

        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());

            foreach (FileInfo file in files)
            {
                Console.WriteLine($"{file.Name} : {file.Length}");
            }

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
