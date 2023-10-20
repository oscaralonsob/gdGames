using Godot;
using System;

public class PaddleMovementController
{
	private float Speed { get; set; }

	public PaddleMovementController() {
		Speed = 100;//ToDO remove test
	}

	public void move(InputEvent inputEvent, Node2D parent) 
	{
		if (inputEvent is InputEventKey eventKey) {
			if (eventKey.Pressed && eventKey.Keycode == Key.S) {
				parent.Position = Vector2.Down * Speed;
			}
		}
	}
}
