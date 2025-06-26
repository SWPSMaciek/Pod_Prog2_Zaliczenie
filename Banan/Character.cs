abstract class Character
{
    public string name;
    public Point position;
    public int speed = 1;
    public string avatar;

    public Character(string name, string avatar)
    {
        this.name = name;
        this.avatar = avatar;
    }

    public void Move(Point direction, Level level)
    {
        Point target = position;

        int signX = Math.Sign(direction.x);
        for (int x = 1; x <= Math.Abs(direction.x * speed); x++)
        {
            int coordinateToTest = position.x + x * signX;
            if (level.GetCellVisuals(coordinateToTest, target.y) == '#')
            {
                break;
            }

            target.x = coordinateToTest;
        }

        int signY = Math.Sign(direction.y);
        for (int y = 1; y <= Math.Abs(direction.y * speed); y++)
        {
            int coordinateToTest = position.y + y * signY;
            if (level.GetCellVisuals(target.x, coordinateToTest) == '#')
            {
                break;
            }

            target.y = coordinateToTest;
        }

        // HACK: We have to limit y before limiting x, because we use y to get row's length
        target.y = Math.Clamp(target.y, 0, level.GetHeight() - 1);
        target.x = Math.Clamp(target.x, 0, level.GetRowWidth(target.y) - 1);

        if (level.GetCellVisuals(target.x, target.y) != '#')
        {
            position = target;
            // speed += 1;
        }
    }

    public void Display()
    {
        Console.SetCursorPosition(position.x, position.y);
        Console.Write(avatar);
    }

    public abstract string ChooseAction();
}
