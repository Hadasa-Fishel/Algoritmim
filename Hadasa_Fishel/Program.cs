
#region Question1
static void Question1(int[] arr)
{
    if (arr == null || arr.Length == 0) return;

    int currentSum = arr[0], maxSum = arr[0];
    int currentStart = 0, bestStart = 0, bestEnd = 0;

    for (int i = 1; i < arr.Length; i++)
    {
        if (currentSum + arr[i] > arr[i])
            currentSum += arr[i];
        else
        {
            currentSum = arr[i];
            currentStart = i;
        }

        if (currentSum > maxSum)
        {
            maxSum = currentSum;
            bestStart = currentStart;
            bestEnd = i;
        }
    }
    Console.WriteLine(maxSum);
    for (int i = bestStart; i <= bestEnd; i++)
    {
        Console.WriteLine(arr[i]);
    }
}
#endregion

#region Question3
static ListNode Question3(ListNode head)
{
    if (head == null) return null;

    List<int> arrList = new List<int>();
    ListNode currNode = head;
    while (currNode != null)
    {
        arrList.Add(currNode.Value);
        currNode = currNode.Next;
    }

    int[] arr = arrList.ToArray();
    int n = arr.Length;

    int[] parent = new int[n];
    int[] tailIndices = new int[n];
    int length = 0;

    for (int i = 0; i < n; i++)
    {
        int x = arr[i];
        int left = 0;
        int right = length;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (arr[tailIndices[mid]] <= x)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        tailIndices[left] = i;

        if (left > 0)
        {
            parent[i] = tailIndices[left - 1];
        }
        else
        {
            parent[i] = -1;
        }

        if (left == length)
        {
            length++;
        }
    }

    int[] resultArr = new int[length];
    int currIndex = tailIndices[length - 1];

    for (int i = length - 1; i >= 0; i--)
    {
        resultArr[i] = arr[currIndex];
        currIndex = parent[currIndex];
    }

    ListNode newHead = new ListNode(resultArr[0]);
    ListNode tail = newHead;

    for (int i = 1; i < length; i++)
    {
        tail.Next = new ListNode(resultArr[i]);
        tail = tail.Next;
    }

    return newHead;
}
#endregion

#region Question4
static int Question4(int[] arr, int X)
{
    if (arr == null || arr.Length == 0) return 0;

    Dictionary<int, int> prefixSums = new Dictionary<int, int>();
    prefixSums[0] = 1;

    int currentSum = 0;
    int count = 0;

    for (int i = 0; i < arr.Length; i++)
    {
        currentSum += arr[i];
        int requiredPreviousSum = currentSum - X;

        if (prefixSums.ContainsKey(requiredPreviousSum))
        {
            count += prefixSums[requiredPreviousSum];
        }

        if (prefixSums.ContainsKey(currentSum))
        {
            prefixSums[currentSum]++;
        }
        else
        {
            prefixSums[currentSum] = 1;
        }
    }

    return count;
}
#endregion

#region Question5
//מצורף בקובץ
static int Question5(int T, int S, int N)
{
    return (Math.max(N - T + 1, N - S + 1))
}

#endregion

#region Question2
public class O1DataStructure
{
    private Dictionary<int, Node> dict;
    private int globalCount;
    private int setAllValue;

    public O1DataStructure()
    {
        dict = new Dictionary<int, Node>();
        globalCount = 0;
    }

    public void Set(int key, int val)
    {
        dict[key] = new Node(val, globalCount);
    }

    public int Get(int key)
    {
        Node node = dict[key];
        if (node.Count == globalCount)
        {
            return node.Value;
        }
        return setAllValue;
    }

    public void SetAll(int val)
    {
        setAllValue = val;
        globalCount++;
    }
}
#endregion

