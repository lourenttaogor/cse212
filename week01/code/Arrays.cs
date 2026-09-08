public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.


        // Plan:
        // - Input: 'number' (the starting number) and 'count' (how many multiples to generate)
        // - Output: an array of doubles containing number*1, number*2, number*3, ... number*count
        // - Since we know the exact size needed up front, we can create the array
        //   with that size right away instead of using a resizable list.
        // - Loop from i = 0 to count - 1, and store number * (i + 1) at each position.
        //   We use (i + 1) because array indexes start at 0, but we want to multiply
        //   by 1, 2, 3... not 0, 1, 2...
        // - Performance: single loop through 'count' items, no nested loops -> O(n)

       var result = new double[length]; // create array of the exact size needed

        for (var i = 0; i < length; i++)
        {
            result[i] = number * (i + 1); // (i+1) so first multiple is number*1, not number*0
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // - The last 'amount' items in the list need to move to the front, and everything else
        //   (the remaining items at the start) needs to shift after them, keeping their relative order.
        // - Find the split point: splitIndex = data.Count - amount.
        //   Example: data.Count = 9, amount = 3 -> splitIndex = 6.
        //   That means index 6, 7, 8 (the values 7, 8, 9) are the "tail" that moves to the front.
        // - Use GetRange to slice out two pieces:
        //     tail = data.GetRange(splitIndex, amount)         -> last 'amount' items (e.g. {7,8,9})
        //     head = data.GetRange(0, splitIndex)              -> everything before the tail (e.g. {1,2,3,4,5,6})
        // - Since we must modify 'data' in place (not return a new list), clear it out first,
        //   then add the tail back in, followed by the head. This rebuilds the list in rotated order.
        // - Performance: GetRange copies elements (O(n) combined for both slices), Clear is O(n),
        //   and AddRange to rebuild is O(n) as well. All of these are single passes with no
        //   nested loops, so overall this is O(n), where n is data.Count.


    var splitIndex = data.Count - amount; // index where the "tail" (items to move to front) begins
    var tail = data.GetRange(splitIndex, amount); // last 'amount' items, e.g. {7,8,9}
    var head = data.GetRange(0, splitIndex); // remaining items at the start, e.g. {1,2,3,4,5,6}

    data.Clear(); // empty out the original list so we can rebuild it in the new order
    data.AddRange(tail); // tail goes first
    data.AddRange(head); // head follows after
    }
}
