using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using AwsTools;

namespace AwsTools.Backup
{
    public partial class BackupTool : Form
    {
        String xmlFile = @".\Config\BackupConfig.xml";
        public BackupTool()
        {
            InitializeComponent();
        }

        private void BackupTool_Load(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlFile);

            XmlNodeList origiConfig = xmldoc.GetElementsByTagName("Origi");
            for (int i = 0; i < origiConfig.Count; i++)
            {
                OrigiFileList.RowCount += 1;
                OrigiFileList[0, i].Value = origiConfig[i].Attributes[0].Value;
            }

            XmlNodeList digitConfig = xmldoc.GetElementsByTagName("Targit");
            for (int i = 0; i < digitConfig.Count; i++)
            {
                TargitDirList.RowCount += 1;
                TargitDirList[0, i].Value = digitConfig[i].Attributes[0].Value;
            }
        }

        private void OrigiFileSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Filter = "所有文件|*.*",
                RestoreDirectory = true,
                CheckPathExists = true,
                CheckFileExists = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                int index = OrigiFileList.Rows.Add();
                OrigiFileList[0, index].Value = openFileDialog.FileName;
            }
        }

        private void OrigiDirSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog P_File_Folder = new FolderBrowserDialog
            {
                SelectedPath = @"D:\"
            };
            if (P_File_Folder.ShowDialog() == DialogResult.OK)
            {
                int index = OrigiFileList.Rows.Add();
                OrigiFileList[0, index].Value = P_File_Folder.SelectedPath;
            }
        }

        private void TargitDirSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog P_File_Folder = new FolderBrowserDialog
            {
                SelectedPath = @"D:\"
            };
            if (P_File_Folder.ShowDialog() == DialogResult.OK)
            {
                int index = TargitDirList.Rows.Add();
                TargitDirList[0, index].Value = P_File_Folder.SelectedPath;
            }
        }

        private void BackupConfigSave_Click(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlFile);

            XmlNodeList origiConfig = xmldoc.GetElementsByTagName("OrigiParameters");
            XmlNodeList targitConfig = xmldoc.GetElementsByTagName("TargitParameters");
            origiConfig[0].RemoveAll();
            targitConfig[0].RemoveAll();

            for (int i = 0; i < OrigiFileList.RowCount; i++)
            {
                XmlElement newNode = xmldoc.CreateElement("Origi");
                try
                {
                    newNode.SetAttribute("File", OrigiFileList[0, i].Value.ToString());
                    origiConfig[0].AppendChild(newNode);
                }
                catch
                {
                    continue;
                }
            }

            for (int i = 0; i < TargitDirList.RowCount; i++)
            {
                XmlElement newNode = xmldoc.CreateElement("Targit");
                try
                {
                    newNode.SetAttribute("Dir", TargitDirList[0, i].Value.ToString());
                    targitConfig[0].AppendChild(newNode);
                }
                catch
                {
                    continue;
                }
            }
            xmldoc.Save(xmlFile);
            MessageBox.Show("参数保存成功", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void StartBackup_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("请确认参数修改后已保存或未修改？", "提示", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                MoveFile mf = new MoveFile();
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(xmlFile);

                XmlNodeList origiConfig = xmldoc.GetElementsByTagName("Origi");
                XmlNodeList targitConfig = xmldoc.GetElementsByTagName("Targit");

                PBar pb = new PBar(0, origiConfig.Count * targitConfig.Count);
                pb.Show(this);
                int pbnum = 0;
                for (int i = 0; i < targitConfig.Count; i++)
                {
                    for (int j = 0; j < origiConfig.Count; j++)
                    {
                        String oriFile = origiConfig[j].Attributes[0].Value;
                        String tarDir = targitConfig[i].Attributes[0].Value;
                        pb.Set_pos(pbnum, String.Format("备份:{0} ----至:{1}...", oriFile, tarDir));
                        mf.Move_File(oriFile, tarDir);
                        pbnum++;
                    }
                }
                pb.Close();
                MessageBox.Show("备份完成！", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }
    }
}
