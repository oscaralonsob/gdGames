using Godot;

public partial class Entity : Node2D
{
	public override void _Ready()
	{
		EventBus.Instance.EmitSignal(EventBus.SignalName.EntityCreated, this);
	}

	public override void _ExitTree()
	{
		EventBus.Instance.EmitSignal(EventBus.SignalName.EntityDeleted, this);
	}
}
