class Player : Character
{
    Dictionary<ConsoleKey, string> keyActionMap = new Dictionary<ConsoleKey, string>
    {
        { ConsoleKey.A, "moveLeft" },
        { ConsoleKey.D, "moveRight" },
        { ConsoleKey.Spacebar, "Shoot" },
        { ConsoleKey.T, "Teleport" },
        //{ ConsoleKey.S, "moveDown" },
    };

    public string chosenAction;

    public Player(string name, string avatar) : base(name, avatar)
    {
    }

    public override string ChooseAction()
    {
        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
        chosenAction = keyActionMap.GetValueOrDefault(pressedKey.Key, "pass");

        return chosenAction;
    }
}