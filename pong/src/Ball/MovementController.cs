using Godot;
using System;

public partial class MovementController : Node2D
{
	[Export] 
	private float Speed { get; set; }
	
	[Export]
	private Vector2 Direction { get; set; }
	
	private Node2D ParentNode { get; set; }
	private Vector2 OriginalPosition { get; set; }
	private Vector2 OriginalDirection { get; set; }
	private float OriginalSpeed { get; set; }

	public override void _Ready()
	{
		ParentNode = GetParent<Node2D>();
		OriginalPosition = ParentNode.Position;
		OriginalDirection = Direction;
		OriginalSpeed = Speed;
		//TODO: check null or empty (no init in editor maybe?)
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Direction * Speed * (float)delta;

		ParentNode.Position += velocity;
	}

	//TODO: when looking for points and pausing the game, this can be extracted so more logic that has nothing to do with movement can be added
	public void _OnArea2DAreaEntered(Area2D area)
	{
		if (area.IsInGroup("Wall")) {
			Direction = new Vector2(Direction.X, -Direction.Y);
			Speed *= 1.2f;
		} else if (area.IsInGroup("Limit")) {
			ParentNode.Position = OriginalPosition;
			Direction = OriginalDirection;
			Speed = OriginalSpeed;
			EventBus.Instance.EmitSignal(EventBus.SignalName.GoalScored, area.Position.X < OriginalPosition.X);
		} else if (area.IsInGroup("Paddle")) {
			Direction = new Vector2(-Direction.X, Direction.Y);
			Speed *= 1.2f;
		}
	}
}
