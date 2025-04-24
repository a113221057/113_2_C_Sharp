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
            return (double)total / scores.Length; // 修正為使用 Length 屬性
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
            List<int> testScores = new List<int>(); // 使用 List<int> 動態存儲分數
            int highestScore = 0; // 初始化最高分數變數
            int lowestScore = 0; // 初始化最低分數變數
            double averageScore = 0.0; // 初始化平均分數變數
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

                    // 將 List<int> 轉換為陣列
                    int[] scoresArray = testScores.ToArray();

                    // 計算平均分數、最高分數和最低分數
                    averageScore = Average(scoresArray);
                    highestScore = Highest(scoresArray);
                    lowestScore = Lowest(scoresArray);

                    // 顯示結果
                    averageScoreLabel.Text = averageScore.ToString("F1");
                    highestScoreLabel.Text = highestScore.ToString();
                    lowestScoreLabel.Text = lowestScore.ToString();
                }
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息
                MessageBox.Show(ex.Message, "錯誤");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }
    }
}
