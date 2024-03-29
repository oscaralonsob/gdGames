using Godot;

public partial class EventBus: Node
{
  [Signal]
  public delegate void GoalScoredEventHandler(int player);

  public static EventBus Instance { get; private set; }

  public override void _EnterTree()
  {
    if (Instance == null)
    {
      Instance = this;        
    }
  }
}
