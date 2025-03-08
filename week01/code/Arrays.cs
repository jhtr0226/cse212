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


        //-----------------------------------------------------------------------------------------
        //First we will create an array to store/save the multiples
        double[] multiples = new double[length];

        //Now, let's loop it and fill it with multiples of the number
        for (int i = 0; i < length; i++) //loop start at i = 0, and runs while i is less than length, i will increase 1 after each interaction
        {
            multiples[i] = number * (i + 1); //multiply number by i+1 to get the multiple
        }

        //Return the array! 
        return multiples;
    }
    //-----------------------------------------------------------------------------------------

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


        //-----------------------------------------------------------------------------------------
        int length = data.Count; //let's get the lenght of the list

        //if no rotation is needed, return
        if (length <= 1 || amount == 0 || amount == length)
        {
            return;
        }

        //find the split index
        int splitIndex = length - amount;

        //extract and reorder the list
        List<int> rotated = new List<int>();

        rotated.AddRange(data.GetRange(splitIndex, amount)); // Take last 'amount' elements
        rotated.AddRange(data.GetRange(0, splitIndex)); // Take the remaining elements

        //Update the original list
        data.Clear();
        data.AddRange(rotated);




    }
}
