
public class Calculator
{
    public int Add(string numbers)
    {
        //this is if string is empty
        if (numbers == "")
        {
            return 0;
        }
        //this is if string is one value
        //check if the string is an int, then return result
        else if (Int32.TryParse(numbers, out int result))
        {
            return result;
        }
        //everything else
        else
        {
            if (numbers.Contains(","))
            {
                //better to separate all the numbers by the commas
                //add to array of strings
                string[] values = numbers.Split(',');

                //total sum count
                int totalSum = 0;

                //for every value, do the same as before
                //find out if that string is an int and then return that num
                foreach (string v in values)
                {
                    //trim is for if there are spaces, or extra char
                    if (Int32.TryParse(v.Trim(), out int num))
                    {
                        totalSum += num;
                    }
                }

                return totalSum;

            }

            return 0;

        }
    }
}