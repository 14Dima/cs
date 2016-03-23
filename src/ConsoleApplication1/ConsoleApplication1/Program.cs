using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
namespace ConsoleApplication2
{
    class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {

            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Выберите файл git-cmd.exe";
            fd.Filter = "git|git-cmd.exe";
            fd.ShowDialog();
            string sk = "cd C:\\1\\preact & git tag>st2.txt & exit";
            Process myProcess;
            myProcess = Process.Start(fd.FileName, sk);
            myProcess.WaitForExit();
            FileStream f1 = new FileStream("C:\\1\\preact\\st2.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            StreamReader sr = new StreamReader(f1);
            string s;            
            string pathString= @"C:\\1\\preact\\s3.hml";
            FileStream fs = File.Create(pathString);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write("<root>");
            sw.WriteLine();
            do
            {
                s = sr.ReadLine();
                sk = "cd C:\\1\\preact & git show -s --format=\"%ad\" " + s + " >ss.txt & exit";                
                myProcess = Process.Start(fd.FileName, sk);
                myProcess.WaitForExit();
                FileStream f3 = new FileStream("C:\\1\\preact\\ss.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader sr2 = new StreamReader("C:\\1\\preact\\ss.txt");
                string s2 = sr2.ReadLine();
                string[] strs = s2.Split(' ');
                sw.Write("<tag name =" + '"' + s + '"' + " date=" + '"' + strs[0] + ", " + strs[2] + " " + strs[1] + " " + strs[4] + " " + strs[3] + '"' + "/>");
                sw.WriteLine();
                sr2.Close();
                
            } while (!(sr.EndOfStream));
            sw.Write("</root>");
            sw.Close();
            sr.Close();
        }
    }
}