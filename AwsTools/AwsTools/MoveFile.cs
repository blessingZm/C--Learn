﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace AwsTools
{
    public class MoveFile
    {
        public void Create_Path(String pathname)
        {
            if (!Directory.Exists(pathname))
            {
                Directory.CreateDirectory(pathname);
            }
        }

        // 文件或文件夹复制
        public void Move_File(String origin_file, String targit_dir)
        {
            if (Directory.Exists(origin_file))
            {
                String end_dir = Path.Combine(targit_dir, Path.GetFileNameWithoutExtension(origin_file));
                Create_Path(end_dir);
                String[] buf_dirs = Directory.GetDirectories(origin_file);
                String[] buf_files = Directory.GetFiles(origin_file);
                if (buf_dirs.Length > 0)
                {
                    foreach (String d in buf_dirs)
                    {
                        Move_File(d, end_dir);
                    }
                }
                if (buf_files.Length > 0)
                {
                    foreach (String s in buf_files)
                    {
                        Move_File(s, end_dir);
                    }
                }
            }
            else
            {
                File.Copy(origin_file, Path.Combine(targit_dir, Path.GetFileName(origin_file)), true);
            }
        }
    }
}
