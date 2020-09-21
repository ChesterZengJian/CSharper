using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace ExecuteExternalProgramDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            const int ERROR_FILE_NOT_FOUND = 2;
            const int ERROR_ACCESS_DENIED = 5;
            try
            {
                using var p = new Process
                {
                    StartInfo =
                    {
                        UseShellExecute = false,
                        CreateNoWindow = false,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        FileName = $"{Path.Combine(AppContext.BaseDirectory,"bats","hello.bat")}"
                    }
                };
                p.Start();

                p.StandardInput.AutoFlush = true;

                using var reader = p.StandardOutput;
                var curLine = reader.ReadLine(); //获取错误信息到error
                while (!reader.EndOfStream)
                {
                    if (!string.IsNullOrEmpty(curLine))
                    {
                        Console.WriteLine(curLine);
                    }
                    curLine = reader.ReadLine();
                }

                p.WaitForExit();
            }
            catch (Win32Exception e)
            {
                switch (e.NativeErrorCode)
                {
                    case ERROR_FILE_NOT_FOUND:
                        Console.WriteLine(e.Message + ". 检查文件路径.");
                        break;
                    case ERROR_ACCESS_DENIED:
                        Console.WriteLine(e.Message + ". 你没有权限操作文件.");
                        break;
                    default:
                        Console.WriteLine(e.Message);
                        break;
                }
            }

        }
    }
}
