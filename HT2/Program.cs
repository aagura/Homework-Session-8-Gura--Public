/*Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

Например, задан массив:

1 4 7 2

5 9 2 3

8 4 2 4

5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/
int GetNumber (string message)
{
    int result = 0;
    while (true)
    {
        Console.WriteLine (message);
        if (int.TryParse(Console.ReadLine(), out result))
        {
            break;
        }
        else
        {
            Console.WriteLine("Ошибка ввода, вы ввели не число. Повторите ввод:");
        }
    }
    return result;
}

int [,] InitRandomMatrix()
{
int m;
int n;   
while (true)
    {
    m = GetNumber ("Введите количество строк");
    n = GetNumber ("Введите количество столбцов");
        if (m>0 && n>0)
        {
            break;
        }
        else
        {
            Console.WriteLine("Ошибка ввода, размер матрицы должен быть положительным. Повторите ввод:");
        }
    }

int lowRange =  GetNumber ("Введите нижнюю границу диапазона случайных чисел");
int highRange =  GetNumber ("Введите верхнюю границу диапазона случайных чисел");
int [,] array = new int [m,n];
    
    Random rnd = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
           array[i,j] =rnd.Next(lowRange,highRange);
        }
    }
    return array;
}

void PrintMatrix(int[,] matrix)
{
    Console.WriteLine ();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i,j]);
            if (i != matrix.GetLength(0)-1 || j!= matrix.GetLength(1)-1)
            Console.Write(", \t");
        }
        Console.WriteLine();
    }
}
int [] SumColumn(int [,] matrix)
{
    Console.WriteLine("Сумма по строкам");
int [] Sum = new int [matrix.GetLength(0)] ;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Sum [i] = Sum [i] + matrix [i,j];
        }
      
        Console.Write($" {Sum [i]}");
        if (i != matrix.GetLength(0)-1)
            Console.Write(", ");
    }
return Sum;
}
int GetMinIndex (int[] array )
{
    int MinIndex= 0;
    for (int i = 0; i < array.Length-1; i++)
    {
        if (array[i] > array [i+1])
        {
            MinIndex =i+1;
        }
        else
        {
          array [i+1] = array [i];
        }
    }
    return MinIndex;
}
int [,] matrix= InitRandomMatrix();
PrintMatrix(matrix);
int [] SumC= SumColumn (matrix);
Console.WriteLine ();
Console.WriteLine($"Номер строки с наименьшей суммой элементов: {GetMinIndex(SumC)} строка");