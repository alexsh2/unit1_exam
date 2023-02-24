/*  Написать программу, которая из имеющегося массива строк формирует массив из строк, 
    длина которых меньше либо равна 3 символа.
    Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма. 
    При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

    Примеры:
    ["hello", "2", "world", ":-)"] => ["2", ":-)"]
    ["1234", "1567", "-2", "computer science"] => ["-2"]
    ["Russia", "Denmark", "Kazan"] => []
*/

Console.Clear();

int number = PromptInt("Введите требуемое число строк в массиве");
if (number > 0)
{
    string[] array = new string[number];
    for (int i = 0; i < number; i++)
    {
        array[i] = PromptStr($"Введите {i + 1}-ю строку массива");
    }
    Console.WriteLine();
    Console.WriteLine($"Создан массив строк: {PrintArray(array)}");
    Console.WriteLine();

    string[] resultArray = FormArray(array);
    if (resultArray.Length > 0)
    {
        Console.WriteLine($"Сформирован массив из строк длиной не более 3 символов: {PrintArray(resultArray)}");
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine($"В созданном массиве отсутствуют строки длиной не более 3 символов: {PrintArray(resultArray)}");
        Console.WriteLine();
    }
}
else
{
    Console.WriteLine("Введено некорректное число");
}



// Считывание, проверка и конвертация вводимого числа
int PromptInt(string message)
{
    Console.Write($"{message}: ");
    string? num = Console.ReadLine();

    if (!string.IsNullOrEmpty(num))
    {
        if (int.TryParse(num, out int result))
        {
            return int.Parse(num);
        }
    }
    return 0;
}

// Считывание и проверка вводимой строки
string PromptStr(string message)
{
    Console.Write($"{message}: ");
    string? item = Console.ReadLine();
    if (!string.IsNullOrEmpty(item))
    {
        return item;
    }
    return item = "blank";

}

// Вывод массива
string PrintArray(string[] arr)
{
    string output = "[";
    if (arr.Length == 0)
    {
        output = "[]";
    }
    for (int i = 0; i < arr.Length; i++)
    {
        if (i == arr.Length - 1)
        {
            output = output + $"\"{arr[i]}\"]";
        }
        else
        {
            output = output + $"\"{arr[i]}\", ";
        }
    }
    return output;
}


// Проверка на наличие пустых строк
bool IsNotEmpty(string s)
{
    return !string.IsNullOrEmpty(s);
}

// Формирование массива из строк длиной не более 3-х символов
string[] FormArray(string[] arr)
{
    string[] a = new string[arr.Length];
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i].Length <= 3)
        {
            a[i] = arr[i];
        }
    }

    a = Array.FindAll(a, IsNotEmpty).ToArray();
    return a;
}