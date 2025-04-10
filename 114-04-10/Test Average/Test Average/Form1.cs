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
            return scores.Average();
        }

        // Highest 方法接受一個整數陣列參數，並返回該陣列中的最大值。
        private int Highest(int[] scores)
        {
        
            
            int highest = scores[0]; // 假設第一個元素為最高分數
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
            const int SIZE = 48; // 定義陣列大小為 48
            int[] testScores = new int[SIZE]; // 初始化整數陣列以存儲測試分數
            int index = 0; // 初始化索引變數
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
                    while (!inputFile.EndOfStream && index < SIZE)
                    {
                        testScores[index] = Convert.ToInt32(inputFile.ReadLine());
                        index++;
                    }

                    // 關閉檔案
                    inputFile.Close();

                    // 計算平均分數、最高分數和最低分數
                    averageScore = Average(testScores);
                    highestScore = Highest(testScores);
                    lowestScore = Lowest(testScores);

                    // 顯示結果
                    averageScoreLabel.Text =averageScore.ToString("F1");
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
