using Godot;
using System;

public partial class CameraMovementInputSystem : Node
{
	private Node2D Parent { get; set; }
	private MovementComponent MovementComponent { get; set; }
	private PlayerAwareComponent PlayerAwareComponent { get; set; }

	public override void _Ready()
	{
		Parent = GetParent<Node2D>();
		
		if (Parent == null) {
			Free();
			return;
		}

		MovementComponent = Parent.GetNode<MovementComponent>("MovementComponent");
		PlayerAwareComponent = Parent.GetNode<PlayerAwareComponent>("PlayerAwareComponent");
	}

	public override void _Process(double delta)
	{
		Node2D target = PlayerAwareComponent.Player;
		if (null != target) {
			UpdateSpeed(target.Position);
		}
	}

  private void UpdateSpeed(Vector2 targetPosition) {
		Vector2 speed = new Vector2();
    if (targetPosition.Y < Parent.Position.Y) {
			speed.Y = targetPosition.Y - Parent.Position.Y;
		}
		speed.X = targetPosition.X - Parent.Position.X;
		MovementComponent.Speed = speed;
  }
}
