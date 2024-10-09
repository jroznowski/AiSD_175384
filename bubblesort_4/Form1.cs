namespace bubblesort_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool a = false;
            int[] tab;
            tab = new int[] { 3, 1, 2, 5, 6 };

            while (!a)
            {
                a = true;
                for(int i = 0; i < tab.Length-1; i++)
                {
                    if (tab[i] >= tab[i + 1])
                    {
                        int temp = tab[i];
                        tab[i] = tab[i + 1];
                        tab[i + 1] = temp;
                        a = false;
                    }
                }
            }
            string wynik = string.Join(" ", tab);
            textBox1.Text = "Wynik sortowania to: " + wynik;
        }
    }
}
