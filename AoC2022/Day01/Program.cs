//IEnumerable<string> input = System.IO.File.ReadLines(@"input_test.txt");
using System.Diagnostics;

IEnumerable<string> input = System.IO.File.ReadLines(@"input.txt");

Stopwatch w1 = new Stopwatch();
w1.Start();

long maxCalories = 0;
long maxCaloriesElfIndex = 0;
long elfCounter = 0;
long calories = 0;

Stack<long> elfsCalories = new Stack<long>();

foreach (string line in input)
{
    if (line != "")
    {
        calories += int.Parse(line);
        continue;
    }

    elfCounter++;

    if (calories > maxCalories)
    {
        maxCalories = calories;
        maxCaloriesElfIndex = elfCounter;
    }

    elfsCalories.Push(calories);
    calories = 0;
}
Console.WriteLine("Elf = " + maxCaloriesElfIndex);
Console.WriteLine("ElfCalories = " + maxCalories);

long[] elfsCaloriesArray = elfsCalories.ToArray();
Array.Sort(elfsCaloriesArray);
Array.Reverse(elfsCaloriesArray);

Console.WriteLine("Top Three Elfs Calories = " + (elfsCaloriesArray[0] + elfsCaloriesArray[1] + elfsCaloriesArray[2]));
w1.Stop();

Console.WriteLine("Elapsed Time = " + (w1.Elapsed.TotalMilliseconds));
