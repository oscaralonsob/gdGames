using Godot;

public partial class EventBus: Node
{
  [Signal]
  public delegate void PlayerKilledEventHandler();
  [Signal]
  public delegate void PausedGameEventHandler();
  [Signal]
  public delegate void UnPausedGameEventHandler();
  [Signal]
  public delegate void EntityCreatedEventHandler(Entity entity);
  [Signal]
  public delegate void EntityDeletedEventHandler(Entity entity);

  [Signal]
  public delegate void EntityControlCreatedEventHandler(EntityControl entity);
  [Signal]
  public delegate void EntityControlDeletedEventHandler(EntityControl entity);

  public static EventBus Instance { get; private set; }

  public override void _EnterTree()
  {
    if (Instance == null)
    {
      Instance = this;        
    }
  }
}
