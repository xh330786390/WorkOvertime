using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkOvertime.Files;

namespace WorkOvertime
{
    public partial class FormMain : Form
    {
        private string filePath = string.Empty;
        private string basePath = System.AppDomain.CurrentDomain.BaseDirectory;

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnProduce_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("请选择考勤记录文件");
                return;
            }
            if (!File.Exists(filePath))
            {
                MessageBox.Show("您选择的考勤文件不存在，请重新选择");
                return;
            }
            Dictionary<string, ResultModel> dict = new Dictionary<string, ResultModel>();

            ExcelFile file = new ExcelFile();

            List<RecodeModel> list = file.Read(filePath, this.comboBox1.Text);
            if (list != null && list.Count > 0)
            {
                var names = list.Where(l => !l.Name.Contains("离职")).GroupBy(l => l.Name).Select(l => l.Key).ToList();
                names.ForEach(l =>
                {
                    dict.Add(l, new ResultModel() { Name = l, money = 15 });
                });
            }

            string strDate = DateTime.Now.ToString("yyyy-MM-dd ");
            foreach (RecodeModel item in list)
            {
                if (dict.ContainsKey(item.Name))
                {
                    if (string.IsNullOrEmpty(item.StartTime) || string.IsNullOrEmpty(item.EndTime)) continue;
                    ResultModel model = dict[item.Name];
                    string strStartTime = string.Empty;
                    string strEndTime = strDate + item.EndTime + ":00";
                    if (item.Week.Contains("星期六") || item.Week.Contains("星期日"))
                    {
                        if (!string.IsNullOrEmpty(item.StartTime) && !string.IsNullOrEmpty(item.EndTime))
                        {
                            strStartTime = strDate + item.StartTime + ":00";
                            strEndTime = strDate + item.EndTime + ":00";

                            DateTime startDate = DateTime.Parse(strStartTime);
                            DateTime endDate = DateTime.Parse(strEndTime);

                            TimeSpan span = endDate - startDate;

                            if (span.Hours >= 8)
                            {
                                model.Day = model.Day + 1;
                                model.Num = model.Num + 2;
                            }
                        }
                    }
                    else if (DateTime.Parse(strEndTime).Hour >= 21)
                    {
                        model.Day = model.Day + 1;
                        model.Num = model.Num + 1;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            if (dict.Count > 0)
            {
                string init = "姓名".PadRight(6, ' ') + "加班天数".PadRight(7, ' ') + "餐补数".PadRight(8, ' ') + "餐费".PadRight(7, ' ') + "餐补费用";
                sb.AppendLine(init);

                var result = dict.Values.ToList().OrderByDescending(l => l.Num).ToList();
                foreach (ResultModel item in result)
                {
                    string str = "";
                    if (item.Name.Length == 3)
                    {
                        str = item.Name.PadRight(8, ' ');
                    }
                    else
                    {
                        str = item.Name.PadRight(9, ' ');
                    }

                    str = str + item.Day.ToString().PadRight(10, ' ') + item.Num.ToString().PadRight(10, ' ') + item.money.ToString().PadRight(10, ' ') + (item.Num * item.money).ToString();
                    sb.AppendLine(str);
                }
            }
            string display = sb.ToString();
            if (string.IsNullOrEmpty(display))
            {
                this.richTextBox1.Text = "数据为空";
            }
            else
            {
                this.richTextBox1.Text = display;
            }
        }

        private void btnProjectPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Excle文件(*.xlsx)|*.xlsx|所有文件|*.xlsx";//设置文件类型
            dialog.InitialDirectory = filePath;
            try
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.txtExcelPath.Text = dialog.FileName;
                    filePath = this.txtExcelPath.Text;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = 0;
        }
    }
}
