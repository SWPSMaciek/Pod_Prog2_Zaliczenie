Console.CursorVisible = false;

Dictionary<string, Point> directionsMap = new Dictionary<string, Point>();
directionsMap.Add("moveLeft", new Point(-1, 0));
directionsMap.Add("moveRight", new Point(1, 0));
//directionsMap.Add("moveUp", new Point(0, -1));
//directionsMap.Add("moveDown", new Point(0, 1));

int currentLevelIndex = 0;
int prewiousLevelIndex = 0;
Level currentLevel = new Level(currentLevelIndex);

Point startingPoint = new Point(16, 16);
Player hero = new Player("Cowboy", "@");
hero.isDead = false;
hero.speed = 1;
hero.position = startingPoint;

List<Character> characters = new List<Character>();
characters.Add(hero);

Random rand = new Random();
NonPlayerCharacter npc = new NonPlayerCharacter("Wario", "W");
npc.position = new Point(rand.Next(11, 22), 2);
npc.isDead = false; // Ensure npc2 is not dead
NonPlayerCharacter npc2 = new NonPlayerCharacter("Mario", "M");
NonPlayerCharacter npc3 = new NonPlayerCharacter("Yoshi", "Y");
NonPlayerCharacter npc4 = new NonPlayerCharacter("Toad", "T");
NonPlayerCharacter npc5 = new NonPlayerCharacter("Thwomp ", "H");
characters.Add(npc);

currentLevel.Display();
foreach (Character element in characters)
{
    element.Display();
}

npc.Display();

while (true)
{
    Console.SetCursorPosition(0, 0);

    currentLevel.LevelSelect(ref prewiousLevelIndex, ref currentLevelIndex, ref currentLevel, characters, hero, npc, npc2, npc3, npc4, npc5, rand);

    foreach (Character element in characters)
    {
        element.Display();
    }

    int charactersAmount = characters.Count;
    for (int i = 0; i < charactersAmount; i++)
    {
        Character element = characters[i];
        element.Display();

        string chosenAction = element.ChooseAction();
        if (!directionsMap.ContainsKey(chosenAction))
        {
            if (chosenAction == "Shoot")
            {
                foreach (var character in characters)
                {
                    if (character is NonPlayerCharacter npcChar && !npcChar.isDead && npcChar.position.x == hero.position.x)
                    {
                        npcChar.isDead = true;
                        //Console.SetCursorPosition(npcChar.position.x, npcChar.position.y);
                        //Console.Write("*");
                    }
                }
            }
            continue;
        }
        currentLevel.RedrawCell(element.position);
        Point direction = directionsMap[chosenAction];
        element.Move(direction, currentLevel);
    }
}