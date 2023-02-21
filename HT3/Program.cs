/*Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
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
           array[i,j] =rnd.Next(lowRange,highRange+1);
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
int [,] MultipleMatrix(int [,] matrixA, int [,] matrixB)
{
    
int [,] Mult = new int [matrixA.GetLength(0),matrixB.GetLength(1)] ;
    for (int i = 0; i < matrixA.GetLength(0); i++)
    {
        for (int j = 0; j < matrixB.GetLength(1); j++)
        {
           for (int k = 0; k < matrixB.GetLength(0); k++)
           {
            Mult [i,j] = Mult[i,j]+matrixA[i,k]*matrixB[k,j] ;
           }
        }
    }
return Mult;
}
int [,] A= InitRandomMatrix();
int [,] B= InitRandomMatrix();
while (true)
    {
        int width = B.GetLength(1);
        int hight = A.GetLength(0);
         if (width==hight)
        {
            break;
        }
        else
        {
            Console.WriteLine("Ошибка ввода, количество строк матрицы А должно совпадать с количеством столбцов матрицы B. Повторите ввод:");
            A= InitRandomMatrix();
            B= InitRandomMatrix();
        }
    }

Console.WriteLine ("Матрица А");
PrintMatrix(A);
Console.WriteLine ();
Console.WriteLine ("Матрица B");
PrintMatrix(B);
Console.WriteLine ();
int [,] C= MultipleMatrix(A,B);
Console.WriteLine ("Матрица А*B");
PrintMatrix(C);