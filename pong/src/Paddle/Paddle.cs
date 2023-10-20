using Godot;
using System;

public partial class Paddle : Node2D
{
	public void Init(Vector2 position, Vector2 size)
	{
		Position = new Vector2(position.X - size.X / 2, position.Y - size.X / 2);
		Scale = new Vector2(size.X, size.Y);
	}
}
