using Godot;

public partial class EventBus: Node
{
  [Signal]
  public delegate void PlayerKilledEventHandler();

  [Signal]
  public delegate void EntityCreatedEventHandler(Entity entity);

  [Signal]
  public delegate void EntityDeletedEventHandler(Entity entity);

  public static EventBus Instance { get; private set; }

  public override void _EnterTree()
  {
    if (Instance == null)
    {
      Instance = this;        
    }
  }
}
