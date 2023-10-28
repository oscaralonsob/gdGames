using Godot;

public partial class EventBus: Node
{
  [Signal]
  public delegate void TargetHitEventHandler();
  [Signal]
  public delegate void ShootEventHandler();

  public static EventBus Instance { get; private set; }

  public override void _EnterTree()
  {
	if (Instance == null)
	{
	  Instance = this;        
	}
  }
}
