using Godot;
using System;

public partial class Paddle : Node2D
{
	public int Player { get; set; }
	public void Init(Vector2 position, Vector2 size, int player = 0)
	{
		Position = new Vector2(position.X - size.X / 2, position.Y - size.X / 2);
		Scale = new Vector2(size.X, size.Y);
		Player = player;
	}
}
