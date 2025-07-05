using System.Security.Cryptography.X509Certificates;

class Level
{
    static List<string[]> allLevelVisuals = new List<string[]>
    {
        new string[]
        {
            "##################################",
            "#12345678901234567890123456789012#",
            "#2...............................#",
            "#3..Kill.enemy.to.spawn.portal...#",
            "#4...............................#",
            "#5...............................#",
            "#6...............................#",
            "#7...............................#",
            "#8...............................#",
            "#9...............................#",
            "#10.Left=A.......................#",
            "#11.Right=D......................#",
            "#12.Shoot=SpaceBar...............#",
            "#13.T=Use.Portal.................#",
            "#14..............................#",
            "#15..............................#",
            "#16..............................#",
            "##################################",
        },
        new string[]
        {
            "##################################",
            "###LEVEL1......................###",
            "###............................###",
            "###............................###",
            "###............................###",
            "###............................###",
            "###............................###",
            "###............................###",
            "###............................###",
            "###............................###",
            "###............................###",
            "###............................###",
            "###............................###",
            "###............................###",
            "###............................###",
            "###............................###",
            "###............................###",
            "##################################",
        },
        new string[]
        {
            "##################################",
            "#####LEVEL2..................#####",
            "#####........................#####",
            "#####........................#####",
            "#####........................#####",
            "#####........................#####",
            "#####........................#####",
            "#####........................#####",
            "#####........................#####",
            "#####........................#####",
            "#####........................#####",
            "#####........................#####",
            "#####........................#####",
            "#####........................#####",
            "#####........................#####",
            "#####........................#####",
            "#####........................#####",
            "##################################",
        },
        // Add more levels here as new string[]
        new string[]
        {
            "##################################",
            "#######LEVEL3..............#######",
            "#######....................#######",
            "#######....................#######",
            "#######....................#######",
            "#######....................#######",
            "#######....................#######",
            "#######....................#######",
            "#######....................#######",
            "#######....................#######",
            "#######....................#######",
            "#######....................#######",
            "#######....................#######",
            "#######....................#######",
            "#######....................#######",
            "#######....................#######",
            "#######....................#######",
            "##################################",
        },
        new string[]
        {
            "##################################",
            "###########LEVEL4......###########",
            "###########............###########",
            "###########............###########",
            "###########............###########",
            "###########............###########",
            "###########............###########",
            "###########............###########",
            "###########............###########",
            "###########............###########",
            "###########............###########",
            "###########............###########",
            "###########............###########",
            "###########............###########",
            "###########............###########",
            "###########............###########",
            "###########............###########",
            "##################################",
        },
        new string[]
        {
            @"#.__....__....................__......__......................#",
            @"#/\.\../\.\................../\.\..__/\.\....................#",
            @"#\.`\`\\/'/.___...__..__.....\.\.\/\.\.\.\....___.....___....#",
            @"#.`\.`\./'./.__`\/\.\/\.\.....\.\.\.\.\.\.\../.__`\./'._.`\..#",
            @"#...`\.\.\/\.\L\.\.\.\_\.\.....\.\.\_/.\_\.\/\.\L\.\/\.\/\.\.#",
            @"#.....\.\_\.\____/\.\____/......\.`\___x___/\.\____/\.\_\.\_\#",
            @"#......\/_/\/___/..\/___/........'\/__//__/..\/___/..\/_/\/_/#",
            @"#............................................................#",
            @"#............................................................#",
            @"#.____.......................................................#",
            @"#/\.._`\.....................................................#",
            @"#\.\,\L\_\.._____......__......___.....__....................#",
            @"#.\/_\__.\./\.'__`\../'__`\.../'___\./'__`\..................#",
            @"#.../\.\L\.\.\.\L\.\/\.\L\.\_/\.\__//\..__/..................#",
            @"#...\.`\____\.\.,__/\.\__/.\_\.\____\.\____\.................#",
            @"#....\/_____/\.\.\/..\/__/\/_/\/____/\/____/.................#",
            @"#.............\.\_\..........................................#",
            @"#..............\/_/..........................................#",
            @"#.____.........................____..........................#",
            @"#/\.._`\....................../\.._`\........................#",
            @"#\.\.\/\_\....___...__..__..__\.\.\L\.\....___...__..__......#",
            @"#.\.\.\/_/_../.__`\/\.\/\.\/\.\\.\.._.<'../.__`\/\.\/\.\.....#",
            @"#..\.\.\L\.\/\.\L\.\.\.\_/.\_/.\\.\.\L\.\/\.\L\.\.\.\_\.\....#",
            @"#...\.\____/\.\____/\.\___x___/'.\.\____/\.\____/\/`____.\...#",
            @"#....\/___/..\/___/..\/__//__/....\/___/..\/___/..`/___/>.\..#",
            @"#..................................................../\___/..#",
            @"#....................................................\/__/...#",
        }
    };

    string[] levelVisuals;
    List<List<Cell>> levelData;
    int portalX = 0;
    public Level(int levelIndex = 0)
    {
        if (levelIndex < 0 || levelIndex >= allLevelVisuals.Count)
            throw new ArgumentOutOfRangeException("levelIndex", "Invalid level index.");
        levelVisuals = allLevelVisuals[levelIndex];
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

    public void LevelSelect(
        ref int currentLevelIndex,
        ref int prewiousLevelIndex,
        ref Level currentLevel,
        List<Character> characters,
        Player hero,
        NonPlayerCharacter npc,
        NonPlayerCharacter npc2,
        NonPlayerCharacter npc3,
        NonPlayerCharacter npc4,
        NonPlayerCharacter npc5,
        Random rand)
    {

        bool AllNpcIsDead = true;

        foreach (var character in characters)
        {
            if (character is NonPlayerCharacter npcChar && !npcChar.isDead)
            {
                AllNpcIsDead = false;
                break;
            }
        }

        if (AllNpcIsDead == true && currentLevelIndex <= 5)
        {
            if (prewiousLevelIndex == currentLevelIndex)
            {
                currentLevelIndex++;
                portalX = rand.Next(11, 22);

            }
            if (prewiousLevelIndex != currentLevelIndex)
            {
                if (currentLevelIndex != 6)
                {
                    Console.SetCursorPosition(portalX, 16);
                    Console.Write("P");
                    Console.SetCursorPosition(0, 0);
                }

                if (hero.position.x == portalX)
                {
                    switch (currentLevelIndex)
                    {
                        case 1:
                            currentLevel = new Level(1);
                            currentLevel.Display();
                            characters.Add(npc2);
                            npc.position = new Point(rand.Next(3, 30), 2);
                            npc2.position = new Point(rand.Next(3, 30), 3);
                            npc.isDead = false;
                            npc2.isDead = false;
                            prewiousLevelIndex = currentLevelIndex;
                            break;
                        case 2:
                            currentLevel = new Level(2);
                            currentLevel.Display();
                            characters.Add(npc3);
                            npc.position = new Point(rand.Next(5, 28), 2);
                            npc2.position = new Point(rand.Next(5, 28), 3);
                            npc3.position = new Point(rand.Next(5, 28), 4);
                            npc.isDead = false;
                            npc2.isDead = false;
                            npc3.isDead = false;
                            prewiousLevelIndex = currentLevelIndex;
                            break;
                        case 3:
                            currentLevel = new Level(3);
                            currentLevel.Display();
                            characters.Add(npc4);
                            npc.position = new Point(rand.Next(7, 26), 2);
                            npc2.position = new Point(rand.Next(7, 26), 3);
                            npc3.position = new Point(rand.Next(7, 26), 4);
                            npc4.position = new Point(rand.Next(7, 26), 5);
                            npc.isDead = false;
                            npc2.isDead = false;
                            npc3.isDead = false;
                            npc4.isDead = false;
                            prewiousLevelIndex = currentLevelIndex;
                            break;
                        case 4:
                            currentLevel = new Level(4);
                            currentLevel.Display();
                            characters.Add(npc5);
                            npc.position = new Point(rand.Next(11, 22), 2);
                            npc2.position = new Point(rand.Next(11, 22), 3);
                            npc3.position = new Point(rand.Next(11, 22), 4);
                            npc4.position = new Point(rand.Next(11, 22), 5);
                            npc5.position = new Point(rand.Next(11, 22), 6);
                            npc.isDead = false;
                            npc2.isDead = false;
                            npc3.isDead = false;
                            npc4.isDead = false;
                            npc5.isDead = false;
                            prewiousLevelIndex = currentLevelIndex;
                            break;
                        case 5:
                            currentLevel = new Level(5);
                            currentLevel.Display();
                            break;
                    }
                }
            }
        }
    }
}