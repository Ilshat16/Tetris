void LowDown(int[,] matrix, int[] arrayRow, int[] arrayCol, int num)
{
    int[] arrayLowRow1 = new int[4];
    int[] arrayLowCol1 = new int[4];
    arrayLowCol1[0] = arrayCol[0];
    arrayLowRow1[0] = arrayRow[0];
    int l = 0;
    for (int i = 1; i < arrayCol.Length; i++)
    {
        if (arrayCol[i] == arrayLowCol1[l]) arrayLowRow1[l] = arrayRow[i];
        else
        {
            l++;
            arrayLowCol1[l] = arrayCol[i];
            arrayLowRow1[l] = arrayRow[i];
        }
    }
    int length = 0;
    for (int i = 0; i < arrayLowRow1.Length; i++)
    {
        if (arrayLowRow1[i] == 0 && arrayLowCol1[i] == 0) continue;
        else length++;
    }
    int[] arrayLowCol2 = new int[length];
    int[] arrayLowRow2 = new int[length];
    int k = 0;
    for (int i = 0; i < arrayLowRow1.Length; i++)
    {
        if (arrayLowRow1[i] == 0 && arrayLowCol1[i] == 0) continue;
        else
        {
            arrayLowCol2[k] = arrayLowCol1[i];
            arrayLowRow2[k] = arrayLowRow1[i];
            k++;
        }
    }
    bool down = false;
    System.Console.WriteLine($"{string.Join(", ", arrayLowRow2)}");
    System.Console.WriteLine($"{string.Join(", ", arrayLowCol2)}");
    while (down == false)
    {
        for (int i = arrayRow.Length - 1; i >= 0; i--)
        {
            int ind1 = arrayRow[i];
            int ind2 = arrayCol[i];
            int newInd1 = ind1 + 1;
            matrix[newInd1, ind2] = 1;
            matrix[ind1, ind2] = 0;
            arrayRow[i] = newInd1;
            arrayCol[i] = ind2;
        }
        for (int j = 0; j < arrayLowCol2.Length; j++)
        {
            arrayLowRow2[j]++;
            if (matrix[arrayLowRow2[j] + 1, arrayLowCol2[j]] == 1) down = true;
        }
    }
}

void Rotate(int[,] matrix, int[] arrayRow, int[] arrayCol, int num)
{
    int[,] figreMatrix = new int[4, 4];
    int ind1 = arrayRow[0];
    int ind2 = arrayCol[0];
    for (int i = 0; i < figreMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < figreMatrix.GetLength(1); j++)
        {
            figreMatrix[j, i] = matrix[ind1 + i, ind2 + j];
        }
    }
    int k = 0;
    for (int i = 0; i < figreMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < figreMatrix.GetLength(1); j++)
        {
            int i1 = ind1 + i;
            int i2 = ind2 + j;
            matrix[i1, i2] = figreMatrix[i, j];
            if (matrix[i1, i2] == 1)
            {
                arrayRow[k] = i1;
                arrayCol[k] = i2;
                k++;
            }
        }
    }
}

void MoveToRight(int[,] matrix, int[] arrayRow, int[] arrayCol)
{
    for (int i = arrayRow.Length - 1; i >= 0; i--)
    {
        int ind1 = arrayRow[i];
        int ind2 = arrayCol[i];
        if (ind2 == matrix.GetLength(1) - 2) break;
        int newInd2 = ind2 + 1;
        matrix[ind1, newInd2] = 1;
        matrix[ind1, ind2] = 0;
        arrayRow[i] = ind1;
        arrayCol[i] = newInd2;
    }
}

void MoveToLeft(int[,] matrix, int[] arrayRow, int[] arrayCol)
{
    for (int i = 0; i < arrayRow.Length; i++)
    {
        int ind1 = arrayRow[i];
        int ind2 = arrayCol[i];
        if (ind2 == 1) break;
        int newInd2 = ind2 - 1;
        matrix[ind1, ind2] = 0;
        matrix[ind1, newInd2] = 1;
        arrayRow[i] = ind1;
        arrayCol[i] = newInd2;
    }
}

void CreateCorner(int[,] matrix, int[] arrayRow, int[] arrayCol)
{
    int middle = matrix.GetLength(1) / 2;
    int i = 0;
    int ind1 = 1;
    int ind2 = middle - 2;
    while (i < arrayRow.Length)
    {
        ind2 += 1;
        if (i == 1)
        {
            ind1 = 2;
            ind2 -= 1;
        }
        arrayRow[i] = ind1;
        arrayCol[i] = ind2;
        matrix[ind1, ind2] = 1;
        i++;
    }
}

void CreateZ(int[,] matrix, int[] arrayRow, int[] arrayCol)
{
    int middle = matrix.GetLength(1) / 2;
    int i = 0;
    int ind1 = 1;
    int ind2 = middle - 2;
    while (i < arrayRow.Length)
    {
        ind2 += 1;
        if (i == 2)
        {
            ind1 = 2;
            ind2 -= 1;
        }
        arrayRow[i] = ind1;
        arrayCol[i] = ind2;
        matrix[ind1, ind2] = 1;
        i++;
    }
}

void CreateLine(int[,] matrix, int[] arrayRow, int[] arrayCol)
{
    int lineLength = 4;
    int middle = matrix.GetLength(1) / 2;
    int colInd = 0;
    for (int i = 0; i < lineLength; i++)
    {
        colInd = (middle - lineLength / 2) + i;
        matrix[1, colInd] = 1;
        arrayRow[i] = 1;
        arrayCol[i] = colInd;
    }
}

int ChangeFigure(int[,] matrix, int[] arrayRow, int[] arrayCol)
{
    int numFigure = new Random().Next(3);
    if (numFigure == 0) CreateLine(matrix, arrayRow, arrayCol);
    if (numFigure == 1) CreateZ(matrix, arrayRow, arrayCol);
    if (numFigure == 2) CreateCorner(matrix, arrayRow, arrayCol);
    return numFigure;
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
int[] figurePositionRow = new int[4];
int[] figurePositionCol = new int[4];
CreateBorder(tetrisBoard);
int numFigure = ChangeFigure(tetrisBoard, figurePositionRow, figurePositionCol);
int actionNum = 0;
while (actionNum != 5)
{
    PrintMatrix(tetrisBoard);
    ShowMenu();
    System.Console.Write("Выберите нужный пункт: ");
    actionNum = int.Parse(Console.ReadLine());
    if (actionNum == 1) MoveToLeft(tetrisBoard, figurePositionRow, figurePositionCol);
    if (actionNum == 2) MoveToRight(tetrisBoard, figurePositionRow, figurePositionCol);
    if (actionNum == 3) Rotate(tetrisBoard, figurePositionRow, figurePositionCol, numFigure);
    if (actionNum == 4) LowDown(tetrisBoard, figurePositionRow, figurePositionCol, numFigure);
}