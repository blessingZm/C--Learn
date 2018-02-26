using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using StaElemStatAPI;

namespace APP1
{
    public partial class Form1 : Form
    {
        public String interfaceId = "getSurfEleByTimeRangeAndStaID";

        public const String CONFIGPATH = @".\Config";
        public Dictionary<string, string> DATATYPES = new Dictionary<string, string>
        {
            { "地面逐小时资料", "HOUR.ini,SURF_CHN_MUL_HOR,yyyy-MM-dd HH" },
            { "地面日值资料", "DAY.ini,SURF_CHN_MUL_DAY,yyyy-MM-dd" },
            { "地面月值资料", "MONTH.ini,SURF_CHN_MUL_MON,yyyy-MM" },
            { "地面年值资料", "YEAR.ini,SURF_CHN_MUL_YER,yyyy" }
            };       
        public Dictionary<string, string> ElemntDict = new Dictionary<string, string>();
        public static String exePath = Environment.CurrentDirectory;
        public static String resultPath = exePath + @"\results";

    public Form1()
        {
            // 各控件值初始化
            InitializeComponent();
            DateTime NOW = DateTime.Now;
            StartdateTime.Value = NOW;
            EnddateTime.Value = NOW;
            StartdateTime.MaxDate = NOW;
            EnddateTime.MaxDate = NOW;

            DatasSelect.SelectedIndex = 0;
            StidSelect.Items.Clear();
            ElemntDict = GetElements(DATATYPES[DatasSelect.Text]);
            StartdateTime.CustomFormat = "yyyy-MM-dd HH";
            EnddateTime.CustomFormat = "yyyy-MM-dd HH";
            if (!Directory.Exists(resultPath))
            {
                //创建路径
                Directory.CreateDirectory(resultPath);
            }
            ResultsPath.Text = resultPath;

            String STFILE = Path.Combine(CONFIGPATH, "STID.ini");
            StreamReader sr = new StreamReader(STFILE, Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                StidSelect.Items.Add(line.ToString());
            }
        }

        private Dictionary<string, string> GetElements(String datatypeOfConfig)
        {
            ElementsSelect.Items.Clear();
            String iniFile = datatypeOfConfig.Split(',')[0];
            String elemFile = Path.Combine(CONFIGPATH, iniFile);
            Dictionary<string, string> elemDict = new Dictionary<string, string>();
            StreamReader sr = new StreamReader(elemFile, Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                line = line.Trim();
                string[] elem = Regex.Split(line, "\\s+", RegexOptions.IgnoreCase);
                elemDict.Add(elem[1], elem[0]);
                ElementsSelect.Items.Add(elem[1].ToString());
            }
            return elemDict;
        }

        private void DatasSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ElemntDict = GetElements(DATATYPES[DatasSelect.Text]);
            StartdateTime.CustomFormat = DATATYPES[DatasSelect.Text].Split(',')[2];
            EnddateTime.CustomFormat = DATATYPES[DatasSelect.Text].Split(',')[2];
        }

        public String MyChangeDatetime(string mydate)
        {
            String result_datetime;
            String buf_datetime;
            switch (mydate.Length)
            {
                case 10:
                case 8:
                    buf_datetime = mydate;
                    break;
                case 6:
                    buf_datetime = mydate + "01";
                    break;
                case 4:
                    buf_datetime = mydate + "0101";
                    break;
                default:
                    buf_datetime = mydate;
                    break;
            }
            result_datetime = buf_datetime.PadRight(14, '0');
            return result_datetime;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // 取出要下载的要素，组合成字符串
            ArrayList elements = new ArrayList
            {
                "Station_ID_C"
            };
            for (int i = 0; i < ElementsSelect.Items.Count; i++)
            { if (ElementsSelect.GetItemChecked(i))
                {
                    elements.Add(ElemntDict[ElementsSelect.Items[i].ToString()]);
                }
            }
            String elemStr = String.Join(",", (String[])elements.ToArray(typeof(string)));

            // 取区站号列表
            ArrayList stids = new ArrayList();
            for (int i = 0; i < StidSelect.Items.Count; i++)
            {
                if (StidSelect.GetItemChecked(i))
                {
                    stids.Add(StidSelect.Items[i].ToString());
                }
            }
            if (stids.Count == 0)
            {
                MessageBox.Show("未选择区站号", "错误提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 取出资料接口
            String dataCode = DATATYPES[DatasSelect.Text].Split(',')[1];

            // 取起止时间
            String datetimeForm = StartdateTime.CustomFormat;
            datetimeForm = String.Join("", Regex.Split(datetimeForm, "[- ]"));
            DateTime SDt = StartdateTime.Value;
            DateTime EDt = EnddateTime.Value;
            String startDt = MyChangeDatetime(SDt.ToString(datetimeForm));
            String endDt = MyChangeDatetime(EDt.ToString(datetimeForm));
            if (String.Compare(startDt, endDt) > 0)
            {
                MessageBox.Show("开始时间大于结束时间", "错误提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 调用进度条展示下载进度
            PBar pb = new PBar(0, stids.Count);
            pb.Show(this);
            // 开始调用CIMISS 并下载数据
            SaveAsFile_TEXT cimiss_api = new SaveAsFile_TEXT();
            String resultMessage = "";
            for (int i = 0; i < stids.Count; i++)
            {
                String stid = stids[i].ToString();
                pb.Set_pos(i, String.Format("正在下载{0}站数据......", stid));
                String filename = String.Format("{0}_{1}-{2}_{3}.txt",
                    stid, startDt, endDt, DatasSelect.Text);
                resultMessage = cimiss_api.GetResults(interfaceId, dataCode, elemStr, 
                    startDt, endDt, stid, Path.Combine(ResultsPath.Text, filename));
                if (resultMessage.IndexOf("失败") > -1)
                {
                    MessageBox.Show(resultMessage, "提示", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            pb.Close(); //关闭进度条
            MessageBox.Show("所有资料下载完成", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            foreach (int i in ElementsSelect.CheckedIndices)
            {
                ElementsSelect.SetItemChecked(i, false);
            }

            foreach (int i in StidSelect.CheckedIndices)
            {
                StidSelect.SetItemChecked(i, false);
            }
        }

        // 结果保存路径设置
        private void Button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog P_File_Folder = new FolderBrowserDialog
            {
                SelectedPath = resultPath
            };
            if (P_File_Folder.ShowDialog() == DialogResult.OK)
            {
                ResultsPath.Text = P_File_Folder.SelectedPath;
            }
        }

        public String Get_datatype()
        {
            return DatasSelect.Text;
        }

    }
}
