using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Array_To_File
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 建立一個包含一些值的陣列。
                //陳列大小設定為5
                int[] numbers = { 10, 20, 30, 40, 50 };

                // 宣告一個 StreamWriter 變數。
                StreamWriter inputFile;

                //檔案名稱為Values.txt
                // 建立檔案並取得 StreamWriter 物件。
                inputFile = File.CreateText("Values.txt");

                // 將陣列的內容寫入檔案。
               
                for (int index = 0; index < numbers.Length; index++)
                {
                    inputFile.WriteLine(numbers[index]);
                }

                // 關閉檔案。
                inputFile.Close();

                // 讓使用者知道已完成。
                MessageBox.Show("完成");
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息。
                MessageBox.Show(ex.Message);
            }
        }
    }
}
