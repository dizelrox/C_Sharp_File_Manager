using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    class Operation
    {

        

        public void DeleteDirectory(DirectoryInfo deleteFrom, string name)
        {

            RecursiveDeletion(Path.Combine(deleteFrom.ToString(), name));

        }

        public void CreateDirectory(String path)
        {
            Directory.CreateDirectory(path);
        }

        public void CopyFileToDirectory(FileInfo fileToCopy, DirectoryInfo targetDir)
        {
            
            File.Copy(Path.GetFullPath(fileToCopy.FullName), Path.Combine(targetDir.FullName, fileToCopy.Name));
        }

        public void MoveFileToDirectory(FileInfo fileToCopy, DirectoryInfo targetDir)
        {
            File.Move(Path.GetFullPath(fileToCopy.FullName), Path.Combine(targetDir.FullName, fileToCopy.Name));
        }

        public bool IsFileContentEqual(FileInfo file1, FileInfo file2)
        {

                byte[] fileInBytes1 = File.ReadAllBytes(file1.FullName);
                byte[] fileInBytes2 = File.ReadAllBytes(file2.FullName);

                if (fileInBytes1.Length == fileInBytes2.Length)
                {
                    for (int i = 0; i < file1.Length; i++)
                    {
                        if (fileInBytes1[i] != fileInBytes2[i])
                        {
                            return false;
                        }
                    }
                    return true;
                }
            return false;
        }
        

        public bool AreDirectoriesEqual(DirectoryInfo dir1, DirectoryInfo dir2)
        {
            return new DirCompare().DirEquals(dir1, dir2);
        }


        

        public void DeleteFile(DirectoryInfo deleteFrom, string name)
        {
            File.Delete(Path.Combine(deleteFrom.ToString(), name));
        }


        private static void RecursiveDeletion(string path)
        {
            foreach (string thisPath in Directory.GetDirectories(path))
            {
                RecursiveDeletion(thisPath);
            }

            foreach (string filename in Directory.GetFiles(path))
                File.Delete(Path.GetFullPath(filename));


            Directory.Delete(Path.GetFullPath(path));

        }

        public static List<string> Search(string searchValue, DirectoryInfo directory, ListBox resultsListBox)
        {
            var resultsList = new List<string>();

            if (!IsDirectoryAccessable(directory.ToString()))
                return new List<string>();


            foreach (string directoryIn in Directory.GetDirectories(Path.GetFullPath(directory.ToString())))
            {

                

                DirectoryInfo innerDirectory = new DirectoryInfo(Path.Combine(directory.ToString(), directoryIn));

                
                if (String.Equals(searchValue, innerDirectory.Name, StringComparison.CurrentCultureIgnoreCase))
                {
                    resultsList.Add(Path.Combine(directory.ToString(), directoryIn));
                }

                resultsList.AddRange( Search(searchValue, innerDirectory, resultsListBox) ); //recursive function
            }

            foreach (string fileIn in Directory.GetFiles(Path.GetFullPath(directory.ToString())))
            {
              

                if (String.Equals(searchValue, Path.GetFileNameWithoutExtension(fileIn), StringComparison.CurrentCultureIgnoreCase) 
                    || String.Equals(searchValue, Path.GetFileName(fileIn), StringComparison.CurrentCultureIgnoreCase))
                {
                    resultsList.Add( Path.Combine(directory.ToString(), fileIn) );
                    
                }              
            }

            return resultsList;
        }

        public static bool IsDirectoryAccessable(string directory)
        {

            try
            {
                Directory.GetDirectories(directory); //no other way to check access permissions ;( so much overhead...
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            
            
        }

        public static List<FileSystemInfo> FilterItems(string fullPath)
        {
            var filterValue = fullPath.Substring(fullPath.LastIndexOf("\\")+1);
            var currentPath = fullPath.Remove(fullPath.LastIndexOf("\\"));

            List<FileSystemInfo> itemsFound = new List<FileSystemInfo>();

            itemsFound.AddRange(new DirectoryInfo(currentPath).GetDirectories(filterValue, SearchOption.TopDirectoryOnly));
            itemsFound.AddRange(new DirectoryInfo(currentPath).GetFiles(filterValue, SearchOption.TopDirectoryOnly));

            return itemsFound;
        }


        private class DirCompare //Inner class only for directory comparison
        {

            public bool DirEquals(DirectoryInfo dir1, DirectoryInfo dir2)
            {
                if (dir1 == null || dir2 == null)
                    return false;

                if ((dir1.GetFiles().Length != dir2.GetFiles().Length) || (dir1.GetDirectories().Length != dir2.GetDirectories().Length))
                    return false;

                for (int i = 0; i < dir1.GetFiles().Length; i++)
                {
                    if (FileEquals(dir1.GetFiles()[i], dir2.GetFiles()[i]) == false)
                        return false;
                }

                for (int i = 0; i < dir1.GetDirectories().Length; i++)
                {
                    if (DirEquals(dir1.GetDirectories()[i], dir2.GetDirectories()[i]) == false)
                        return false;
                }

                return true;
            }

            public bool FileEquals(FileInfo file1, FileInfo file2)
            {
                return (file1.Name == file2.Name && file1.Length == file2.Length);
            }

        }
    }
}
