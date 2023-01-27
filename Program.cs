void MoveToLeft(int[,] matrix)
{
    for (int i = 0; i < 4; i++)
    {
        for (int j = 1; j < matrix.GetLength(1) - 2; j++)
        {
            matrix[i, j] = matrix[i, j + 1];
        }
    }
}

void CreateLine(int[,] matrix)
{
    int lineLength = 4;
    int middle = matrix.GetLength(1) / 2;
    for (int i = 0; i < lineLength; i++)
    {
        matrix[1, (middle - lineLength / 2) + i] = 1;
    }
}

void ShowMenu()
{
    System.Console.WriteLine("Меню выбора действия:");
    System.Console.WriteLine("1 - переместить влево");
    System.Console.WriteLine("2 - переместить вправо");
    System.Console.WriteLine("3 - повернуть");
    System.Console.WriteLine("4 - закончить ход");
    System.Console.WriteLine("5 - выход из игры");
}

void CreateBorder(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        matrix[0, i] = 1;
        matrix[i, 0] = 1;
        matrix[i, matrix.GetLength(1) - 1] = 1;
        matrix[matrix.GetLength(1) - 1, i] = 1;
    }
}

void PrintMatrix(int[,] matrix)
{
    Console.Clear();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] == 0) System.Console.Write("  ");
            else System.Console.Write("+ ");
        }
        System.Console.WriteLine();
    }
}

int border = 20;
int[,] tetrisBoard = new int[border, border];
CreateBorder(tetrisBoard);
CreateLine(tetrisBoard);
int actionNum = 0; 
while (actionNum != 5)
{
    PrintMatrix(tetrisBoard);
    ShowMenu();
    System.Console.Write("Выберите нужный пункт: ");
    actionNum = int.Parse(Console.ReadLine());
    if (actionNum == 1) MoveToLeft(tetrisBoard);
}