using Godot;

public partial class EntityControl : Control
{
	public override void _Ready()
	{
		EventBus.Instance.EmitSignal(EventBus.SignalName.EntityControlCreated, this);
	}

	public override void _ExitTree()
	{
		EventBus.Instance.EmitSignal(EventBus.SignalName.EntityControlDeleted, this);
	}
}
