void CreateLine(int[,] matrix)
{
    int lineLength = 4;
    int middle = matrix.GetLength(1) / 2;
    for (int i = 0; i < lineLength; i++)
    {
        matrix[1, (middle - lineLength / 2) + i] = 1;
    }
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
PrintMatrix(tetrisBoard);