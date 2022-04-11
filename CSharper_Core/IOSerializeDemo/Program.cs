using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace IOSerializeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                //var forest = new Tree<string>("root");
                //var current = forest;
                //var paths = new List<string>
                //{
                //    "a/b/c/d/e",
                //    "a/b/e/f/g",
                //    "a/b/h",
                //    "a/i/j",
                //    "a/i/k"
                //};

                //foreach (var path in paths)
                //{
                //    var root = current;
                //    foreach (var data in path.Split("/"))
                //    {
                //        current = current.Child(data);
                //    }
                //    current = root;
                //}

                //forest.Accept(new TreeVisitor());
                //Console.WriteLine(JsonConvert.SerializeObject(forest));
            }

            {
                //var st = new Stopwatch();
                //st.Start();
                //var dirHelper = new DirectoryHelper(@"E:\Game");
                //dirHelper.GetFile();
                ////dirHelper.Print();
                //st.Stop();
                //Console.WriteLine(st.ElapsedMilliseconds);
            }

            {
                //var logPath = ConfigurationManager.AppSettings["LogPath"].ToString();

                //Console.WriteLine(Path.Combine(@"F:\Dockers", "info.exe"));

                //var filePath = Path.Combine(@"F:\Dockers\test1", "text.txt");

                //using var fileStream = File.Create(Path.Combine(@"F:\Dockers\test1", "text.txt"));
                //var name = "231423sdfafa";
                //var bytes = Encoding.Default.GetBytes(name);
                //fileStream.Write(bytes, 0, bytes.Length);
                //fileStream.Flush();

                //using var fileStream = File.Create(Path.Combine(@"F:\Dockers\test1", "text.txt"));
                //var name = "231423sdfafa";
                //var sw = new StreamWriter(fileStream);
                //sw.WriteLine(name);
                //sw.Flush();

                //using var sw = File.AppendText(filePath);
                //var msg = "This is Append text";
                //sw.WriteLine(msg);
                //sw.Flush();

                //foreach (var line in File.ReadAllLines(filePath))
                //{
                //    Console.WriteLine(line);
                //}

                //Console.WriteLine(File.ReadAllText(filePath));

                //var bytes = File.ReadAllBytes(filePath);
                //Console.WriteLine(Encoding.Default.GetString(bytes));

                //using var fs = File.OpenRead(filePath);
                //const int length = 5;
                //var result = 0;

                //do
                //{
                //    var bytes = new byte[length];
                //    result = fs.Read(bytes, 0, 5);
                //    for (var i = 0; i < result; i++)
                //    {
                //        Console.WriteLine(bytes[i].ToString());
                //    }
                //} while (length == result);

                //File.Move(filePath,destFileName)
                //File.Copy(filePath, destFileName);
                //File.Delete(filePath);
            }

            {
                //if (Directory.Exists(@"F:\Dockers"))
                //{
                //    Console.WriteLine("Directory exists");
                //}

                //var directoryInfo = new DirectoryInfo(@"F:\Dockerss");
                //Console.WriteLine(directoryInfo);

                //Directory.CreateDirectory(@"F:\Dockers\test1\test2.txt");

                //Directory.Move(@"F:\Dockers\test1", @"F:\Dockers");

                //Directory.Delete(@"F:\Dockers\test2");

                //Console.WriteLine(Path.GetDirectoryName(@"D:\dr"));
                //Console.WriteLine(Path.GetDirectoryName(@"D:\dr\"));

                //Console.WriteLine(Path.GetRandomFileName());
                //Console.WriteLine(Path.GetFileNameWithoutExtension(@"D:\dr.txt"));

                //Console.WriteLine(Path.GetInvalidFileNameChars());
                //Console.WriteLine(Path.GetInvalidPathChars());
            }

            {
                //var directories = GetAllDirectory(@"F:\My_GitHubProject");
            }

            {
                //var directoryPath = string.Empty;

                //while (string.IsNullOrEmpty(directoryPath))
                //{
                //    Console.WriteLine("Input your directory path:");
                //    directoryPath = Console.ReadLine();
                //}

                //var directory = new DirectoryInfo(directoryPath);
                //var childrenDirectories = directory.GetDirectories();
                //var emptyDirectories = new List<DirectoryInfo>();
                //Console.WriteLine($"There are {childrenDirectories.Length} children directories and {directory.GetFiles().Length} files. Here are the details:");

                //foreach (var directoryInfo in childrenDirectories)
                //{
                //    Console.WriteLine($"{directoryInfo.Name}");
                //    Console.WriteLine($"\tChildren folders: {directoryInfo.GetDirectories().Length}");
                //    Console.WriteLine($"\tFiles: {directoryInfo.GetFiles().Length}");

                //    if (directoryInfo.GetDirectories().Length == 0 && directoryInfo.GetFiles().Length == 0)
                //    {
                //        emptyDirectories.Add(directoryInfo);
                //    }
                //}

                //Console.WriteLine($"Choice your operation:");
                //Console.WriteLine("D: Delete empty directories");
                //switch (Console.ReadKey().Key)
                //{
                //    case ConsoleKey.D:
                //        DeleteDirectories(emptyDirectories);
                //        break;
                //    default:
                //        Console.WriteLine("Unsupported operation");
                //        break;
                //}
            }
        }

        public static List<DirectoryInfo> GetAllDirectory(string rootPath)
        {
            if (!Directory.Exists(rootPath))
            {
                return new List<DirectoryInfo>();
            }

            var directoryInfos = new List<DirectoryInfo>();
            var directory = new DirectoryInfo(rootPath);

            return GetChild(directoryInfos, directory);
        }

        private static List<DirectoryInfo> GetChild(List<DirectoryInfo> directoryInfos, DirectoryInfo directory)
        {
            var childDirectories = directory.GetDirectories();
            if (childDirectories.Length <= 0) return directoryInfos;
            foreach (var childDirectory in childDirectories)
            {
                directoryInfos.Add(childDirectory);
                GetChild(directoryInfos, childDirectory);
            }

            return directoryInfos;
        }

        private static void DeleteDirectories(List<DirectoryInfo> directoryInfos)
        {
            foreach (var directoryInfo in directoryInfos)
            {
                directoryInfo.Delete();
            }
        }
    }
}
