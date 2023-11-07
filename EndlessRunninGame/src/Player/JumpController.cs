	using Godot;
using System;

public partial class JumpController : Node2D
{
	[Export]
	private int JumpForce { get; set; }
	private bool IsJumping { get; set; }
	private RigidBody2D Parent { get; set; }

	public override void _Ready()
	{
		Parent = GetParent<RigidBody2D>();
		IsJumping = false;
	}

	public override void _Process(double delta)
	{
		if (Parent == null) {
			return;
		}


		if (Input.IsKeyPressed(Key.Space) && !IsJumping) {
			Parent.ApplyForce(new Vector2(0, -JumpForce));
			IsJumping = true;
		}
	}
	
	private void OnPlayerBodyEntered(Node body)
	{
		IsJumping = false;
	}
}
