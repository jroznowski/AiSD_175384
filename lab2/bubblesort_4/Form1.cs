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

        }

        int[] BubbleSort(int[] tab)
        {
            bool a = false;
            while (!a)
            {
                a = true;
                for (int i = 0; i < tab.Length - 1; i++)
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
            return tab;
        }

        string Sorting(int[] tab, string sort)
        {
            string wynik;
            switch (sort)
            {
                case "Bubble Sort":
                    wynik = string.Join(" ", BubbleSort(tab));
                    return wynik;
            }
            return null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sort = comboBox1.Text;
            string[] war = textBox2.Text.Split(' ');
            int[] tab;
            tab = new int[] { 3, 1, 2, 5, 6 };
            string wynik = Sorting(tab,sort);
            //Insert Sort, Merge Sort, Counting Sort, Quick Sort
            textBox1.Text = "Wynik sortowania to: " + wynik;
        }


    }
}
