	using Godot;
using System;

public partial class JumpController : Node2D
{
	[Export]
	private int JumpForce { get; set; }
	[Export]
	private double JumpMaxTime { get; set; } //if jumping but time is greater, add force
	private double JumpCurrentTime { get; set; } //if jumping but time is greater, add force
	private bool IsJumping { get; set; }
	private RigidBody2D Parent { get; set; }

	public override void _Ready()
	{
		Parent = GetParent<RigidBody2D>();
		IsJumping = false;
		JumpCurrentTime = 0;
	}

	public override void _Process(double delta)
	{
		if (Parent == null) {
			return;
		}

		if (Input.IsKeyPressed(Key.Space)) {
			if (!IsJumping) {
				Parent.SetAxisVelocity(new Vector2(0, -JumpForce));
				IsJumping = true;
			} else if (JumpCurrentTime < JumpMaxTime) {
				Parent.SetAxisVelocity(new Vector2(0, -JumpForce));
				JumpCurrentTime += delta;
			} else {
				JumpCurrentTime = JumpMaxTime;
			}
		} else if (IsJumping) {
			JumpCurrentTime = JumpMaxTime;
		}
	}
	
	private void OnPlayerBodyEntered(Node body)
	{
		IsJumping = false;
		JumpCurrentTime = 0;
	}
}
