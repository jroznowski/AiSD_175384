using System;
using System.Diagnostics;
namespace sorting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] tab = null;
        int[] Tab
        {
            get
            {
                return tab;
            }
            set
            {
                tab = value;
                if (value != null)
                {
                    button1.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == false)
            {
                string[] con = new string[] { "" };
                con = textBox1.Text.Split(' ');
                Tab = con.Select(s => int.Parse(s)).ToArray();
            }
            else
            {
                Tab = null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == false)
            {
                int dl = int.Parse(textBox2.Text);
                Random rnd = new Random();
                int[] newTab = new int[dl];

                for (int i = 0; i < int.Parse(textBox2.Text); i++)
                {
                    newTab[i] = rnd.Next(1, 100);
                }
                Tab = newTab;
            }
            else
            {
                Tab = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string wynik;
            int[] tab;
            tab = new int[] { 37, 12, 27, 51, 64, 10, 15, 73, 87 };
            Stopwatch tim = new Stopwatch();
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Bubble":
                    tim.Start();
                    tab = BubbleSort(Tab);
                    tim.Stop();
                    break;
                case "Insert":
                    tim.Start();
                    tab = InsertSort(Tab);
                    tim.Stop();
                    break;
                case "Merge":
                    tim.Start();
                    tab = MergeSort(Tab);
                    tim.Stop();
                    break;
                case "Counting":
                    tim.Start();
                    tab = CountingSort(Tab);
                    tim.Stop();
                    break;
                case "Quick":
                    tim.Start();
                    tab = QuickSort(Tab, 0, tab.Length - 1);
                    tim.Stop();
                    break;
            }
            wynik = TabToString(tab);
            TimeSpan stime = tim.Elapsed;
            label1.Text = "Posortowana tabela: " + wynik;
            label2.Text = "Czas sortowania: " + stime.TotalMilliseconds.ToString() + " ms";

        }


        int[] BubbleSort(int[] tab)
        {
            bool a = false;
            while (!a)
            {
                a = true;
                for (int i = 0; i < tab.Length - 1; i++)
                {
                    if (tab[i] > tab[i + 1])
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

        int[] InsertSort(int[] tab)
        {
            List<int> tab2 = new List<int> { tab[0] };
            for (int i = 1; i < tab.Length; i++)
            {
                int j = 0;
                int cur = tab[i];
                while (j < tab2.Count && tab2[j] < cur)
                {
                    j++;
                }

                tab2.Insert(j, cur);
            }
            int[] tab3 = tab2.ToArray();
            return tab3;

        }

        int[] MergeSort(int[] tab)
        {
            if (tab.Length <= 1)
            {
                return tab;
            }

            int mid = tab.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[tab.Length - mid];

            Array.Copy(tab, 0, left, 0, mid);

            Array.Copy(tab, mid, right, 0, tab.Length - mid);

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        int[] Merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];
            int leftIndex = 0, rightIndex = 0, resultIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] <= right[rightIndex])
                {
                    result[resultIndex++] = left[leftIndex++];
                }
                else
                {
                    result[resultIndex++] = right[rightIndex++];
                }
            }

            while (leftIndex < left.Length)
            {
                result[resultIndex++] = left[leftIndex++];
            }

            while (rightIndex < right.Length)
            {
                result[resultIndex++] = right[rightIndex++];
            }

            return result;
        }

        int[] CountingSort(int[] array)
        {
            if (array.Length == 0)
            {
                return array;
            }

            int maxWar = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxWar)
                {
                    maxWar = array[i];
                }
            }

            int[] count = new int[maxWar + 1];

            for (int i = 0; i < array.Length; i++)
            {
                count[array[i]]++;
            }

            int index = 0;
            for (int i = 0; i < count.Length; i++)
            {
                while (count[i] > 0)
                {
                    array[index++] = i;
                    count[i]--;
                }
            }

            return array;
        }

        int[] QuickSort(int[] tab, int low, int high)
        {
            if (tab.Length <= 1 || low < high)
            {
                return tab;
            }
            int i = low - 1;
            int temp = 0;
            int pivot = tab[high];
            for (int j = 0; j < high; j++)
            {
                if (tab[j] <= pivot)
                {
                    i++;
                    temp = tab[i];
                    tab[i] = tab[j];
                    tab[j] = temp;
                }
            }
            i++;
            temp = tab[i + 1];
            tab[i + 1] = pivot;
            tab[high] = temp;
            return QuickSort(tab, low, i - 1).Concat(QuickSort(tab, i, i + 1)).Concat(QuickSort(tab, i + 1, high)).ToArray();
        }

        string TabToString(int[] tab)
        {
            string tts = string.Join(" ", tab);
            return tts;
        }

    }
}
