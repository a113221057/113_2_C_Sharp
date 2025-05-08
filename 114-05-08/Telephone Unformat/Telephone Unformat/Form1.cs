using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Unformat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // IsValidFormat 方法接受一個字串參數，並判斷該字串是否符合美國電話號碼的格式。
        // 格式要求為：(XXX)XXX-XXXX，其中：
        // - (XXX) 表示區域碼，必須包含括號。
        // - XXX 表示前三位數字。
        // - -XXXX 表示後四位數字，必須包含連字符。
        // 如果字串符合上述格式，則返回 true；否則返回 false。
        private bool IsValidFormat(string str)
        {
            // 檢查字串是否為空或長度不符合格式要求
            if (string.IsNullOrEmpty(str) || str.Length != 13)
            {
                return false;
            }

            // 檢查字串是否符合 (XXX)XXX-XXXX 格式
            if (str[0] == '(' && str[4] == ')' && str[8] == '-')
            {
                // 確保括號內和後續部分的字符都是數字
                if (str.Substring(1, 3).All(char.IsDigit) &&
                    str.Substring(5, 3).All(char.IsDigit) &&
                    str.Substring(9, 4).All(char.IsDigit))
                {
                    return true;
                }
            }

            return false;
        }

        // Unformat 方法接受一個字串參數（以引用方式傳遞），該字串假設為格式化的電話號碼。
        // 格式化的電話號碼格式為：(XXX)XXX-XXXX。
        // 此方法的功能是移除字串中的括號和連字符，將其轉換為純數字格式。
        // 例如，輸入 "(123)456-7890" 將被轉換為 "1234567890"。
        private void Unformat(ref string str)
        {
            // 移除括號和連字符，僅保留數字
            str = str.Replace("(", "").Replace(")", "").Replace("-", "");
        }

        // 當使用者點擊「移除格式」按鈕時觸發此事件。
        // 此方法會從文字框中取得使用者輸入的電話號碼，檢查其格式是否正確，
        // 如果格式正確，則移除格式並顯示結果；否則提示格式無效。
        private void unformatButton_Click(object sender, EventArgs e)
        {
            // 從文字框中取得使用者輸入的電話號碼
            string input = numberTextBox.Text;

            // 檢查電話號碼格式是否正確
            if (IsValidFormat(input))
            {
                // 如果格式正確，移除格式
                Unformat(ref input);
                numberTextBox.Text = input;

                // 顯示移除格式後的電話號碼
             
            }
            else
            {
                // 如果格式無效，顯示錯誤訊息
                MessageBox.Show("格式無效。請輸入格式為 (XXX)XXX-XXXX 的電話號碼。");
                numberTextBox.Clear();
                numberTextBox.Focus();
            }
        }

        // 當使用者點擊「退出」按鈕時觸發此事件。
        // 此方法的功能是關閉表單，結束應用程式。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }

        // 當表單載入時觸發此事件。
        // 此方法可用於初始化表單的狀態或執行其他載入時的邏輯。
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
