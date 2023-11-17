using Godot;
using System;

public partial class MovementPlayerSystem : Node
{
	private StatsComponent StatsComponent { get; set; }
	private MovementComponent MovementComponent { get; set; }

	public override void _Ready()
	{
		Node2D parent = GetParent<Node2D>();
		
		if (parent == null) {
			Free();
			return;
		}

		StatsComponent = parent.GetNode<StatsComponent>("StatsComponent");
		MovementComponent = parent.GetNode<MovementComponent>("MovementComponent");
	}

	//TODO: migrate to unhandled input???
	public override void _Process(double delta)
	{
		Vector2 direction = new Vector2(0, MovementComponent.Speed.Y);

		if (Input.IsKeyPressed(Key.D)) {
			direction += Vector2.Right * StatsComponent.Speed;
		} else if (Input.IsKeyPressed(Key.A)) {
			direction += Vector2.Left * StatsComponent.Speed;
		}

		MovementComponent.Speed = direction;
	}
}
