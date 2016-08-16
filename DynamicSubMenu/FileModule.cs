using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DynamicSubMenus
{
    public static class FileModule
    {
        public static void TouchFile(string path)
        { }

        public static string GetUniqueFileName(string path)
        {
            return GetUniqueFilename(GetDirPathOnly(path), Path.GetFileName(path));
        }

        public static string GetUniqueFilename(string filepath, string filename, string defaultExtension = null)
        {
            int fileCounter = 0;

            string name = filename;
            string ext = string.Empty;

            if (filename.LastIndexOf(".") > 1)
            {
                name = filename.Substring(0, filename.LastIndexOf("."));
                ext = filename.Substring(filename.LastIndexOf(".") + 1);
            }

            if (string.IsNullOrEmpty(ext) && defaultExtension != null)
                ext = defaultExtension;

            string newName = name + "." + ext;
            while (System.IO.File.Exists(filepath + @"\" + newName))
            {
                string tname = name + "_" + fileCounter.ToString().PadLeft(4, '0');
                newName = tname + "." + ext;
                fileCounter++;
            }

            return filepath + @"\" + newName;
        }

        public static void EnsureFilePath(string filePath)
        {
            string dirPath = GetDirPathOnly(filePath);
            System.IO.Directory.CreateDirectory(dirPath);
        }

        public static string GetDirPathOnly(string filePath)
        {
            return Path.GetFullPath(filePath).Replace(Path.GetFileName(filePath), "");
        }

        public static bool IsImage(string path)
        {
            return true;
        }

    }
}
