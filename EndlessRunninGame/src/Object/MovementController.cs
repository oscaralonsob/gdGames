using Godot;
using System;

//TODO: probably this will be removed since the movement is done by the background/world
public partial class MovementController : Node2D
{
	[Export]
	private int Speed { get; set; }
	private RigidBody2D Parent { get; set; }
	public override void _Ready()
	{
		Parent = GetParent<RigidBody2D>();
	}

	public override void _Process(double delta)
	{
		if (Parent == null) {
			return;
		}

		Parent.Position = new Vector2(Parent.Position.X - Speed * (float) delta, Parent.Position.Y);

		if (Parent.Position.X < -10) {
			Parent.Free();
		}
	}
}
