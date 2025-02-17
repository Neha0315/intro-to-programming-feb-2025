
using System.Text.RegularExpressions;
public class Calculator
{
    //old Add method(first version)
    public int Add2(string numbers)
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
            if (numbers.Contains(",") || numbers.Contains("\n"))
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
                    if (int.TryParse(v.Trim(), out int num))
                    {
                        totalSum += num;
                    }
                }
                return totalSum;
            }
            return 0;
        }
    }


    //old add method
    //second version
    public int Add3(string numbers)
    {
        if (numbers == "")
        {
            return 0;
        }
        else if (int.TryParse(numbers, out int result))
        {
            return result;
        }
        else
        {
            string allDelimiters = ",\n";
            //check for custom delimiters
            if (numbers.StartsWith("//"))
            {
                int delimiterEndIndex = numbers.IndexOf('\n');
                if (delimiterEndIndex != -1)
                {
                    //get the custom delimiter
                    //delimiter is at the beginning after the //
                    string customDelimiter = numbers.Substring(2, delimiterEndIndex - 2);
                    allDelimiters += customDelimiter;
                }
            }

            return numbers.Split(allDelimiters.ToCharArray()).Select(int.Parse).Sum();


        }

    }

    //updated add method with all test cases 1-11 work
    public int Add(string numbers)
    {
        if (numbers == "")
        {
            return 0;
        }

        //list for all delimiters first
        List<string> delimiters = new List<string> { ",", "\n" };

        //save in another to not modify main one; fixed issue here
        string numbersValues = numbers;

        //find the custom delimiters
        if (numbers.StartsWith("//"))
        {
            //get the ending index
            int delimiterEndIndex = numbers.IndexOf('\n');
            if (delimiterEndIndex != -1)
            {
                string delimiterSection = numbers.Substring(2, delimiterEndIndex - 2);

                // square brackets test case handle here
                if (delimiterSection.StartsWith("[") && delimiterSection.EndsWith("]"))
                {
                    //get delimiters in square brackets
                    var matches = Regex.Matches(delimiterSection, @"\[(.*?)\]");
                    foreach (Match match in matches)
                    {
                        delimiters.Add(match.Groups[1].Value);
                    }
                }
                else
                {
                    //1 char delimiter
                    delimiters.Add(delimiterSection);
                }

                numbersValues = numbers.Substring(delimiterEndIndex + 1);
            }
        }

        //split nums as before
        string[] numberStrings = numbersValues.Split(delimiters.ToArray(), StringSplitOptions.None);

        //filter out nums greater than 1000
        int[] filteredNumbers = numberStrings.Select(int.Parse).Where(n => n <= 1000).ToArray();

        //check for negatives
        var negativeNumbers = filteredNumbers.Where(n => n < 0).ToArray();
        if (negativeNumbers.Any())
        {
            throw new ArgumentException("Negatives not allowed: " + string.Join(", ", negativeNumbers));
        }

        //sum the nums
        return filteredNumbers.Sum();
    }
}