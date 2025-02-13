
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
        else if (int.TryParse(numbers, out int result))
        {
            return result;
        }
        //everything else
        else
        {
            if (numbers.Contains(',') || numbers.Contains('\n'))
            {
                //better to separate all the numbers by the commas
                //add to array of strings
                string[] values = numbers.Split(',', '\n');
                var numsConverted = values.Select(int.Parse);
                var sum = numsConverted.Sum();
                return sum;

                /*
                 * Simple way:
                 * var numberOfCommas = numbers.Where(n => n == ',').Count();
                 * 
                 * if(numberOfCommas > 1)
                 * {
                 *    return 6;
                 * 
                 * }
                 * 
                 * var commaAt = numbers.IndexOf(',');
                 * var firstPart = numbers[..commaAt];
                 * var secondpart = numbers[(commAt + 1)..];
                 * 
                 * return int.Parse(firstPart) + int.parse(secondPart);
                 * 
                 * 
                 * numbers.Split(',').Select(int.Parse).Sum()
                 * 
                 * numbers.Split(',', '\n').Select(int.Parse).Sum();
                 * */


                //    //total sum count
                //    int totalSum = 0;

                //    //for every value, do the same as before
                //    //find out if that string is an int and then return that num
                //    foreach (string v in values)
                //    {
                //        //trim is for if there are spaces, or extra char
                //        if (int.TryParse(v.Trim(), out int num))
                //        {
                //            totalSum += num;
                //        }
                //    }

                //    return totalSum;

                //}

                //return 0;

            }

            return 0;

        }
    }
}