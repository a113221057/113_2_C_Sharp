using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Program7_5
{
    public partial class Form1 : Form
    {
        // 使用 List<string> 來儲存球隊名稱
        List<string> teamList = new List<string>();
        // 使用 List<string> 來儲存每年冠軍球隊名稱
        List<string> winnerList = new List<string>();
        // 記錄球隊檔案與冠軍檔案的路徑
        string teamFilePath = "";
        string winnerFilePath = "";

        // 介面按鈕
        private Button btnAddData;
        private Button btnExit;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomButtons();
        }

        /// <summary>
        /// 初始化自訂按鈕
        /// </summary>
        private void InitializeCustomButtons()
        {
            // 新增資料按鈕
            btnAddData = new Button();
            btnAddData.Text = "新增資料";
            btnAddData.Location = new Point(20, 220);
            btnAddData.Size = new Size(100, 30);
            btnAddData.Click += BtnAddData_Click;
            this.Controls.Add(btnAddData);

            // 離開按鈕
            btnExit = new Button();
            btnExit.Text = "離開";
            btnExit.Location = new Point(140, 220);
            btnExit.Size = new Size(100, 30);
            btnExit.Click += BtnExit_Click;
            this.Controls.Add(btnExit);
        }

        /// <summary>
        /// 表單載入事件，初始化並讀取球隊與冠軍資料
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show(
                "請先選擇球隊資料檔案。\n",
                "檔案選擇提醒",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            readTeams();

            MessageBox.Show(
                "請選擇世界冠軍檔案。\n",
                "檔案選擇提醒",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            readWinner();
        }

        /// <summary>
        /// 讀取球隊資料檔案（不使用 using 關鍵字）
        /// </summary>
        private void readTeams()
        {
            teamList.Clear();
            listBox1.Items.Clear();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "請選擇球隊資料檔案 (Teams.txt)";
            openFileDialog.Filter = "文字檔案 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
            openFileDialog.FileName = "Teams.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                teamFilePath = openFileDialog.FileName;
                FileStream fs = null;
                StreamReader reader = null;
                try
                {
                    fs = new FileStream(teamFilePath, FileMode.Open, FileAccess.Read);
                    reader = new StreamReader(fs, Encoding.UTF8);
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        teamList.Add(line);
                        listBox1.Items.Add(line);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("讀取球隊資料時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (reader != null) reader.Close();
                    if (fs != null) fs.Close();
                }
            }
            else
            {
                MessageBox.Show("未選擇球隊資料檔案，無法載入球隊資料。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 讀取冠軍資料檔案（不使用 using 關鍵字）
        /// </summary>
        private void readWinner()
        {
            winnerList.Clear();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "請選擇冠軍資料檔案 (WorldSeries.txt)";
            openFileDialog.Filter = "文字檔案 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
            openFileDialog.FileName = "WorldSeries.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                winnerFilePath = openFileDialog.FileName;
                FileStream fs = null;
                StreamReader reader = null;
                try
                {
                    fs = new FileStream(winnerFilePath, FileMode.Open, FileAccess.Read);
                    reader = new StreamReader(fs, Encoding.UTF8);
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        winnerList.Add(line);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("讀取冠軍資料時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (reader != null) reader.Close();
                    if (fs != null) fs.Close();
                }
            }
            else
            {
                MessageBox.Show("未選擇冠軍資料檔案，無法載入冠軍資料。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 新增資料按鈕事件：讀取2010年以後的MLB冠軍資料並更新清單與介面
        /// </summary>
        private void BtnAddData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "請選擇2010年以後的世界冠軍資料檔案";
            openFileDialog.Filter = "文字檔案 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
            openFileDialog.FileName = "WorldSeries_2010up.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                StreamReader reader = null;
                try
                {
                    fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                    reader = new StreamReader(fs, Encoding.UTF8);
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        winnerList.Add(line);
                        // 若新球隊名稱不在 teamList，則加入 teamList 及 listBox1
                        if (!teamList.Contains(line))
                        {
                            teamList.Add(line);
                            listBox1.Items.Add(line);
                        }
                    }
                    MessageBox.Show("已成功新增2010年以後的世界冠軍資料！", "新增完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("新增資料時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (reader != null) reader.Close();
                    if (fs != null) fs.Close();
                }
            }
        }

        /// <summary>
        /// 離開按鈕事件：將資料存回原始檔案並結束程式
        /// </summary>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            // 儲存球隊資料
            if (!string.IsNullOrEmpty(teamFilePath))
            {
                FileStream fs = null;
                StreamWriter writer = null;
                try
                {
                    fs = new FileStream(teamFilePath, FileMode.Create, FileAccess.Write);
                    writer = new StreamWriter(fs, Encoding.UTF8);
                    foreach (string team in teamList)
                    {
                        writer.WriteLine(team);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("儲存球隊資料時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (writer != null) writer.Close();
                    if (fs != null) fs.Close();
                }
            }

            // 儲存冠軍資料
            if (!string.IsNullOrEmpty(winnerFilePath))
            {
                FileStream fs = null;
                StreamWriter writer = null;
                try
                {
                    fs = new FileStream(winnerFilePath, FileMode.Create, FileAccess.Write);
                    writer = new StreamWriter(fs, Encoding.UTF8);
                    foreach (string winner in winnerList)
                    {
                        writer.WriteLine(winner);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("儲存冠軍資料時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (writer != null) writer.Close();
                    if (fs != null) fs.Close();
                }
            }

            Application.Exit();
        }

        /// <summary>
        /// 當使用者在 listBox1 選取球隊時，計算該球隊奪冠次數並顯示於 label1，並列出奪冠年份
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = listBox1.SelectedItem.ToString();
            int numWin = 0;
            List<int> winYears = new List<int>();
            int startYear = 1903;
            int year = startYear;

            // MLB 世界大賽在 1904 與 1994 年未舉行，需跳過這兩年
            for (int i = 0; i < winnerList.Count; i++)
            {
                year = startYear + i;
                if (year == 1904 || year == 1994)
                {
                    year++;
                }
                if (i < winnerList.Count && str == winnerList[i])
                {
                    numWin++;
                    winYears.Add(year);
                }
            }

            string yearsText = winYears.Count > 0
                ? "\n奪冠年份：" + string.Join("、", winYears) + " 年"
                : "\n無奪冠紀錄。";

            label1.Text = str + " 從 1903 年到 2009 年共獲得 " + numWin + " 次世界大賽冠軍。" + yearsText;
        }
    }
}
