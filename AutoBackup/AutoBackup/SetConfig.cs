using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace AutoBackup
{
    public partial class SetConfig : Form
    {
        String xmlFile = @".\Config\BackupConfig.xml";
        public SetConfig()
        {
            InitializeComponent();
        }

        private void SetConfig_Load(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlFile);

            XmlNodeList rateNode = xmldoc.GetElementsByTagName("Rate");
            String rateValue = rateNode[0].Attributes[0].Value;
            if (rateValue == "Hour")
            {
                SelectHour.Select();
            }
            else if (rateValue == "Day")
            {
                SelectDay.Select();
            }

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

        private void SaveConfig_Click(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlFile);

            XmlNodeList rateConfig = xmldoc.GetElementsByTagName("RateParameters");
            XmlNodeList origiConfig = xmldoc.GetElementsByTagName("OrigiParameters");
            XmlNodeList targitConfig = xmldoc.GetElementsByTagName("TargitParameters");
            rateConfig[0].RemoveAll();
            origiConfig[0].RemoveAll();
            targitConfig[0].RemoveAll();

            XmlElement rateNode = xmldoc.CreateElement("Rate");
            if (SelectHour.Checked)
            {
                rateNode.SetAttribute("Time", "Hour");
            }
            else if(SelectDay.Checked)
            {
                rateNode.SetAttribute("Time", "Day");
            }
            rateConfig[0].AppendChild(rateNode);

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
            MessageBox.Show("参数已更改，请重启程序生效！", "警告",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            this.Close();
            ActiveForm.Close();
        }

        private void OrigiFileSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
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
    }
}
