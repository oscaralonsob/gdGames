using Godot;
using System;

public partial class MovementComponent : IECSComponent
{
	[Export]
	public Vector2 Speed { set; get; }
}
