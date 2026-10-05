public class Solution
{
    public int MaxOperations(int[] v, int k)
    {
        int l = 0, r = v.Length - 1;
        int ans = 0;
        Array.Sort(v);
        if (v[v.Length - 1] + v[v.Length - 2] < k) return 0;


        while (l < r)
        {
            if (v[l] + v[r] == k)
            {
                ans++; l++; r--;
            }
            else if (v[l] + v[r] > k) r--;
            else l++;
        }
        return ans;
    }
}