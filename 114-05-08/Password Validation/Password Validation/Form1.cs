using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Validation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 設定表單的標題文字為「密碼驗證」
            this.Text = "密碼驗證";

            // 設定檢查密碼按鈕的文字為「檢查密碼」
            checkPasswordButton.Text = "檢查密碼";

            // 設定退出按鈕的文字為「退出」
            exitButton.Text = "退出";

            // 設定標籤的文字為「請輸入密碼：」
            passwordTextBox.Text = "請輸入密碼：";
        }

        /// <summary>
        /// NumberUpperCase 方法
        /// 接受一個字串參數，並計算該字串中包含的大寫字母數量。
        /// </summary>
        /// <param name="str">要檢查的大寫字母的字串</param>
        /// <returns>返回大寫字母的數量</returns>
        private int NumberUpperCase(string str)
        {
            int upercaseCount = 0; // 初始化大寫字母計數器
            foreach (char c in str)
            {
                // 檢查字元是否為大寫字母
                if (char.IsUpper(c))
                {
                    upercaseCount++; // 如果是大寫字母，計數器加一
                }
            }
            return upercaseCount; // 返回大寫字母的數量
        }

        /// <summary>
        /// NumberLowerCase 方法
        /// 接受一個字串參數，並計算該字串中包含的小寫字母數量。
        /// </summary>
        /// <param name="str">要檢查的小寫字母的字串</param>
        /// <returns>返回小寫字母的數量</returns>
        private int NumberLowerCase(string str)
        {
            int lowercaseCount = 0; // 初始化小寫字母計數器
            for (int i = 0; i < str.Length; i++)
            {

                // 檢查字元是否為小寫字母
                if (char.IsLower(str[i]))
                {
                    lowercaseCount++; // 如果是小寫字母，計數器加一
                }
            }
            {

                return lowercaseCount; // 返回小寫字母的數量
            }
        }
        
        /// NumberDigits 方法
        /// 接受一個字串參數，並計算該字串中包含的數字字元數量。
    
        /// <param name="str">要檢查的數字字元的字串</param>
        /// <returns>返回數字字元的數量</returns>
        private int NumberDigits(string str)
        {
            int digits = 0;
            foreach (char c in str)
            {
                // 檢查字元是否為數字
                if (char.IsDigit(c))
                {
                    digits++; // 如果是數字，計數器加一
                }
            }
        }

     
        /// 檢查密碼按鈕的點擊事件處理方法。
        /// 當用戶點擊「檢查密碼」按鈕時，執行相關的密碼驗證邏輯。
   
        private void checkPasswordButton_Click(object sender, EventArgs e)
        {
          const int MIN_LENGTH = 8; // 密碼的最小長度
            string password = passwordTextBox.Text; // 獲取用戶輸入的密碼
            if ( password . Length >= MIN_LENGTH && NumberUpperCase(password) > 0 && 
                NumberLowerCase(password) > 0 && 
                NumberDigits(password) > 0) 
            {
                MessageBox.Show("密碼有效！"); // 顯示密碼有效的提示
            }
            else
            {
                MessageBox.Show("密碼無效！"); // 顯示密碼無效的提示
            }
        }

        /// <summary>
        /// 退出按鈕的點擊事件處理方法。
        /// 當用戶點擊「退出」按鈕時，關閉當前的表單。
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉當前的表單
            this.Close();
        }
    }
}
