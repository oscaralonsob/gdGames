using Godot;
using System;

public partial class MovementComponent : Node
{
	[Export]
	public Vector2 Speed { set; get; }

	[Export]
	public bool IsGrounded { set; get; }
}
