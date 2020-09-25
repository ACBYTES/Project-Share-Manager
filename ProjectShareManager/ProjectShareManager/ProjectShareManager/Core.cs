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
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;

namespace ProjectShareManager
{
    class Core
    {
        public static bool isParallel = false;

        private static protected List<string> newDirs;
        private static protected List<string> newFiles;

        public static string TempPath = $"{Application.StartupPath}\\Temp\\";
        public static char[] GenPC = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        public static Random rand = new Random();
        private static Action acv = new Action(() => ProcessInfo.aliveInstance.Visible = false);

        public static string customLog = string.Empty;

        public static bool CheckReferencePath(string Path)
        {
            bool d = (Directory.GetDirectories(Path).Length == 0) ? false : true;
            bool f = (Directory.GetFiles(Path).Length == 0) ? false : true;
            return (f || d);
        }

        public static List<List<string>> Export(string Path, string RefPath, bool F, Form1 Sender = null)
        {
            if (F)
            {
                Copy(Path, RefPath);
                return null;
            }

            else
            {
                newDirs = new List<string>();
                newFiles = new List<string>();
                CheckFilesAndCopy(Path, RefPath);
                GC.Collect();
                MessageBox.Show($"DIRs: {newDirs.Count} || FILES: {newFiles.Count}");
                return new List<List<string>> { newDirs, newFiles };
            }
        }

        public static void Copy(string Path, string Destination, string DesMessage = "reference", string BaseMessage = "base", Form1 Sender = null)
        {
            if (!isParallel)
            {
                #region Non-Parallel
                foreach (var file in Directory.GetFiles(Path, ".", SearchOption.TopDirectoryOnly))
                {
                    File.Copy(file, file.Replace(Path, Destination), true);
                }
                #endregion
            }

            else
            {
                #region Parallel
                Parallel.ForEach(Directory.GetFiles(Path, ".", SearchOption.TopDirectoryOnly), (file) =>
                {
                    File.Copy(file, file.Replace(Path, Destination), true);
                });
            }
            #endregion

            if (Sender != null)
            {
                Action acBFC = new Action(() => Sender.processInfoInst.ChangeLT('D', $"Base Files ({ProcessInfo.Check})"));
                Sender.Invoke(acBFC);
            }
            //MessageBox.Show($"The {BaseMessage} files have been copied to {DesMessage}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            if (!isParallel)
            {
                #region Non_Parallel
                foreach (var item in Directory.GetDirectories(Path, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(/*$@"{Destination}\{item}"*/ item.Replace(Path, Destination));
                    foreach (var file in Directory.GetFiles(item, ".", SearchOption.TopDirectoryOnly))
                    {
                        File.Copy(file, file.Replace(Path, Destination), true);
                    }
                }
                #endregion
            }

            else
            {
                #region Parallel
                Parallel.ForEach(Directory.GetDirectories(Path, "*", SearchOption.AllDirectories), (item) =>
                {
                    Directory.CreateDirectory(/*$@"{Destination}\{item}"*/ item.Replace(Path, Destination));
                    Parallel.ForEach(Directory.GetFiles(item, ".", SearchOption.TopDirectoryOnly), (file) =>
                    {
                        File.Copy(file, file.Replace(Path, Destination), true);
                    });
                });
                #endregion
            }

            if (Sender != null)
            {
                Action acBFC = new Action(() => Sender.processInfoInst.ChangeLT('F', $"Other Directories and Files ({ProcessInfo.Check})"));
                Sender.Invoke(acBFC);
            }
            //MessageBox.Show($"The whole directory and files have been copied to {DesMessage}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static async Task CopyAsync(string Path, string Destination, string DesMessage = "reference", string BaseMessage = "base")
        {
            if (!isParallel)
            {
                foreach (var file in Directory.GetFiles(Path, ".", SearchOption.TopDirectoryOnly))
                {
                    File.Copy(file, file.Replace(Path, Destination), true);
                }
            }

            else
            {
                Parallel.ForEach(Directory.GetFiles(Path, ".", SearchOption.TopDirectoryOnly), (file) =>
                {
                    File.Copy(file, file.Replace(Path, Destination), true);
                });
            }
            MessageBox.Show($"The {BaseMessage} files have been copied to {DesMessage}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            if (!isParallel)
            {
                foreach (var item in Directory.GetDirectories(Path, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(/*$@"{Destination}\{item}"*/ item.Replace(Path, Destination));
                    foreach (var file in Directory.GetFiles(item, ".", SearchOption.TopDirectoryOnly))
                    {
                        File.Copy(file, file.Replace(Path, Destination), true);
                    }
                }
            }

            else
            {
                Parallel.ForEach(Directory.GetDirectories(Path, "*", SearchOption.AllDirectories), (item) =>
                {
                    Directory.CreateDirectory(/*$@"{Destination}\{item}"*/ item.Replace(Path, Destination));
                    Parallel.ForEach(Directory.GetFiles(item, ".", SearchOption.TopDirectoryOnly), (file) =>
                    {
                        File.Copy(file, file.Replace(Path, Destination), true);
                    });
                });
            }
            MessageBox.Show($"The whole directory and files have been copied to {DesMessage}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void CopyFile(string Path, string FilePath, string Destination)
        {
            var filePathRootDir = FilePath.Substring(0, FilePath.LastIndexOf('\\'));
            var destR = filePathRootDir.Replace(Path, Destination);
            Directory.CreateDirectory(destR);
            File.Copy(FilePath, FilePath.Replace(Path, Destination), true);
        }

        public static void CopyDirectory(string Path, string DirPath, string Destination)
        {
            Directory.CreateDirectory(DirPath.Replace(Path, Destination));
            if (!isParallel)
            {
                foreach (var item in Directory.GetDirectories(Path, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(/*$@"{Destination}\{item}"*/ item.Replace(Path, Destination));
                    foreach (var file in Directory.GetFiles(item, ".", SearchOption.TopDirectoryOnly))
                    {
                        File.Copy(file, file.Replace(Path, Destination), true);
                    }
                }
            }

            else
            {
                Parallel.ForEach(Directory.GetDirectories(Path, "*", SearchOption.AllDirectories), (item) =>
                {
                    Directory.CreateDirectory(/*$@"{Destination}\{item}"*/ item.Replace(Path, Destination));
                    Parallel.ForEach(Directory.GetFiles(item, ".", SearchOption.TopDirectoryOnly), (file) =>
                    {
                        File.Copy(file, file.Replace(Path, Destination), true);
                    });
                });
            }
        }

        private static void CheckFilesAndCopy(string Path, string Destination)
        {
            if (!isParallel)
            {
                foreach (var file in Directory.GetFiles(Path, ".", SearchOption.TopDirectoryOnly))
                {
                    CompareFile(file, file.Replace(Path, Destination));
                }
            }

            else
            {
                Parallel.ForEach(Directory.GetFiles(Path, ".", SearchOption.TopDirectoryOnly), (file) =>
                {
                    CompareFile(file, file.Replace(Path, Destination));
                });
            }

            if (!isParallel)
            {
                foreach (var item in Directory.GetDirectories(Path, "*", SearchOption.AllDirectories))
                {
                    if (!Directory.Exists(item.Replace(Path, Destination)))
                    {
                        //Copy(item, Destination);
                        newDirs.Add(item);
                    }

                    else
                    {
                        foreach (var file in Directory.GetFiles(item, ".", SearchOption.TopDirectoryOnly))
                        {
                            CompareFile(file, file.Replace(Path, Destination));
                        }
                    }
                }
            }

            else
            {
                Parallel.ForEach(Directory.GetDirectories(Path, "*", SearchOption.AllDirectories), (item) =>
                {
                    if (!Directory.Exists(item.Replace(Path, Destination)))
                    {
                        //Copy(item, Destination);
                        newDirs.Add(item);
                    }

                    else
                    {
                        foreach (var file in Directory.GetFiles(item, ".", SearchOption.TopDirectoryOnly))
                        {
                            CompareFile(file, file.Replace(Path, Destination));
                        }
                    }
                });
            }
        }

        private static void CompareFile(string BaseFile, string DestinationFile)
        {
            if (!File.Exists(DestinationFile))
                newFiles.Add(BaseFile);
            //File.Copy(BaseFile, DestinationFile);
            else
                CompareContent(BaseFile, DestinationFile);
        }

        private static void CompareContent(string BaseFile, string DestinationFile)
        {
            //Read both files and see if any of them have different contents.
            //Convert contents of the first file to SHA512 and compare it with the SHA512 of the second file.
            //MD5 md5 = MD5.Create();

            BinaryReader reader = new BinaryReader(new FileStream(BaseFile, FileMode.Open));
            BinaryReader reader1 = new BinaryReader(new FileStream(DestinationFile, FileMode.Open));
            byte b0;
            byte b1;
            if (reader.BaseStream.Length != reader1.BaseStream.Length)
            {
                newFiles.Add(BaseFile);
                GC.Collect();
                return;
            }

            else if (reader.BaseStream.Length == reader1.BaseStream.Length)
            {
                for (int i = 0; i < reader.BaseStream.Length; i++)
                {
                    reader.BaseStream.Seek(i, SeekOrigin.Begin);
                    reader1.BaseStream.Seek(i, SeekOrigin.Begin);
                    b0 = reader.ReadByte();
                    b1 = reader1.ReadByte();
                    if (!b0.Equals(b1))
                    {
                        newFiles.Add(BaseFile);
                        GC.Collect();
                        return;
                    }
                }
            }

            //byte[] baseMD5 = File.ReadAllBytes(BaseFile);
            //byte[] destMD5 = File.ReadAllBytes(DestinationFile);
            //var result = baseMD5.SequenceEqual(destMD5);

            //if (!result)
            //{
            //    //File.Copy(BaseFile, DestinationFile);
            //    newFiles.Add(BaseFile);
            //}
        }

        public static bool CopyToNewVersion(string Path, string ExportationPath, string Version)
        {
            StreamWriter writer = File.CreateText($"{ExportationPath}\\LOG.txt");

            int files = 0;
            int dirs = 0;

            Action acd = new Action(() => ProcessInfo.D.Text = ProcessInfo.DV + (newDirs.Count - dirs).ToString());
            Action acf = new Action(() => ProcessInfo.F.Text = ProcessInfo.FV + (newFiles.Count - files).ToString());
            
            if (!isParallel)
            {
                foreach (var item in newDirs)
                {
                    CopyDirectory(Path, item, ExportationPath);
                    writer.WriteLine($"D({item.Replace(Path, "")})");
                    dirs++;
                    ProcessInfo.aliveInstance.Invoke(acd);
                }
            }

            else
            {
                Parallel.ForEach(newDirs, (item) =>
                {
                    CopyDirectory(Path, item, ExportationPath);
                    writer.WriteLine($"D({item.Replace(Path, "")})");
                    dirs++;
                    ProcessInfo.aliveInstance.Invoke(acd);
                });
            }

            acd = new Action(() => ProcessInfo.aliveInstance.AddLT('D', $" {ProcessInfo.Check}"));
            ProcessInfo.aliveInstance.Invoke(acd);

            if (!isParallel)
            {
                foreach (var item in newFiles)
                {
                    CopyFile(Path, item, ExportationPath);
                    writer.WriteLine($"F({System.IO.Path.GetFileName(item)})");
                    files++;
                    ProcessInfo.aliveInstance.Invoke(acf);
                }
            }

            else
            {
                Parallel.ForEach(newFiles, (item) =>
                {
                    CopyFile(Path, item, ExportationPath);
                    writer.WriteLine($"F({System.IO.Path.GetFileName(item)})");
                    files++;
                    ProcessInfo.aliveInstance.Invoke(acf);
                });
            }

            acd = new Action(() => ProcessInfo.aliveInstance.AddLT('F', $" {ProcessInfo.Check}"));
            ProcessInfo.aliveInstance.Invoke(acd);

            writer.WriteLine($"Custom Log [ {customLog} ]");

            writer.Flush();
            writer.Close();
            writer.Dispose();
            MessageBox.Show("NEW VERSION IS READY!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Action ps = new Action(() => ProcessInfo.aliveInstance.ChangeLT('T', "Compressing Files"));
            ProcessInfo.aliveInstance.Invoke(ps);

            ZipFiles(ExportationPath, Version);

            MessageBox.Show("Compression has been successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            ProcessInfo.aliveInstance.Invoke(acv);
            return true;
        }

        public static bool CopyToNewVersion(string Path, string ExportationPath, string Version, List<FormSIMW.FileControl> NewDirs, List<FormSIMW.FileControl> NewFiles)
        {
            StreamWriter writer = File.CreateText($"{ExportationPath}\\LOG.txt");

            int files = 0;
            int dirs = 0;

            Action acd = new Action(() => ProcessInfo.D.Text = ProcessInfo.DV + (newDirs.Count - dirs).ToString());
            Action acf = new Action(() => ProcessInfo.F.Text = ProcessInfo.FV + (newFiles.Count - files).ToString());

            if (!isParallel)
            {
                foreach (var item in NewDirs)
                {
                    CopyDirectory(Path, item._file, ExportationPath);
                    writer.WriteLine($"D({item._file.Replace(Path, "")})");
                    dirs++;
                    ProcessInfo.aliveInstance.Invoke(acd);
                }
            }

            else
            {
                Parallel.ForEach(NewDirs, (item) =>
                {
                    CopyDirectory(Path, item._file, ExportationPath);
                    writer.WriteLine($"D({item._file.Replace(Path, "")})");
                    dirs++;
                    ProcessInfo.aliveInstance.Invoke(acd);
                });
            }

            acd = new Action(() => ProcessInfo.aliveInstance.AddLT('D', $" {ProcessInfo.Check}"));
            ProcessInfo.aliveInstance.Invoke(acd);

            if (!isParallel)
            {
                foreach (var item in NewFiles)
                {
                    CopyFile(Path, item._file, ExportationPath);
                    writer.WriteLine($"F({System.IO.Path.GetFileName(item._file)})");
                    files++;
                    ProcessInfo.aliveInstance.Invoke(acf);
                }
            }

            else
            {
                Parallel.ForEach(NewFiles, (item) =>
                {
                    CopyFile(Path, item._file, ExportationPath);
                    writer.WriteLine($"F({System.IO.Path.GetFileName(item._file)})");
                    files++;
                    ProcessInfo.aliveInstance.Invoke(acf);
                });
            }

            acd = new Action(() => ProcessInfo.aliveInstance.AddLT('F', $" {ProcessInfo.Check}"));
            ProcessInfo.aliveInstance.Invoke(acd);

            writer.WriteLine($"Custom Log [ {customLog} ]");

            writer.Flush();
            writer.Close();
            writer.Dispose();
            MessageBox.Show("NEW VERSION IS READY!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Action ps = new Action(() => ProcessInfo.aliveInstance.ChangeLT('T', "Compressing Files"));
            ProcessInfo.aliveInstance.Invoke(ps);

            ZipFiles(ExportationPath, Version);

            MessageBox.Show("Compression has been successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            ProcessInfo.aliveInstance.Invoke(acv);
            return true;
        }

        public static void ZipFiles(string Path, string Version)
        {
            try
            {
                ZipFile.CreateFromDirectory(Path, $"{Application.StartupPath}\\{Version}.ACPSM", CompressionLevel.Optimal, false);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public static void Import(string ProjectPath, string ExtractionPath, string PSMFile, bool PAP)
        {
            if (PAP)
            {
                Copy(ProjectPath, ExtractionPath);
            }

            UnZipFile(PSMFile, ExtractionPath);
        }

        public static void UnZipFile(string Path, string ExtractionPath)
        {
            string generatedP = string.Empty;
            for (int i = 0; i < 12; i++)
            {
                generatedP += GenPC[rand.Next(0, GenPC.Length)];
            }
            try
            {
                ZipFile.ExtractToDirectory(Path, TempPath + generatedP);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            MoveFilesToBase(TempPath + generatedP, ExtractionPath);
        }

        public static async void MoveFilesToBase(string ExPath, string ExtractionPath)
        {
            try
            {
                await CopyAsync(ExPath, ExtractionPath, "destination", "new");
                Directory.Delete(ExPath, true);
                ProcessInfo.aliveInstance.Invoke(acv);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            GC.Collect();

            MessageBox.Show("Importation has been successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}