using System;

class Podciag
{
    static int[,] NWPTab(string S1, string S2)
    {
        int m = S1.Length;
        int n = S2.Length;

        int[,] tab = new int[m + 1, n + 1];

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (S1[i - 1] == S2[j - 1])
                {
                    tab[i, j] = tab[i - 1, j - 1] + 1;
                }
                else
                {
                    tab[i, j] = Math.Max(tab[i - 1, j],
                                        tab[i, j - 1]);
                }
            }
        }


        return tab;
    }

    static string NWP(string S1, string S2, int[,] dp)
    {
        int m = S1.Length;
        int n = S2.Length;

        int index = dp[m, n];
        char[] lcs = new char[index];
        int x = m, y = n;

        while (x > 0 && y > 0)
        {
            if (S1[x - 1] == S2[y - 1])
            {
                lcs[index - 1] = S1[x - 1];
                x--;
                y--;
                index--;
            }
            else if (dp[x - 1, y] > dp[x, y - 1])
            {
                x--;
            }
            else
            {
                y--;
            }
        }

        return new string(lcs);
    }

    static void Main()
    {
        string S1 = "abaabbaaa";
        string S2 = "babab";

        int[,] tab = NWPTab(S1, S2);

        int LCSLength = tab[S1.Length, S2.Length];

        Console.WriteLine("Długość najdłuższego wspólnego podciągu wynosi: "
                          + LCSLength);

        Console.WriteLine("Najdłuższy podciąg to: " + NWP(S1, S2, NWPTab(S1, S2)));
    }
}