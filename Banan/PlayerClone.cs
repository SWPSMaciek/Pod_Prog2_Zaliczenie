class PlayerClone : Player
{
    private Player mothership;
    private List<string> allowedActions;

    public PlayerClone(Player mothership, string avatar) : base(mothership.name, avatar)
    {
        this.mothership = mothership;
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
        if (!allowedActions.Contains(mothership.chosenAction))
        {
            return "pass";
        }
        
        return mothership.chosenAction;
    }
}