namespace Tutorial_4_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calculatebutton1_Click(object sender, EventArgs e)
        {
            double distance, gas, average; //宣告區域變數

            if (double.TryParse(distancetextBox1.Text, out distance))
            {
                if (double.TryParse(gastextBox.Text, out gas))
                {
                    average = distance / gas; //計算平均油耗
                    averagelabel.Text = "平均油耗:" + average.ToString("f2") + "公里/公升";
                    logListBox.Items.Add(average.ToString("f2") + "公里/公升");
                }
                else
                {
                    MessageBox.Show("油耗請輸入數字");
                    gastextBox.Focus(); //將游標移到gastextBox
                    gastextBox.Text = ""; //清空
                }
            }
            else
            {
                MessageBox.Show("里程請輸入數字");
                distancetextBox1.Focus(); //將游標移到distancetextBox
                distancetextBox1.Text = ""; //清空
            }
        }

        private void exitButton1_Click(object sender, EventArgs e)
        {
            this.Close(); //關閉視窗
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logListBox.Items.Clear(); //清空logListBox
            logListBox.Items.Add("平均油耗的紀錄:");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double sum = 0;
            if (logListBox.Items.Count > 1)
            {
               
                for (int i = 1; i < logListBox.Items.Count; i++)
                {
                    sum += double.Parse(logListBox.Items[i].ToString().Replace("公里/公升", "")); //累加平均油耗

                }
                logListBox.Items.Add("平均油耗:" + (sum / (logListBox.Items.Count - 1)).ToString("f2") + "公里/公升");
            }
            else
            {
                MessageBox.Show("沒有紀錄");
            }
        }
    }
}
