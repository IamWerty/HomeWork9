﻿using System.Buffers;
using System.Globalization;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Transactions;

Console.OutputEncoding = Encoding.UTF8;

int[] arr = new int[] { 5, 9, 1, 2, 8, 7, 3, 4, 6, 12};
int[,] arr2D = new int[,] {
    { 1, 2, 7 },
    { 3, 6, 2 },
    { 6, 9, 3 },
    };

#region 1
int temp = 0;
int max = 0;
for (int i = 0; i < arr.Length; i++)
{
    if (arr[i] > max)
    {
        temp = max;
        max = arr[i];
    }
    else if (arr[i] > temp && arr[i] < max)
    {
        temp = arr[i];
    }
}
Console.WriteLine($"Другий елемент за величеною: {temp}");
#endregion

#region 2
int rows = arr2D.GetLength(0);
int cols = arr2D.GetLength(1);
int total = rows * cols;

int[] tempArr2D = new int[total];
int k = 0;

// Заповнюєм темп
for (int i = 0; i < rows; i++)
    for (int j = 0; j < cols; j++)
        tempArr2D[k++] = arr2D[i, j];

// Сортуємо
Array.Sort(tempArr2D);

// Повертаєм лічильник назад
k = 0;

// Присв. нові значення матриці
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < cols; j++)
    {
        arr2D[i, j] = tempArr2D[k++];
    }
}

// Виводимо на екран
Console.WriteLine("Результат сортування: ");
for (int i = 0; i < arr2D.GetLength(0); i++)
{
    for (int j = 0; j < arr2D.GetLength(1); j++)
    {
        Console.Write(arr2D[i, j].ToString().PadLeft(3));
    }
    Console.WriteLine();
}


// Поки-що найважче завдання для розуміння серед всіх що були до цего ＼(ﾟｰﾟ＼)
// Зато як було приємно коли все запрацювало d=(￣▽￣*)
#endregion

#region 3
Console.Write("Який елемент хочете видалити?(0-9): ");
int usernumber = Convert.ToInt16(Console.ReadLine());
int[] tempArr = new int[arr.Length - 1];
k = 0;
for (int i = 0; i < arr.Length; i++)
{
    if (i != usernumber)
    {
        tempArr[k++] = arr[i];
    }
}
foreach (int num in tempArr)
{
    Console.Write(num.ToString().PadLeft(3));
}
Console.WriteLine();
#endregion

#region 4
var matrix = new int[,] {
    {1, 0, 0, 5, 0},
    {0, 1, 0, 0, 5},
    {5, 0, 1, 0, 0},
    {0, 5, 0, 1, 0},
    {0, 0, 5, 0, 1},

};

var sum = 0;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    sum += matrix[i, i];
}
Console.WriteLine($"Сума головної діагоналі матриці: {sum}");
#endregion

#region Додаткові завдання. Непарність елементів
int count = 0;
for (int i = 0; i < arr.Length; i++)
{
    if (arr[i] % 2 != 0)
    {
        count++;
    }
}

if (count == 0)
{
    Console.WriteLine("Немає непарних елементів.");
}
else
{
    int[] notPairnumbers = new int[count];
    k = 0;

    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] % 2 != 0)
        {
            notPairnumbers[k++] = arr[i];
        }
    }

    Console.WriteLine("Непарні елементи:");
    foreach (int num in notPairnumbers)
    {
        Console.Write(num.ToString().PadLeft(3));
    }
    Console.WriteLine();
}
#endregion

#region Додаткові завдання. Транспонування матриці
int row = arr2D.GetLength(0);
int col = arr2D.GetLength(1);
int[,] transpArr = new int[col, row];

for (int i = 0; i < row; i++)
{
    for (int j = 0; j < col; j++)
    {
        transpArr[j, i] = arr2D[i, j];
    }
}

Console.WriteLine("Результат транспортування просортованої матриці:");
for (int i = 0; i < col; i++)
{
    for (int j = 0; j < row; j++)
    {
        Console.Write(transpArr[i, j].ToString().PadLeft(3));
    }
    Console.WriteLine();
}
#endregion

#region Додаткові завдання. Рівність матриць
//Методи ми ще не проходили, тому просто зроблю базовану перевірку матриць ( ﹁ ︿﹁ ) 
int[,] mat1 = {
    {1, 2, 3},
    {4, 5, 6}
};

int[,] mat2 = {
    {1, 2, 3},
    {4, 5, 6}
};
int rowsExtra = mat1.GetLength(0);
int colsExtra = mat1.GetLength(1);

var isEqual = true;
for (int i = 0; i < rowsExtra; i++)
{
    for (int j = 0; j < colsExtra; j++)
    {
        if (mat1[i, j] != mat2[i, j]) // пів години шукав тут помилку, а виявляється що я порівнював mat1 і mat1, тому постійно і писало що матриці рівні (°ロ°)
        {
            isEqual = false;
            break;
        }
    }
}
if (isEqual == true) Console.WriteLine("Матриці рівні."); else if (isEqual == false) Console.WriteLine("Матриці не рівні.");
#endregion