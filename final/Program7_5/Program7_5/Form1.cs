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
        public Form1()
        {
            InitializeComponent();
        }

        // 使用 List<string> 來儲存球隊名稱
        List<string> teamList = new List<string>();
        // 使用 List<string> 來儲存每年冠軍球隊名稱
        List<string> winnerList = new List<string>();

        /// <summary>
        /// 表單載入事件，初始化並讀取球隊與冠軍資料
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // 顯示提示訊息，提醒使用者需選擇球隊資料檔案
            MessageBox.Show(
                "請先選擇球隊資料檔案。\n",
                "檔案選擇提醒",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            readTeams();

            // 顯示提示訊息，提醒使用者需選擇世界冠軍檔案
            MessageBox.Show(
                "請選擇世界冠軍檔案。\n",
                "檔案選擇提醒",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            readWinner();
        }

        /// <summary>
        /// 透過對話方塊選擇 Teams.txt 檔案，將所有球隊名稱加入 listBox1 並存入 teamList
        /// </summary>
        private void readTeams()
        {
            try
            {
                teamList.Clear();
                listBox1.Items.Clear();

                // 建立開啟檔案對話方塊，讓使用者選擇 Teams.txt
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "請選擇球隊資料檔案 (Teams.txt)";
                    openFileDialog.Filter = "文字檔案 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
                    openFileDialog.FileName = "Teams.txt";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamReader inputFile = File.OpenText(openFileDialog.FileName))
                        {
                            string line;
                            // 逐行讀取球隊名稱，加入 teamList 及 listBox1
                            while ((line = inputFile.ReadLine()) != null)
                            {
                                teamList.Add(line);
                                listBox1.Items.Add(line);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("未選擇球隊資料檔案，無法載入球隊資料。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // 若發生例外，顯示錯誤訊息（以繁體中文顯示）
                MessageBox.Show("讀取球隊資料時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 透過對話方塊選擇 WorldSeries.txt 檔案，將每年冠軍球隊名稱存入 winnerList
        /// </summary>
        private void readWinner()
        {
            try
            {
                winnerList.Clear();

                // 建立開啟檔案對話方塊，讓使用者選擇 WorldSeries.txt
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "請選擇冠軍資料檔案 (WorldSeries.txt)";
                    openFileDialog.Filter = "文字檔案 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
                    openFileDialog.FileName = "WorldSeries.txt";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamReader inputFile = File.OpenText(openFileDialog.FileName))
                        {
                            string line;
                            // 逐行讀取冠軍球隊名稱，加入 winnerList
                            while ((line = inputFile.ReadLine()) != null)
                            {
                                winnerList.Add(line);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("未選擇冠軍資料檔案，無法載入冠軍資料。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // 若發生例外，顯示錯誤訊息（以繁體中文顯示）
                MessageBox.Show("讀取冠軍資料時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                // 計算目前對應的年份
                year = startYear + i;
                if (year == 1904 || year == 1994)
                {
                    // 1904 與 1994 沒有世界大賽，跳過這一年
                    year++;
                }
                if (i < winnerList.Count && str == winnerList[i])
                {
                    numWin++;
                    winYears.Add(year);
                }
            }

            // 組合奪冠年份字串
            string yearsText = winYears.Count > 0
                ? "\n奪冠年份：" + string.Join("、", winYears) + " 年"
                : "\n無奪冠紀錄。";

            // 以繁體中文顯示結果
            label1.Text = str + " 從 1903 年到 2009 年共獲得 " + numWin + " 次世界大賽冠軍。" + yearsText;
        }
    }
}
