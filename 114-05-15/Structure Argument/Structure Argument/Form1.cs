using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Structure_Argument
{
    // 定義一個汽車（Automobile）結構，包含廠牌、年份與里程數欄位
    struct Automobile
    {
        public string make;    // 汽車廠牌
        public int year;       // 汽車年份
        public double mileage; // 汽車里程數
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // DisplayAuto 方法接收一個 Automobile 結構物件作為參數，
        // 並顯示該物件的所有欄位資訊於訊息方塊中
        private void DisplayAuto(Automobile auto)
        {
            MessageBox.Show(
                auto.year + " 年 " + auto.make +
                "，里程數：" + auto.mileage + " 英里。"
            );
        }

        // 當使用者點擊 auto1Button（顯示汽車 #1 按鈕）時執行此事件處理方法
        private void auto1Button_Click(object sender, EventArgs e)
        {
            // 建立一個 Automobile 結構的實例，代表一台跑車
            Automobile sportsCar = new Automobile();

            // 指定該跑車的廠牌、年份與里程數
            sportsCar.make = "Chevy Corvette";
            sportsCar.year = 1970;
            sportsCar.mileage = 50000.0;

            // 顯示該跑車的所有資訊
            DisplayAuto(sportsCar);
        }

        // 當使用者點擊 auto2Button（顯示汽車 #2 按鈕）時執行此事件處理方法
        private void auto2Button_Click(object sender, EventArgs e)
        {
            // 建立一個 Automobile 結構的實例，代表一台皮卡車
            Automobile pickupTruck = new Automobile();

            // 指定該皮卡車的廠牌、年份與里程數
            pickupTruck.make = "Ford Ranger";
            pickupTruck.year = 1985;
            pickupTruck.mileage = 75000.0;

            // 顯示該皮卡車的所有資訊
            DisplayAuto(pickupTruck);
        }

        // 當使用者點擊 auto3Button（顯示汽車 #3 按鈕）時執行此事件處理方法
        private void auto3Button_Click(object sender, EventArgs e)
        {
            // 建立一個 Automobile 結構的實例，代表一台轎車
            Automobile sedan = new Automobile();

            // 指定該轎車的廠牌、年份與里程數
            sedan.make = "Honda Accord";
            sedan.year = 2000;
            sedan.mileage = 80000.0;

            // 顯示該轎車的所有資訊
            DisplayAuto(sedan);
        }
    }
}
