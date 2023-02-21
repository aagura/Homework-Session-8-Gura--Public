/*..Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/
int GetNumber (string message)
{
    int result= 0;
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

int [,,] InitRandomCube()
{
int m;
int n; 
int o;  
while (true)
    {
    m = GetNumber ("Введите количество строк");
    n = GetNumber ("Введите количество столбцов");
    o = GetNumber ("Введите количество уровней");
        if (m>0 && n>0 && o>0)
        {
            break;
        }
        else
        {
            Console.WriteLine("Ошибка ввода, размер матрицы должен быть положительным. Повторите ввод:");
        }
    }

int lowRange =  10;
int highRange =  99;
bool marker;
int [,,] array = new int [m,n,o];
    
Random rnd = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
           for (int k = 0; k < array.GetLength(2); k++)
           {
            while (true)
            {
             array[i,j,k] =rnd.Next(lowRange,highRange+1);
             marker= false;
                for (int i1 = 0; i1 < i; i1++)
                {
                    for (int j1 = 0; j1 < j; j1++)
                    {
                        for (int k1 = 0; k1 < k; k1++)
                        {
                            if (array [i,j,k] == array [i1,j1,k1])
                            marker =true;
                        }
                    }
                }   
            if (marker==false) break;
            }
           }   
        }
     
    }
    return array;
}
void PrintCube(int[,,] matrix)
{
    Console.WriteLine ();
    for (int k = 0; k < matrix.GetLength(2); k++)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int  j= 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i,j,k]}({i},{j},{k})");
                if (i != matrix.GetLength(0)-1 || j!= matrix.GetLength(1)-1 || k!=matrix.GetLength(2)-1)
                Console.Write(", \t");
            }
            Console.WriteLine();
        }
    }
}

int [,,] matrix= InitRandomCube();
PrintCube(matrix);
