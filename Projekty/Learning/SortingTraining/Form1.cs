using System.Diagnostics;

namespace SortingTraining
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
                int len = int.Parse(textBox1.Text);
                Random rn = new Random();

                int[] tb = new int[len];

                for (int i = 0; i < tb.Length; i++)
                {
                    tb[i] = rn.Next(1, 100);
                }
                Tab = tb;
                label1.Text = "Wygenerowana tabela: " + TabToString(tab);
            }
            else
            {
                Tab = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string wynik, czas;
            TimeSpan czasMs;
            Stopwatch dur = new Stopwatch();

            switch (comboBox1.SelectedItem.ToString())
            {
                case "Bubble":
                    dur.Start();
                    Tab = BubbleSort(Tab);
                    dur.Stop();
                    break;
                case "Counting":
                    dur.Start();
                    Tab = CountingSort(Tab);
                    dur.Stop();
                    break;
                case "Insert":
                    dur.Start();
                    Tab = InsertSort(Tab);
                    dur.Stop();
                    break;
                case "Merge":
                    dur.Start();
                    MergeSort(Tab, 0, Tab.Length - 1);
                    dur.Stop();
                    break;
                case "Quick":
                    dur.Start();
                    QuickSort(tab, 0, tab.Length - 1);
                    dur.Stop();
                    break;
            }
            wynik = TabToString(tab);
            czasMs = dur.Elapsed;
            czas = czasMs.TotalMilliseconds.ToString() + " ms";
            label2.Text = "Posortowana tabela: " + wynik;
            label3.Text = "Czas sortowania: " + czas;

        }

        void Swap(int[] tab, int left, int right)
        {
            int temp = tab[left];
            tab[left] = tab[right];
            tab[right] = temp;
        }

        int[] BubbleSort(int[] tab)
        {
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for(int i = 0; i < tab.Length - 1; i++) {
                    if (tab[i] > tab[i + 1])
                    {
                        Swap(tab, i, i + 1);
                        sorted = false;
                    }
                }
            }
            return tab;
        }

        int[] CountingSort(int[] tab){
            int max = tab.Max();
            int[] count = new int[max + 1];
            int[] output = new int[tab.Length];
            for (int i = 0; i < tab.Length; i++)
            {
                count[tab[i]]++;
            }
            for(int i = 1; i < count.Length; i++)
            {
                count[i] = count[i - 1] + count[i];
            }
            for(int i = tab.Length - 1; i >= 0; i--)
            {
                output[count[tab[i]] - 1] = tab[i];
                count[tab[i]]--;
            }
            
            return output;
        }

        int[] InsertSort(int[] tab)
        {
            for(int i = 1; i < tab.Length; i++)
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

        /*void MergeSort(int[] tab, int st, int en)
        {
            if (st >= en)
            {
                return;
            }

            int mid = (st + en) / 2;

            MergeSort(tab, st, mid);
            MergeSort(tab, mid + 1, en);
            Merge(tab, st, mid, en);
        }

        void Merge(int[] tab, int st, int mid, int en)
        {
            int[] left = new int[mid - st + 1];
            Array.Copy(tab, st, left, 0, mid - st + 1);
            int[] right = new int[en - mid];
            Array.Copy(tab, mid + 1, right, 0, en - mid);
            int leP = 0, reP = 0, tabP = st;

            while(leP < left.Length && reP < right.Length)
            {
                if(left[leP] < right[reP])
                {
                    tab[tabP++] = left[leP++];
                }
                else
                {
                    tab[tabP++] = right[reP++];
                }
            }
            while(leP < left.Length)
            {
                tab[tabP++] = left[leP++];
            }
            while(reP < right.Length)
            {
                tab[tabP++] = right[reP++];
            }

        }*/

        void QuickSort(int[] tab, int st, int en)
        {
            if(st < en)
            {
                int PartitionIndex = Partition(tab, st, en);

                QuickSort(tab, st, PartitionIndex - 1);
                QuickSort(tab, PartitionIndex + 1, en);
            }
        }



        int Partition(int[] tab, int st, int en)
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
            return i + 1;
        }

        string TabToString(int[] tab)
        {
            string tts = string.Join(" ", tab);
            return tts;
        }

        void MergeSort(int[] tab, int left, int right)
        {
            if(left >= right)
            {
                return;
            }

            int mid = (left + right) / 2;
            MergeSort(tab, left, mid);
            MergeSort(tab, mid + 1, right);
            Merge(tab, left, mid, right);
        }

        void Merge(int[] tab, int le, int mid, int rig)
        {
            int[] left = new int[mid - le + 1];
            Array.Copy(tab, le, left, 0, mid - le + 1);
            int[] right = new int[rig - mid];
            Array.Copy(tab, mid + 1, right, 0, rig - mid);
            int lefIn = 0, rigIn = 0, tabIn = le;

            while (lefIn < left.Length && rigIn < right.Length)
            {
                if (left[lefIn] < right[rigIn])
                {
                    tab[tabIn++] = left[lefIn++];
                }
                else
                {
                    tab[tabIn++] = right[rigIn++];
                }
            }
            while(lefIn < left.Length)
            {
                tab[tabIn++] = left[lefIn++];
            }
            while (rigIn < right.Length)
            {
                tab[tabIn++] = right[rigIn++];
            }
        }
    }
}
