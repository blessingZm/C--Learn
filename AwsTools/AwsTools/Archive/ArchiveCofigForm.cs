using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace AwsTools.Archive
{
    public partial class ArchiveCofigForm : Form
    {
        String xmlFile = @".\Config\ArchiveConfig.xml";
        public ArchiveCofigForm()
        {
            InitializeComponent();  
        }

        private void AWSPATHSELECT_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog P_File_Folder = new FolderBrowserDialog
            {
                SelectedPath = @"D:\"
            };
            if (P_File_Folder.ShowDialog() == DialogResult.OK)
            {
                AWSPATH.Text = P_File_Folder.SelectedPath;
            }
        }

        private void AWSNETPATHSELECT_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog P_File_Folder = new FolderBrowserDialog
            {
                SelectedPath = @"D:\"
            };
            if (P_File_Folder.ShowDialog() == DialogResult.OK)
            {
                AWSNETPATH.Text = P_File_Folder.SelectedPath;
            }
        }

        private void DIGITPATHSELECT_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog P_File_Folder = new FolderBrowserDialog
            {
                SelectedPath = @"D:\"
            };
            if (P_File_Folder.ShowDialog() == DialogResult.OK)
            {
                DIGITPATH.Text = P_File_Folder.SelectedPath;
            }
        }

        private void ArchiveCofigForm_Load(object sender, EventArgs e)
        { 
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlFile);

            XmlNodeList basicConfig = xmldoc.GetElementsByTagName("Basic");
            STID.Text = basicConfig[0].Attributes[0].Value;
            AWSPATH.Text = basicConfig[0].Attributes[1].Value;
            AWSNETPATH.Text = basicConfig[0].Attributes[2].Value;
            DIGITPATH.Text = basicConfig[0].Attributes[3].Value;

            XmlNodeList fileConfig = xmldoc.GetElementsByTagName("Parameter");
            for (int i = 0; i < fileConfig.Count; i++)
            {
                ARCHIVELISTS.RowCount += 1;
                for (int j = 0; j < fileConfig[i].Attributes.Count; j++)
                {
                    ARCHIVELISTS[j, i].Value = fileConfig[i].Attributes[j].Value;
                }
            }

        }

        private void Save_config_Click(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlFile);

            // 修改基本参数部分
            XmlNodeList basicConfig = xmldoc.GetElementsByTagName("Basic");
            XmlElement xe = (XmlElement)basicConfig[0];
            xe.SetAttribute("StationId", STID.Text);
            xe.SetAttribute("AwsPath", AWSPATH.Text);
            xe.SetAttribute("AwsnetPath", AWSNETPATH.Text);
            xe.SetAttribute("DigitPath", DIGITPATH.Text);

            // 修改文件列表参数部分
            XmlNodeList fileNodes = xmldoc.GetElementsByTagName("FileParameters");
            // 首先清除所有原有的文件列表参数
            fileNodes[0].RemoveAll();
            // 重新写入文件列表参数
            for (int i = 0; i < ARCHIVELISTS.RowCount; i++)
            {
                XmlElement newNode = xmldoc.CreateElement("Parameter");
                try
                {
                    newNode.SetAttribute("FileState", ARCHIVELISTS[0, i].Value.ToString());
                    newNode.SetAttribute("FileType", ARCHIVELISTS[1, i].Value.ToString());
                    newNode.SetAttribute("FilenameMatchMode", ARCHIVELISTS[2, i].Value.ToString());
                    newNode.SetAttribute("FileDir", ARCHIVELISTS[3, i].Value.ToString());
                    fileNodes[0].AppendChild(newNode);
                }
                catch
                {
                    continue;
                }

            }
            xmldoc.Save(xmlFile);
            MessageBox.Show("参数设置成功", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
