using Godot;
using System;

public partial class GroundedCheckSystem : Node
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

	public void _AreaEntered(Area2D area2D) {
		Node2D parentArea = area2D.GetParent<Node2D>();
		if (parentArea.IsInGroup("Ground")) {
			if (parentArea.Position.Y > Parent.Position.Y) {
				MovementComponent.IsGrounded = true;
			}
		}
	}

	public void _AreaExited(Area2D area2D) {
		Node2D parentArea = area2D.GetParent<Node2D>();
		if (parentArea.IsInGroup("Ground")) {
			MovementComponent.IsGrounded = false;
		}
	}
}
