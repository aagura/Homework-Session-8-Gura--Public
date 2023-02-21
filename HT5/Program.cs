/*.Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
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
int [,] WormMatrix()
{
    int m = GetNumber("Введите m");
    int n = GetNumber("Введите n");
    int [,] matrix = new int [m,n];
     int i=0;
     int j=0;
     matrix [0,0]=1;
    int direction =1;
    for (int position = 2; position <= m*n; position++)
    {
     if (j<n-1 && matrix[i,j+1]==0 && direction ==1) 
     {
     j++;
     direction=1;
     } 
     else
     {
        direction=2;
        if (i<m-1 && matrix[i+1,j]==0 && direction ==2)
        {
            i++;
        }
        else
        {
        direction =3;
            if (j>0 && matrix[i,j-1]==0 && direction ==3)
            {
                j--;
                
            }
            else
            {
                direction=4; 
               if (i>0 && matrix[i-1,j]==0 && direction ==4)
               i--;
            
                else 
               {
                j++;
                 direction=1;

               }
            }

        } 
     }
     matrix [i,j]=position;
    }
    return matrix;
}

PrintMatrix(WormMatrix());
