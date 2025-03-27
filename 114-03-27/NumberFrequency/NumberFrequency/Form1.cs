namespace NumberFrequency
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const int SIZE = 1000;
            int num;
            double frequency;
            Random random = new Random();
            int[] numbers = new int[1000];
            for (int i = 0; i < numbers.Length; i++)
            {
                
                numbers[i] = random.Next(1, 101);
            }
            if (int.TryParse(NumbertextBox1.Text, out num))
            {
                frequency = frequencyOfNumber(numbers, num);
                MessageBox.Show("數字" + num + "出現的次數為:" + frequency.ToString("P"));
            }
            else
            {
                MessageBox.Show("型態錯誤:請輸入整數!");
            }
        }
        private double frequencyOfNumber(int[] numbers, int num)
        {
            return (double)numbers.Count(n => n == num) / numbers.Length;
        }
    }
}

