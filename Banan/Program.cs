Console.CursorVisible = false;

Dictionary<string, Point> directionsMap = new Dictionary<string, Point>();
directionsMap.Add("moveLeft", new Point(-1, 0));
directionsMap.Add("moveRight", new Point(1, 0));
//directionsMap.Add("moveUp", new Point(0, -1));
//directionsMap.Add("moveDown", new Point(0, 1));

Point startingPoint = new Point(16, 16);
Player hero = new Player("Snake", "@");
hero.speed = 1;
hero.position = startingPoint;

List<Character> characters = new List<Character>();
characters.Add(hero);

Random rand = new Random();
NonPlayerCharacter npc = new NonPlayerCharacter("Liquid", "L");
npc.position = new Point(rand.Next(12,16), rand.Next(2,3));
NonPlayerCharacter npc2 = new NonPlayerCharacter("Mario", "M");
npc2.position = new Point(rand.Next(16,30), rand.Next(1,6));

characters.Add(npc);
characters.Add(npc2);

Level firstLevel = new Level();

firstLevel.Display();

foreach (Character element in characters)
{
    element.Display();
}

npc.Display();

while (true)
{
    Console.SetCursorPosition(12, 0);
    Console.Write(hero.speed);

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
            if (chosenAction == "clone")
            {
                PlayerClone clone = new PlayerClone(hero, "C");
                clone.position = startingPoint;
                characters.Add(clone);
            }

            continue;
        }

        firstLevel.RedrawCell(element.position);

        Point direction = directionsMap[chosenAction];
        element.Move(direction, firstLevel);
    }
}