using Godot;
using System;

public partial class Limit : Area2D
{
	public void Init(Vector2 position, Vector2 size) 
	{
		Position = new Vector2(position.X, position.Y + size.Y / 2);
		Scale = new Vector2(size.X + 1, size.Y);
	}
}
