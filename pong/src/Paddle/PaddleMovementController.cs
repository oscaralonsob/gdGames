using Godot;
using System;

public partial class PaddleMovementController: Node
{
	[Export]
	private Paddle Parent { get; set; }
	private float Speed { get; set; }

	public override void _Ready() 
	{
		Speed = 100;
	}

	public override void _PhysicsProcess(double delta)
	{
		if (Parent.Player == 1) {
			MovePlayer1Paddle(delta);
		} else if (Parent.Player == 2) {
			MovePlayer2Paddle(delta);
		} else if (Parent.Player == 0) {
			MoveIAPaddle(delta);
		}
	}

	private void MovePlayer1Paddle(double delta) 
	{
		Vector2 direction = Vector2.Zero;

		if (Input.IsKeyPressed(Key.S)) {
			direction += Vector2.Down;
		} else if (Input.IsKeyPressed(Key.W)) {
			direction += Vector2.Up;
		}

		Parent.Position += direction* Speed * (float) delta;
	}

	private void MovePlayer2Paddle(double delta) 
	{
		Vector2 direction = Vector2.Zero;

		if (Input.IsKeyPressed(Key.Down)) {
			direction += Vector2.Down;
		} else if (Input.IsKeyPressed(Key.Up)) {
			direction += Vector2.Up;
		}

		Parent.Position += direction* Speed * (float) delta;
	}

	private void MoveIAPaddle(double delta) 
	{
		Node2D ball = GetTree().Root.GetNode<Node>("Level").GetNode<Node2D>("Ball");
		Vector2 direction = Parent.Position.Y < ball.Position.Y ? Vector2.Down : Vector2.Up;

		Parent.Position += direction* Speed * (float) delta;
	}
}
