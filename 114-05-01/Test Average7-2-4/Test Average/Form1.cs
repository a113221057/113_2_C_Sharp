using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Test_Average
{
    public partial class Form1 : Form
    {
        private List<int> testScores = new List<int>(); // 動態存儲分數

        public Form1()
        {
            InitializeComponent();
            this.Text = "測試平均";
            getScoresButton.Text = "取得分數";
            exitButton.Text = "退出";
        }

        // Average 方法接受一個整數陣列參數，並返回該陣列中所有值的平均值。
        private double Average(int[] scores)
        {
            int total = 0;
            foreach (int score in scores)
            {
                total += score;
            }
            return (double)total / scores.Length; // 使用 Length 屬性
        }

        // Highest 方法接受一個整數陣列參數，並返回該陣列中的最大值。
        private int Highest(int[] scores)
        {
            int highest = scores[0]; // 假設第一個元素為最高分數
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] > highest)
                {
                    highest = scores[i];
                }
            }
            return highest;
        }

        // Lowest 方法接受一個整數陣列參數，並返回該陣列中的最小值。
        private int Lowest(int[] scores)
        {
            int lowest = scores[0]; // 假設第一個元素為最低分數
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] < lowest)
                {
                    lowest = scores[i]; // 更新最低分數
                }
            }
            return lowest;
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            testScores.Clear(); // 清空之前的分數
            testScoresListBox.Items.Clear(); // 清空 ListBox

            StreamReader inputFile; // 定義 StreamReader 物件以讀取檔案

            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // 開啟檔案
                    inputFile = File.OpenText(openFile.FileName);

                    // 從檔案中讀取分數
                    while (!inputFile.EndOfStream)
                    {
                        string line = inputFile.ReadLine();
                        if (int.TryParse(line, out int score)) // 驗證是否為有效整數
                        {
                            testScores.Add(score);
                            testScoresListBox.Items.Add(score); // 將分數添加到 ListBox
                        }
                        else
                        {
                            MessageBox.Show($"無效的分數: {line}", "錯誤"); // 顯示無效分數訊息
                        }
                    }

                    // 關閉檔案
                    inputFile.Close();

                    // 更新分數顯示
                    UpdateScoreLabels();
                }
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息
                MessageBox.Show(ex.Message, "錯誤");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // 確認是否有選中的項目
            if (testScoresListBox.SelectedIndex != -1)
            {
                // 取得選中的索引
                int selectedIndex = testScoresListBox.SelectedIndex;

                // 從 testScores 列表中移除對應的項目
                int scoreToRemove = testScores[selectedIndex];
                testScores.RemoveAt(selectedIndex);

                // 從 testScoresListBox 中移除選中的項目
                testScoresListBox.Items.RemoveAt(selectedIndex);

                // 同步刪除 SortScoresListBox1 中的對應項目
                for (int i = 0; i < SortScoresListBox1.Items.Count; i++)
                {
                    if ((int)SortScoresListBox1.Items[i] == scoreToRemove)
                    {
                        SortScoresListBox1.Items.RemoveAt(i);
                        break; // 確保只刪除第一個匹配的項目
                    }
                }

                // 更新分數顯示
                UpdateScoreLabels();
            }
            else
            {
                // 如果沒有選中任何項目，顯示提示訊息
                MessageBox.Show("請選擇要刪除的項目！", "提示");
            }
        }

        private void sortScoresButton_Click(object sender, EventArgs e)
        {
            // 確保 testScores 不為空
            if (testScores.Count == 0)
            {
                MessageBox.Show("目前沒有分數可供排序！", "提示");
                return;
            }

            // 將 testScores 列表中的分數進行由高到低排序
            var sortedScores = testScores.OrderByDescending(score => score).ToList();

            // 清空 SortScoresListBox1 並重新填充排序後的分數
            SortScoresListBox1.Items.Clear();
            foreach (var score in sortedScores)
            {
                SortScoresListBox1.Items.Add(score);
            }
        }

        private void UpdateScoreLabels()
        {
            if (testScores.Count > 0)
            {
                int[] scoresArray = testScores.ToArray();
                averageScoreLabel.Text = Average(scoresArray).ToString("F1");
                highestScoreLabel.Text = Highest(scoresArray).ToString();
                lowestScoreLabel.Text = Lowest(scoresArray).ToString();
            }
            else
            {
                // 如果列表為空，清空所有分數的顯示
                averageScoreLabel.Text = string.Empty;
                highestScoreLabel.Text = string.Empty;
                lowestScoreLabel.Text = string.Empty;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            try
            {
                // 從 textBox1 取得要插入的數字
                int scoreToInsert = int.Parse(textBox1.Text);

                // 從 textBox2 取得插入的位置
                int position = int.Parse(textBox2.Text);

                // 檢查插入位置是否有效
                if (position < 0 || position > testScores.Count)
                {
                    MessageBox.Show("插入位置無效！", "錯誤");
                    return;
                }

                // 插入數字到 testScores
                testScores.Insert(position, scoreToInsert);

                // 更新 testScoresListBox，顯示插入後的結果
                testScoresListBox.Items.Clear();
                foreach (int score in testScores)
                {
                    testScoresListBox.Items.Add(score);
                }

               
            }
            catch (FormatException)
            {
                MessageBox.Show("請輸入有效的數字！", "錯誤");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"插入失敗: {ex.Message}", "錯誤");
            }
        }
    }
}
