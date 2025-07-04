Console.CursorVisible = false;

Dictionary<string, Point> directionsMap = new Dictionary<string, Point>();
directionsMap.Add("moveLeft", new Point(-1, 0));
directionsMap.Add("moveRight", new Point(1, 0));
//directionsMap.Add("moveUp", new Point(0, -1));
//directionsMap.Add("moveDown", new Point(0, 1));

int currentLevelIndex = 0; // Set initial level index here
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
npc2.position = new Point(rand.Next(16, 30), 3);
NonPlayerCharacter npc3 = new NonPlayerCharacter("Yoshi", "Y");
npc3.position = new Point(rand.Next(16, 30), 4);
NonPlayerCharacter npc4 = new NonPlayerCharacter("Toad", "T");
npc4.position = new Point(rand.Next(16, 30), 5);
NonPlayerCharacter npc5 = new NonPlayerCharacter("Thwomp ", "H");
npc5.position = new Point(rand.Next(16, 30), 6);

characters.Add(npc);
characters.Add(npc2);
characters.Add(npc3);
characters.Add(npc4);
characters.Add(npc5);


currentLevel.Display();
foreach (Character element in characters)
{
    element.Display();
}

npc.Display();

while (true)
{
    Console.SetCursorPosition(12, 0);
    Console.Write(hero.speed);

    if (npc.isDead == true)
    {
        if (currentLevelIndex < 5)
        {
            currentLevelIndex++;
            npc.isDead = false;
        }

    }

    switch (currentLevelIndex)
    {
        case 1:
            currentLevel = new Level(1);
            currentLevel.Display();
            npc.isDead = false;
            npc2.isDead = false;
            break;
        case 2:
            currentLevel = new Level(2);
            currentLevel.Display();
            npc.isDead = false;
            npc2.isDead = false;
            npc3.isDead = false;
            break;
        case 3:
            currentLevel = new Level(3);
            currentLevel.Display();
            npc.isDead = false;
            npc2.isDead = false;
            npc3.isDead = false;
            npc4.isDead = false;
            break;
        case 4:
            currentLevel = new Level(4);
            currentLevel.Display();
            npc.isDead = false;
            npc2.isDead = false;
            npc3.isDead = false;
            npc4.isDead = false;
            npc5.isDead = false;
            break;
        case 5:
            currentLevel = new Level(5);
            currentLevel.Display();
            npc.isDead = true;
            npc2.isDead = true;
            npc3.isDead = true;
            npc4.isDead = true;
            npc5.isDead = true;
            break;
    }
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
            if (chosenAction == "Shoot" && npc.position.x == hero.position.x)
            {
                npc.isDead = true;
            }
            continue;
        }
        currentLevel.RedrawCell(element.position);
        Point direction = directionsMap[chosenAction];
        element.Move(direction, currentLevel);
    }
}