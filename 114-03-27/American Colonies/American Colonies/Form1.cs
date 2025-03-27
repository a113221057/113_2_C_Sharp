using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace American_Colonies
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LocalizeComponents();
        }

        // LocalizeComponents 方法將所有 UI 元件的 Text 屬性設置為繁體中文
        private void LocalizeComponents()
        {
            // 設置表單標題
            this.Text = "美國殖民地";
            // 設置確定按鈕的文字
            this.okButton.Text = "確定";
            // 設置退出按鈕的文字
            this.exitButton.Text = "退出";
            // 清空選擇列表框的項目
            this.selectionListBox.Items.Clear();
            // 添加繁體中文的殖民地名稱到選擇列表框
            this.selectionListBox.Items.AddRange(new string[] {
                    "特拉華", "賓夕法尼亞", "新澤西",
                    "喬治亞", "康涅狄格", "麻薩諸塞",
                    "馬里蘭", "南卡羅來納", "新罕布什爾",
                    "維吉尼亞", "紐約", "北卡羅來納",
                    "羅德島"
                });
        }

        // SequentialSearch 方法在字串陣列中搜尋指定的值
        // 如果找到該值，則返回其位置。否則，返回 -1
        private int SequentialSearch(string[] sArray, string value)
        {
            bool found = false;  // 標誌是否找到搜尋結果
            int index = 0;       // 用於遍歷陣列的索引
            int position = -1;   // 如果找到值，則記錄其位置

            // 搜尋陣列
            while (!found && index < sArray.Length)
            {
                if (sArray[index] == value)
                {
                    found = true;
                    position = index;
                }

                index++;
            }

            // 返回位置
            return position;
        }

        // okButton_Click 方法處理確定按鈕的點擊事件
        private void okButton_Click(object sender, EventArgs e)
        {
            string selection;   // 用於保存使用者的選擇

            // 創建一個包含殖民地名稱的陣列
            string[] colonies = {  "Delaware", "Pennsylvania", "New Jersey",
                                        "Georgia", "Connecticut", "Massachusetts",
                                        "Maryland", "South Carolina", "New Hampshire",
                                        "Virginia", "New York", "North Carolina",
                                        "Rhode Island" };

            if (selectionListBox.SelectedIndex != -1)
            {
                // 獲取選中的項目
                selection = selectionListBox.SelectedItem.ToString();

                // 判斷該項目是否在陣列中
                if (SequentialSearch(colonies, selection) != -1)
                {
                    MessageBox.Show("是的，那是其中一個殖民地。");
                }
                else
                {
                    MessageBox.Show("不，那不是其中一個殖民地。");
                }
            }
        }

        // exitButton_Click 方法處理退出按鈕的點擊事件
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }
    }
}
