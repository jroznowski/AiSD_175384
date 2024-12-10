using System.Diagnostics;

namespace SortingTraining2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
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
                int[] genTab = new int[dl];

                for (int i = 0; i < genTab.Length; i++)
                {
                    genTab[i] = rnd.Next(1, 100);
                }
                Tab = genTab;
                label1.Text = TabToString(Tab);
            }
            else
            {
                Tab = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            switch(comboBox1.SelectedItem.ToString()){
                case "Bubble":
                    timer.Start();
                    Tab = bubbleSort(Tab);
                    timer.Stop();
                    break;
                case "Insert":
                    timer.Start();
                    Tab = insertSort(Tab);
                    timer.Stop();
                    break;
                case "Counting":
                    timer.Start();
                    Tab = countingSort(Tab);
                    timer.Stop();
                    break;
                case "Merge":
                    timer.Start();
                    Tab = mergeSort(Tab, 0, tab.Length-1);
                    timer.Stop();
                    break;
                case "Quick":
                    timer.Start();
                    Tab = quickSort(Tab, 0, tab.Length-1);
                    timer.Stop();
                    break;
            }
            TimeSpan time = timer.Elapsed;
            String czas = "Czas sortowania: " + time.TotalMilliseconds.ToString();
            String wynik = "Wynik sortowania: " + TabToString(Tab);
            label2.Text = wynik;
            label3.Text = czas;

        }

        void Swap(int[] tab, int left, int right)
        {
            int temp = tab[left];
            tab[left] = tab[right];
            tab[right] = temp;
        }

        String TabToString(int[] tab)
        {
            String tts = String.Join(" ", tab);
            return tts;
        }

        int[] bubbleSort(int[] tab)
        {
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int i = 0; i < tab.Length - 1; i++)
                {
                    if (tab[i] > tab[i + 1])
                    {
                        Swap(tab, i, i + 1);
                        sorted = false;
                    }
                }
                }
            return tab;
        }

        int[] insertSort(int[] tab)
        {
            for(int i = 1; i < tab.Length; i++)
            {
                int war = tab[i];
                int j = i;

                while(j > 0 && war < tab[j - 1])
                {
                    tab[j] = tab[j - 1];
                    j--;
                }
                tab[j] = war;
            }
            return tab;
        }

        int[] countingSort(int[] tab)
        {
            int max = tab.Max();
            int[] countTab = new int[max + 1];
            int[] newTab = new int[tab.Length];
            for(int i = 0; i < tab.Length; i++)
            {
                countTab[tab[i]]++;
            }
            for(int j = 1; j < countTab.Length; j++)
            {
                countTab[j] = countTab[j] + countTab[j - 1];
            }
            for(int k = 0; k < tab.Length; k++)
            {
                newTab[countTab[tab[k]] - 1] = tab[k];
                countTab[tab[k]]--;
            }

            return newTab;
        }

        int[] mergeSort(int[] tab, int left, int right)
        {
            if(left >= right)
            {
                return tab;
            }
            int mid = (left + right) / 2;
            mergeSort(tab, left, mid);
            mergeSort(tab, mid + 1, right);
            merge(tab, left, mid, right);
            return tab;
        }

        int[] merge(int[] tab, int le, int mid, int rig) {
            int[] left = new int[mid - le + 1];
            Array.Copy(tab, le, left, 0, mid - le + 1);
            int[] right = new int[rig - mid];
            Array.Copy(tab, mid + 1, right, 0, rig - mid);

            int leP = 0, rigP = 0, tabP = le;

            while(leP < left.Length && rigP < right.Length)
            {
                if (left[leP] < right[rigP])
                {
                    tab[tabP++] = left[leP++]; 
                }
                else
                {
                    tab[tabP++] = right[rigP++];
                }
            }
            while(leP < left.Length)
            {
                tab[tabP++] = left[leP++];
            }
            while (rigP < right.Length)
            {
                tab[tabP++] = right[rigP++];
            }

            return tab;
        }

        int[] quickSort(int[] tab, int st, int en)
        {
            if(st < en)
            {
                int partitionIndex = partition(tab, st, en);

                quickSort(tab, st, partitionIndex - 1);
                quickSort(tab, partitionIndex + 1, en);
            }
            return tab;
        }

        int partition(int[] tab, int st, int en)
        {
            int pivot = tab[en];
            int i = st - 1;

            for(int j = st; j < en; j++)
            {
                if (tab[j] < pivot)
                {
                    i++;
                    Swap(tab, i, j);
                }
            }
            Swap(tab, i + 1, en);

            return i+1;
        }

    }
}
