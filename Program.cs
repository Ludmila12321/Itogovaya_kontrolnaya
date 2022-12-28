// Написать программу, которая из имеющегося массива строк формирует массив из строк, 
// длина которых меньше либо равна 3 символа. 
// Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма.
int EnterNumber(string text) // Метод "Проверка является ли введённое значение числом"
{
    int num;
Link1: //Метка возвращения в случае ошибочного ввода
    Console.WriteLine(text);
    string? n = Console.ReadLine();
    if (int.TryParse(n, out num) == false)
    {
        Console.WriteLine("Значение не является числом, начните заново");
        goto Link1;
    }
    return num;
}
Console.WriteLine("Каким образом заполнять массив?");
int Vybor = EnterNumber("Нажмите 1 для заполнения массива вручную или 2 для значений по умолчанию");
if (Vybor != 1 && Vybor != 2)
    do
    {
        Console.WriteLine("Выбор не понятен");
        Vybor = EnterNumber("Нажмите 1 для заполнения массива вручную или 2 для значений по умолчанию");
    }
    while (Vybor != 1 && Vybor != 2);
string[] EnterarrString; // Временный массив для ручного ввода
string[] arrString; // Массив, с которым проводится основная работа
if (Vybor == 1)
{                                   // Ввод массива строк вручную
    int SizeMass = EnterNumber("Введите размер массива");
    EnterarrString = new string[SizeMass];
    for (int i = 0; i < SizeMass; i++)
    {
        Console.WriteLine($"Введите {i + 1}-й элемент массива");
        EnterarrString[i] = Console.ReadLine();
    }
    arrString = EnterarrString; // Передаём значение временного массива в основной рабочий
}
else
{              // Временный массив для значений по умолчанию
    string[] DefaultarrString = { "hello", "2", "world", ":-)", "1234", "1567", "-2", "computer science", "abc", "Russia" };
    arrString = DefaultarrString;
}
string[] ResultarrString = new string[0]; // Итоговый массив, элементы которого удовлетворяют условию задачи
string[] ResultTemparrString; // Временный массив для подсчёта кол-ва элементов, удовлетворяющих условию,
int count = 0;                  // нужный для того, чтобы задать размер итогового массива 
Console.Write("Заданный массив: ");
Console.Write("[");
for (int i = 0; i < arrString.Length - 1; i++) // Вывод на экран заданного массива
    Console.Write(" " + arrString[i] + ",");
Console.WriteLine(" " + arrString[arrString.Length - 1] + " ]");
for (int i = 0; i < arrString.Length; i++)
    if (arrString[i].Length <= 3) // Подсчёт элементов < или = 3 и запись их через вспомогательный в итоговый массив
    {
        count++;                        
        ResultTemparrString = new string[count];
        for (int j = 0; j < ResultTemparrString.Length - 1; j++)
            ResultTemparrString[j] = ResultarrString[j];
        ResultTemparrString[count - 1] = arrString[i];
        ResultarrString = ResultTemparrString;
    }
if (ResultarrString.Length == 0) // Проверка наличия удовлетворяющих условию элементов
    Console.Write("Таких строк, увы нет");
else
{
    Console.Write("Полученный массив: "); // Вывод итогового массива
    Console.Write("[");
    for (int i = 0; i < ResultarrString.Length - 1; i++)
        Console.Write(" " + ResultarrString[i] + ",");
    Console.WriteLine(" " + ResultarrString[ResultarrString.Length - 1] + " ]");
}
