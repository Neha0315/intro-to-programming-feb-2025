

var numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

IEnumerable<int> evens = numbers.Where(x => x % 2 == 0);

numbers[0] = 4;
numbers[2] = 8;
numbers[1] = 5;

foreach (var number in evens.Select(n => n + n))
{
 
    Console.WriteLine(number);
  
}
