using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quick_Sort : MonoBehaviour
{
    private int Partition(int[] array, int left, int right)
    {
        var low = left;
        var high = right + 1;
        var pivot = array[left];

        do
        {
            do
            {
                low++;
            }
            while (low <= right && array[low] < pivot);
            do
            {
                high--;
            }
            while (high >= left && array[high] > pivot);

            if (low < high)
            {
                Swap(array[low], array[high]);
            }
        }
        while (low < high);

        Swap(array[left], array[high]);

        return high;
    }

    public void Sort_Start(int[] array, int left, int right)
    {
        if (left < right)
        {
            int pivotpos = Partition(array, left, right);

            Sort_Start(array, left, pivotpos - 1);
            Sort_Start(array, pivotpos + 1, right);
        }
    }

    private void Swap(int a, int b)
    {
        var temp = a;
        a = b;
        b = temp;
    }
}
