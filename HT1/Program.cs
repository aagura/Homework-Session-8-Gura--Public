/* Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2 */
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
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i,j]);
            if (i != matrix.GetLength(0)-1 || j!= matrix.GetLength(1)-1)
            Console.Write(",\t");
        }
        Console.WriteLine();
    }
}

int [,] RangeString (int [,] matrix)
{
    Console.WriteLine("Упорядоченные строки:");
int [,] RangeS = new int [matrix.GetLength(0),matrix.GetLength(1)] ;
int pocket;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            RangeS [i,j] = matrix [i,j];
            for (int k = j ; k < matrix.GetLength(1)-1; k++)
            if (RangeS [i,j] < matrix [i,k+1])
            {
            pocket = RangeS [i,j];
            RangeS [i,j]= matrix [i, k+1] ;
            matrix [i,k+1]= pocket;
            }
        }
        
    }
return RangeS;
}
int [,] matrix= InitRandomMatrix();
PrintMatrix(matrix);
int [,] NewMatrix = RangeString (matrix);
PrintMatrix(NewMatrix);

 