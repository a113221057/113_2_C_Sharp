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

namespace Phonebook
{
    // PhoneBookEntry 結構用來儲存每一筆電話簿資料，包括姓名與電話號碼
    struct PhoneBookEntry
    {
        public string name;   // 姓名
        public string phone;  // 電話號碼
    }

    public partial class Form1 : Form
    {
        // 用來儲存所有電話簿資料的 List
        private List<PhoneBookEntry> phoneList =
            new List<PhoneBookEntry>();

        public Form1()
        {
            InitializeComponent();
        }

        // ReadFile 方法會讀取 PhoneList.txt 檔案內容，
        // 並將每一筆資料轉換成 PhoneBookEntry 物件後存入 phoneList。
        // 檔案每一行格式為：姓名,電話號碼
        private void ReadFile()
        {
            try
            {
                // 檢查檔案是否存在
                if (File.Exists("PhoneList.txt"))
                {
                    // 讀取檔案的每一行
                    string[] lines = File.ReadAllLines("PhoneList.txt");

                    // 逐行處理
                    foreach (string line in lines)
                    {
                        // 分割姓名與電話號碼
                        string[] parts = line.Split(',');

                        // 確保格式正確
                        if (parts.Length == 2)
                        {
                            PhoneBookEntry entry;
                            entry.name = parts[0].Trim();
                            entry.phone = parts[1].Trim();

                            // 加入到 phoneList
                            phoneList.Add(entry);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("PhoneList.txt 檔案不存在。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"讀取檔案時發生錯誤: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // DisplayNames 方法會將 phoneList 中所有姓名顯示在 nameListBox 控制項中，
        // 讓使用者可以從清單中選擇要查詢的姓名。
        private void DisplayNames()
        {
            // 清空 nameListBox 的項目
            nameListBox.Items.Clear();

            // 將 phoneList 中的每個姓名加入到 nameListBox
            foreach (var entry in phoneList)
            {
                nameListBox.Items.Add(entry.name);
            }
        }

        // Form1_Load 事件在表單載入時觸發，
        // 主要負責初始化資料，例如讀取電話簿檔案並顯示姓名清單。
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFile();
            DisplayNames();
            DisplayNames();
        }

        // nameListBox_SelectedIndexChanged 事件在使用者選取不同姓名時觸發，
        // 會根據選取的姓名顯示對應的電話號碼於 phoneLabel。
        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = nameListBox.SelectedIndex;
            if ((index != -1))
            {
                phoneLabel.Text = phoneList[index].phone;
            }
            else
            {
                phoneLabel.Text = "無資料";
            }
        }

        // 按下離開按鈕時，會檢查是否有開啟過檔案。
        // 若有開啟過檔案，則顯示確認訊息，提醒使用者未儲存的更改將會遺失。
        // 若使用者選擇「是」，則關閉表單；否則不執行任何動作。
        // 若未開啟檔案，則直接關閉表單。
        private void exitButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 檢查是否開過檔案
                if (!string.IsNullOrEmpty(OpenFile.FileName) && File.Exists(OpenFile.FileName))
                {
                    DialogResult result = MessageBox.Show("您確定要退出嗎？未保存的更改將會丟失。", "確認退出", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        // 關閉表單
                        this.Close();
                    }
                }
                else
                {
                    // 如果未開啟檔案，直接關閉表單
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生錯誤: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // label1_Click 事件目前未實作，保留作為未來擴充使用。
        private void label1_Click(object sender, EventArgs e)
        {

        }

        // backgroundWorker3_DoWork 事件目前未實作，保留作為未來擴充使用。
        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        // button_Click 事件用於新增一筆電話簿資料。
        // 會從 textBox1 取得姓名，從 textBox2 取得電話號碼，並檢查是否為空。
        // 若有開啟檔案，則可進行寫入（目前未完成寫入邏輯）。
        private void button_Click(object sender, EventArgs e)
        {
            PhoneBookEntry entry; // 建立一個 PhoneBookEntry 結構物件
            entry.name = textBox1.Text.Trim();   // 取得姓名並去除前後空白
            entry.phone = textBox2.Text.Trim();  // 取得電話號碼並去除前後空白
                                                 // 檢查姓名與電話號碼是否為空
            if (!string.IsNullOrEmpty(OpenFile.FileName) && File.Exists(OpenFile.FileName))
            {
                StreamWriter writer =
                    // 此處尚未完成寫入檔案的程式碼
                }
        }
    }
}
