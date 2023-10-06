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

	public override void _Ready()
	{
		ParentNode = GetParent<Node2D>();
		OriginalPosition = ParentNode.Position;
		OriginalDirection = Direction;
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

		GD.Print("Collision happened");
		if (area.IsInGroup("Wall")) {
			Direction = new Vector2(Direction.X, -Direction.Y);
		} else if (area.IsInGroup("Limit")) {
			ParentNode.Position = OriginalPosition;
			Direction = OriginalDirection;
		} 
		/* TODO:
		else if (area.IsInGroup("Paddle")) {
			ParentNode.Position = OriginalPosition;
			Direction = OriginalDirection;
		}*/
	}
}
