﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PredatorFinder.Classes
{
    class Helper
    {
        public static string Statistic()
        {
            string roster = "";

            roster += "Source: " + Globals.Source.Count + Environment.NewLine;
            roster += "Good: " + Globals.GoodDomain + Environment.NewLine;
            roster += "Bad: " + Globals.GoodDomain + Environment.NewLine;
            roster += "Left: " + (Globals.Source.Count - (Globals.GoodDomain + Globals.BadDomain)) + Environment.NewLine;
            roster += "TimeOut: " + Globals.ProxyNeed;

            return roster;
        }

        public static void SaveText(string file, string text)
        {
            
            try
            {
                if (Directory.Exists($@"{Globals.AppPath}\Result"))
                {
                    var write = new StreamWriter($@"{Globals.AppPath}\Result\{file}", true);
                    write.WriteLine(text);
                    write.Close();
                }
                else
                {
                    Directory.CreateDirectory($@"{Globals.AppPath}\Result");
                    var write = new StreamWriter($@"{Globals.AppPath}\Result\{file}", true);
                    write.WriteLine(text);
                    write.Close();

                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static string OpenDialog()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "*.txt | *.txt";
            dialog.ShowDialog();
            return dialog.FileName;
        }

        public static List<string> LoadData(string filename)
        {
            var roster = new List<string>();
            roster.AddRange(File.ReadAllLines(filename));
            return roster;
        }

        public static void CheckProxy(string proxy)
        {
            try
            {
                Globals.Proxy = new WebProxy(proxy);
                Globals.ValidProxy = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Proxy not filled correctly, check will go without them ", "Proxy Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Globals.ValidProxy = false;
            }
        }
    }
}
