using System.CodeDom.Compiler;
using System.Diagnostics;

namespace SortingTraining3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
        }
        int counter = 0;
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
                    button2.Enabled = true;
                }
                else
                {
                    button2.Enabled = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                Random rnd = new Random();
                int dl = int.Parse(textBox1.Text);
                int[] tab = new int[dl];

                for (int i = 0; i < dl; i++)
                {
                    tab[i] = rnd.Next(1, 100);
                }
                Tab = tab;
                label1.Text = tabToString(Tab);
            }
            else
            {
                Tab = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            int[] oTab = new int[Tab.Length];
            Array.Copy(tab, oTab, tab.Length);
            counter++;

            switch (comboBox1.SelectedItem.ToString())
            {
                case "Bubble":
                    timer.Start();
                    oTab = bubbleSort(oTab);
                    timer.Stop();
                    break;
                case "Insert":
                    timer.Start();
                    oTab = insertSort(oTab);
                    timer.Stop();
                    break;
                case "Counting":
                    timer.Start();
                    oTab = countingSort(oTab);
                    timer.Stop();
                    break;
                case "Merge":
                    timer.Start();
                    mergeSort(oTab, 0, Tab.Length-1);
                    timer.Stop();
                    break;
                case "Quick":
                    timer.Start();
                    quickSort(oTab, 0, Tab.Length-1);
                    timer.Stop();
                    break;
            }
            label1.Text = tabToString(Tab) + " to juz " + counter.ToString() + " iteracja";
            TimeSpan time = timer.Elapsed;
            string czas = "Czas sortowania: " + time.TotalMilliseconds.ToString();
            string wynik = "Posortowana tablica: " + tabToString(oTab);
            label2.Text = wynik;
            label3.Text = czas;
        }

        String tabToString(int[] tab)
        {
            String tts = String.Join(" ", tab);
            return tts;
        }

        void Swap(int[] tab, int left, int right)
        {
            int temp = tab[left];
            tab[left] = tab[right];
            tab[right] = temp;
        }

        int[] bubbleSort(int[] tab)
        {
            bool sorted = false;

            while (!sorted)
            {
                sorted = true;
                for (int i = 0; i < tab.Length - 1; i++)
                {
                    if (tab[i] > tab[i + 1]) {
                        sorted = false;
                        Swap(tab, i, i + 1);
                    }
                }
            }
            return tab;
        }

        int[] insertSort(int[] tab)
        {
            for (int i = 1; i < tab.Length; i++)
            {
                int temp = tab[i];
                int j = i;

                while (j > 0 && temp < tab[j - 1])
                {
                    tab[j] = tab[j - 1];
                    j--;
                }
                tab[j] = temp;
            }
            return tab;

        }

        int[] countingSort(int[] tab)
        {
            int max = tab.Max();
            int[] countTab = new int[max + 1];
            int[] outputTab = new int[tab.Length];
            for(int i = 0; i < tab.Length; i++)
            {
                countTab[tab[i]]++;
            }
            for(int j = 1; j < countTab.Length; j++)
            {
                countTab[j] = countTab[j - 1] + countTab[j];
            }
            for(int k = 0; k < tab.Length; k++)
            {
                outputTab[countTab[tab[k]] - 1] = tab[k];
                countTab[tab[k]]--;
            }
            return outputTab;
        }

        void mergeSort(int[] tab, int st, int en)
        {
            if(st >= en)
            {
                return;
            }
            int mid = (st + en) / 2;

            mergeSort(tab, st, mid);
            mergeSort(tab, mid + 1, en);
            merge(tab, st, mid, en);
        }

        int[] merge(int[] tab, int st, int mid, int en)
        {
            int[] left = new int[mid - st + 1];
            Array.Copy(tab, st, left, 0, mid - st + 1);
            int[] right = new int[en - mid];
            Array.Copy(tab, mid + 1, right, 0, en - mid);

            int stP = 0, enP = 0, tabP = st;

            while(stP < left.Length && enP < right.Length)
            {
                if (left[stP] < right[enP])
                {
                    tab[tabP++] = left[stP++];
                }
                else
                {
                    tab[tabP++] = right[enP++];
                }
            }
            while(stP < left.Length)
            {
                tab[tabP++] = left[stP++];
            }
            while (enP < right.Length)
            {
                tab[tabP++] = right[enP++];
            }
            return tab;
        }

        void quickSort(int[] tab, int st, int en)
        {
            if (st < en)
            {
                int partitionIndex = partition(tab, st, en);
                quickSort(tab, st, partitionIndex - 1);
                quickSort(tab, partitionIndex + 1, en);
            }

        }

        int partition(int[] tab, int st, int en)
        {
            int pivot = tab[en];
            int i = st - 1;

            for (int j = st; j < en; j++)
            {
                if (tab[j] < pivot)
                {
                    i++;
                    Swap(tab, i, j);
                }
            }
            Swap(tab, i + 1, en);
            return i + 1;
        }

    }
}
