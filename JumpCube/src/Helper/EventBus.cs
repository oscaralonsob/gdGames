using Godot;

public partial class EventBus: Node
{
  [Signal]
  public delegate void PlayerMovementEventHandler(Vector2 vector2);

  public static EventBus Instance { get; private set; }

  public override void _EnterTree()
  {
    if (Instance == null)
    {
      Instance = this;        
    }
  }
}
