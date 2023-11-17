using Godot;
using System;

public partial class MovementSystem : Node
{
	private Node2D Parent { get; set; }
	private MovementComponent MovementComponent { get; set; }

	public override void _Ready()
	{
		Parent = GetParent<Node2D>();
		
		if (Parent == null) {
			Free();
			return;
		}

		MovementComponent = Parent.GetNode<MovementComponent>("MovementComponent");
	}

	public override void _Process(double delta)
	{
		Parent.Position += MovementComponent.Speed * (float) delta;
		EventBus.Instance.EmitSignal(EventBus.SignalName.PlayerMovement, Parent.Position);
	}
}
