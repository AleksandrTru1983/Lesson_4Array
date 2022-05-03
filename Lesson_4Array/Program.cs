bool retry = true;

while (retry)

{
    var lenght = Getinput("\nВведите количество элементов массива: ");
    Getinput1("Введите элементы массива: ", lenght);
    Refresh(ref retry);
}



static int Getinput(string str) // пишем метод для проверки на корректность данных извне
{

    Console.Write($"{str} ");
    int lenght = 0;
    string input = Console.ReadLine();
    bool converted = int.TryParse(input, out lenght); // проверка вводимых данных на корректность

    while (!converted) // для особо "упорных" пишем цикл while и принуждаем ввести корректные данные, переменная converted должна быть true, для выхода из цикла
    {
        Console.Write("введите корректное значение: ");
        input = Console.ReadLine();
        converted = int.TryParse(input, out lenght);

    }
    while (lenght < 2) // еще одна защита от дурака
    {
        Console.WriteLine("длина массива должна быть не менее [2]");
        Console.Write("введите корректное значение: ");
        input = Console.ReadLine();
        converted = int.TryParse(input, out lenght);

    }
    return lenght;
}

static int Getinput1(string str1, int lenght) //пишем второй метод, передаем в него корректное значение длины массива, создаем массив
{
    var value = 0;
    Console.WriteLine(str1);
    int[] array = new int[lenght];

    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"введите число [{i}] =");
        array[i] = Getinput(""); // передаем в цикл метод getinput, для проверки корректности вводимых данных
    }

    Console.WriteLine("\nОтсортированный массив: \n");
    Array.Sort(array); // сортируем по "возрастанию" полученные данные массива

    foreach (int i in array) // используем цикл foreach, перебираем отсортированный массив
        Console.Write($"[{i}]");

    int currentValue = array[lenght - 2]; // присваиваем переменной currentValue 2-ое с конца значение отсортированного массива (условие задачи)
    Console.WriteLine($"\nзапрашиваемое число: {currentValue}");

    return value;
}



static bool Refresh(ref bool retry)
{
    while (retry)
    {
        Console.WriteLine("повторим Y/N?");
        string value = Console.ReadLine();

        if (value == "Y" || value == "y" || value == "Н" || value == "н")
        {
            var lenght = Getinput("Введите количество элементов массива: ");
            Getinput1("Введите элементы массива: ", lenght);
        }
        else
            retry = false;
    }

    return retry;
}


