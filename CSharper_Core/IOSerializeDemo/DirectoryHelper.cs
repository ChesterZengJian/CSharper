using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IOSerializeDemo
{
    public class DirectoryHelper
    {
        private readonly string m_path;
        private FileItem file;

        public DirectoryHelper(string path)
        {
            m_path = path;
        }

        public void GetFile()
        {
            if (!Directory.Exists(m_path))
            {
                file = new FileItem();
                return;
            }

            var dir = new DirectoryInfo(m_path);
            var childrens = GetChildrenFiles(dir);
            file = new FileItem
            {
                Name = dir.Name,
                Childrens = childrens
            };
        }

        private List<FileItem> GetChildrenFiles(DirectoryInfo dir)
        {
            var childrenDirs = dir.GetDirectories();

            if (childrenDirs.Length <= 0)
            {
                return new List<FileItem>();
            }

            var files = new List<FileItem>();

            foreach (var childrenDir in childrenDirs)
            {
                files.Add(new FileItem
                {
                    Name = childrenDir.Name,
                    Childrens = GetChildrenFiles(childrenDir)
                });
            }

            return files;
        }

        public void Print()
        {
            var sb = new StringBuilder();
            sb.AppendLine(file.ToString());

            var spaceCount = 0;
            PrintChildren(sb, file, spaceCount);

            Console.WriteLine(sb.ToString());
        }

        public void PrintChildren(StringBuilder sb, FileItem file, int spaceCount)
        {
            if (file == null || file.Childrens.Count <= 0)
            {
                return;
            }


            foreach (var children in file.Childrens)
            {
                for (int i = 0; i < spaceCount; i++)
                {
                    sb.Append(" ");
                }
                sb.AppendLine("|" + children.ToString());
                PrintChildren(sb, children, spaceCount + 2);
            }
        }
    }

    public class FileItem
    {
        public string Name { get; set; }

        public string Size { get; set; }

        public List<FileItem> Childrens { get; set; }

        public int CurChildrenTotal { get => Childrens.Count; }

        public override string ToString()
        {
            return $"Name:{Name}, Size:{Size} , Children Total:{CurChildrenTotal}";
        }
    }
}
