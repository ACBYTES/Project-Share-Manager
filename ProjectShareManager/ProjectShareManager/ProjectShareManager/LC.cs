// MIT License

// Copyright (c) 2020 Alireza Shahbazi (ACBYTES) (alirezashahbazi641@yahoo.com)

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectShareManager
{
    class LC
    {
        public static async void GD(Form T)
        {
            var ptf = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            if (File.Exists(ptf + "//ACPSM.0011"))
            {
                WebClient client = new WebClient();
                client.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                string s = File.ReadAllText(ptf + "//ACPSM.0011");
                try
                {
                    var data = await client.DownloadDataTaskAsync("http://alirezacodings.ir/ACPSM.txt");
                    s = System.Text.UTF8Encoding.UTF8.GetString(data);
                    Perform(s, T);
                }
                catch
                {
                    Perform(s, T);
                }
            }

            else
            {
                try
                {
                    WebClient client = new WebClient();
                    client.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                    var data = await client.DownloadDataTaskAsync("http://alirezacodings.ir/ACPSM.txt");
                    var s = System.Text.UTF8Encoding.UTF8.GetString(data);
                    Perform(s, T);
                }
                catch
                {
                    foreach (Control item in T.Controls)
                    {
                        item.Enabled = true;
                    }
                }
            }

            GC.Collect();
        }
        private static void Perform(string s, Form T)
        {
            if (s == "3480c3e4860d641456b2bf1452317cbfd2872167abca186ae161582b175c8769239db61e42284adce0ace8fdb75b2c199b28ea9fa3c97e401846fae520ee2d60")
            {
                MessageBox.Show("Application has been disabled.", "ERROR");
                var p = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                foreach (Control item in T.Controls)
                {
                    if (item.Name != "ACCB" && item.Name != "linklbl")
                        item.Enabled = false;
                }
                File.WriteAllText(p + "//ACPSM.0011", s);
            }

            else if (s == "35974988EBFD995050B55F938F2526226BED6D1CE292AC7B4220A03589C2235D38C47428F0792AD5E344590DC38DFC2BCA9BE9B54B540248C0E5EC48C5B2BBA4")
            {
                var p = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                File.Delete(p + "//ACPSM.0011");
                foreach (Control item in T.Controls)
                {
                    item.Enabled = true;
                }
            }
            GC.Collect();
        }
    }
}
