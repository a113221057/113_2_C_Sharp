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

namespace CSV_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader inputFile;
                string line;// 儲存讀取的每一行資料
                int count = 0;// 計算行數
                int total = 0;// 計算總分
                double average = 0;// 計算平均分數


                char[]delim = {',',':'};
                // 顯示檔案選擇對話方塊，讓使用者選擇要開啟的 CSV 檔案
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // 開啟使用者選擇的檔案進行讀取
                    inputFile = File.OpenText(openFile.FileName);
                   
                    while (!inputFile.EndOfStream)
                    {
                        // 讀取每一行資料
                        line = inputFile.ReadLine();
                        line = line.Trim(); // 去除行首行尾的空白字元
                        string[] tokens= line.Split(delim); 
                        total = 0; // 每次讀取新行時，重置總分為 0
                        for (int i = 1; i < tokens.Length; i++)
                        {
                            // 將字串轉換為整數並累加到總分中
                            total +=  int.Parse(tokens[i]);
                        }
                        average = (double)total /( tokens.Length -1);
                        averagesListBox.Items.Add("第" + (++count) + "的平均分數為：" + average.ToString("F2"));
                    }
                }
                else
                {
                    // 若使用者未選擇檔案，顯示提示訊息
                    MessageBox.Show("未選擇任何檔案。");
                }
            }
            catch (Exception ex)
            {
                // 發生例外狀況時，顯示錯誤訊息與詳細內容
                MessageBox.Show("發生錯誤：" + ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉視窗並結束程式
            this.Close();
        }
    }
}
