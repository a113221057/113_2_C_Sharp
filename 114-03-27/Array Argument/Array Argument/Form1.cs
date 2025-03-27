using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Array_Argument
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // goButton 控制項的點擊事件處理函式。
        private void goButton_Click(object sender, EventArgs e)
        {
            // 建立一個整數陣列，包含三個元素。
            int[] numbers = { 1, 2, 3 };

            // 在列表框中顯示陣列的原始內容。
            outputListBox.Items.Add("陣列的原始內容：");
            foreach (int number in numbers)
            {
                outputListBox.Items.Add(number);
            }

            // 將陣列傳遞給 SetToZero 方法，，並將其所有元素設為 0。
            SetToZero(numbers);

            // 再次在列表框中顯示陣列的內容。這次應該顯示所有元素都被設置為0。
            outputListBox.Items.Add("");
            outputListBox.Items.Add("呼叫 SetToZero 之後：");
            foreach (int number in numbers)
            {
                outputListBox.Items.Add(number);
            }
        }

        // SetToZero 方法接受一個整數陣列作為參數，並將其所有元素設為 0。
        private void SetToZero(int[] iArray)
        {
            for (int index = 0; index < iArray.Length; index++)
            {
                iArray[index] = 0;
            }
        }

        // exitButton 控制項的點擊事件處理函式。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
