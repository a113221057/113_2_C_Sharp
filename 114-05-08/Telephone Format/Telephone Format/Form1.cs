using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Format
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // IsValidNumber 方法接受一個字串作為參數，
        // 並檢查該字串是否包含 10 個數字。
        // 如果包含 10 個數字，則回傳 true；否則回傳 false。
        private bool IsValidNumber(string str)
        {
            const int VALID_LENGTH = 10;
            if(str.Length != VALID_LENGTH)
            {
               for (int i=0; i < str.Length; i++)
                {
                    if (!char.IsDigit(str[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        // TelephoneFormat 方法接受一個字串參數（以參考方式傳遞），
        // 並將該字串格式化為電話號碼的形式。
        // 格式化後的電話號碼通常為 (XXX) XXX-XXXX。
        private void TelephoneFormat(String str)
        {
            //  if (str.Length == 10)
            // {
            //       str = $"({str.Substring(0, 2)}) {str.Substring(2, 4)}-{str.Substring(6,4)}";
            //  }
            str = str.Insert(0, "("); // 在字串的開頭插入左括號
            str = str .Insert(3, ") "); // 在字串的第 3 個位置插入右括號和空格
            str = str.Insert(9, "-"); // 在字串的第 9 個位置插入連字號
        }

        private void formatButton_Click(object sender, EventArgs e)
        {
            string input = numberTextBox.Text;
            if (IsValidNumber(input))
            
            {
                TelephoneFormat(ref input);
                MessageBox.Show(input, "格式化後的電話號碼", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("請輸入有效的電話號碼。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單並結束應用程式。
            this.Close();
        }
    }
}
