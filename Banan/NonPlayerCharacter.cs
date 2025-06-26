class NonPlayerCharacter : Character
{
    private List<string> allowedActions;
    
    public NonPlayerCharacter(string name, string avatar) : base(name, avatar)
    {
        allowedActions = new List<string>
        {
            "moveLeft",
            "moveRight",
            "moveUp",
            "moveDown",
        };
    }

    public override string ChooseAction()
    {
        return allowedActions[Random.Shared.Next(allowedActions.Count)];
    }
}