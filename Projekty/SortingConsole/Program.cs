// See https://aka.ms/new-console-template for more information
int[] tab = { 1, 5, 2, 3, 4 };

int[] MergeSort(int[] tab)
{
    if (tab.Length <= 1) { 
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
    while(leftIndex < left.Length && rightIndex < right.Length)
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

void MergeSort2(int[] tab, int leIn, int reIn)
{
    int mid = (leIn+reIn) / 2;

    MergeSort2(tab, 0, mid);
    MergeSort2(tab, mid, tab.Length - mid);
    Merge2(tab, 0, mid);
    Merge2(tab, mid, tab.Length - mid);
}

void Merge2(int[] tab, int left, int mid, int right)
{
    int[] leftArray = new int[mid];
    Array.Copy(tab, 0, leftArray, 0, mid);
    int[] rightArray = new int[tab.Length - mid];
    Array.Copy(tab, mid, rightArray, 0, tab.Length);
    int lefIn = 0, rigIn = 0, merIn = left;
    while(lefIn < leftArray.Length && rigIn < rightArray.Length)
    {
        if (leftArray[lefIn] <= rightArray[rigIn])
        {
            tab[merIn++] = leftArray[lefIn++];
        }
        else
        {
            tab[merIn++] = rightArray[rigIn++];
        }

        while(lefIn < leftArray.Length)
        {
            tab[merIn++] = leftArray[lefIn++];
        }
        while(rigIn < rightArray.Length)
        {
            tab[merIn++] = rightArray[rigIn++];
        }
    }
}

String tabToString(int[] tab)
{
    String str = String.Join(" ", tab);
    return str;
}
Console.WriteLine("Przed sortowaniem " + tabToString(tab));
tab = MergeSort(tab);
Console.WriteLine("Sorted " + tabToString(tab));
