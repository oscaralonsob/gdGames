using Godot;
using System;

public partial class JumpPlayerSystem : Node
{
	//TODO movement component
	private float MaxFallingSpeed { get; set; } = 500;
	private float FallingAcceleration { get; set; } = 50;
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
		MovementComponent.IsGrounded = true;
	}

	//TODO: migrate to unhandled input???
	public override void _Process(double delta)
	{
		if (!MovementComponent.IsGrounded) {
			ProcessFalling(delta);
		} else {
			MovementComponent.Speed = new Vector2(MovementComponent.Speed.X, 0);

			if (Input.IsKeyPressed(Key.Space) && MovementComponent.IsGrounded) {
				MovementComponent.IsGrounded = false;
				ProcessJumping();
			} 
		}
	}

	private void ProcessFalling(double delta) 
	{
		float currentFallingVelocity = MovementComponent.Speed.Y + (float) delta * FallingAcceleration;
		currentFallingVelocity = -currentFallingVelocity < MaxFallingSpeed ? currentFallingVelocity : currentFallingVelocity;

		MovementComponent.Speed = new Vector2(MovementComponent.Speed.X, currentFallingVelocity);
	}

	private void ProcessJumping() 
	{
		float currentFallingVelocity = StatsComponent.JumpForce;

		MovementComponent.Speed = new Vector2(MovementComponent.Speed.X, -currentFallingVelocity);
	}
}
