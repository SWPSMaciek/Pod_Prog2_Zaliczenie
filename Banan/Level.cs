class Level
{
    string[] levelVisuals =
    [
        "##################################",
        "#12345678901234567890123456789012#",
        "#2...............................#",
        "#3...............................#",
        "#4...............................#",
        "#5...............................#",
        "#6...............................#",
        "#7...............................#",
        "#8...............................#",
        "#9...............................#",
        "#10..............................#",
        "#11..............................#",
        "#12..............................#",
        "#13..............................#",
        "#14..............................#",
        "#15..............................#",
        "#16..............................#",
        "##################################",
    ];

    List<List<Cell>> levelData;

    public Level()
    {
        levelData = new List<List<Cell>>();
        
        for (int y = 0; y < levelVisuals.Length; y++)
        {
            List<Cell> row = new List<Cell>();
            for (int x = 0; x < levelVisuals[y].Length; x++)
            {
                char cellVisuals = levelVisuals[y][x];
                Cell cell = new Cell(cellVisuals);
                row.Add(cell);
            }
            levelData.Add(row);
        }
    }


    public void Display()
    {
        foreach (List<Cell> row in levelData)
        {
            foreach (Cell cell in row)
            {
                cell.Display();
            }
            Console.WriteLine();
        }
    }

    public char GetCellVisuals(int x, int y)
    {
        return levelVisuals[y][x];
    }

    public int GetHeight()
    {
        return levelVisuals.Length;
    }

    public int GetRowWidth(int rowNumber)
    {
        return levelVisuals[rowNumber].Length;
    }
    
    public void RedrawCell(Point position)
    {
        Console.SetCursorPosition(position.x, position.y);
        char cellValue = GetCellVisuals(position.x, position.y);
        Console.Write(cellValue);
    }
}