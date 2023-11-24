using Godot;
using System;
using System.Collections.Generic;

public partial class MovementInputSystem : ECSSystem
{
	public override void _Ready()
	{
		base.Init(new List<Type>{
			typeof(MovementComponent),
			typeof(MovementInputComponent),
		});
	}

	public override void execute(Entity entity, double delta)
	{
		MovementComponent movementComponent = entity.GetNode<MovementComponent>("MovementComponent");
		MovementInputComponent movementInputComponent = entity.GetNode<MovementInputComponent>("MovementInputComponent");

		Vector2 direction = new Vector2(0, movementComponent.Speed.Y);
		if (Input.IsKeyPressed(Key.D)) {
			direction += Vector2.Right * movementInputComponent.Speed;
		} else if (Input.IsKeyPressed(Key.A)) {
			direction += Vector2.Left * movementInputComponent.Speed;
		}

		movementComponent.Speed = direction;
	}
}