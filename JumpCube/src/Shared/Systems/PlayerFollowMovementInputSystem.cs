using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerFollowMovementInputSystem : ECSSystem
{
	public override void _Ready()
	{
		base.Init(new List<Type>{
			typeof(MovementComponent),
			typeof(PlayerAwareComponent),
		});
	}


	public override void execute(Entity entity, double delta)
	{
		PlayerAwareComponent playerAwareComponent = entity.GetNode<PlayerAwareComponent>("PlayerAwareComponent");
		MovementComponent movementComponent = entity.GetNode<MovementComponent>("MovementComponent");

		Node2D target = playerAwareComponent.Player;
		if (null != target) {
			Vector2 speed = new Vector2();
			if (target.Position.Y < entity.Position.Y) {
				speed.Y = target.Position.Y - entity.Position.Y;
			}
			speed.X = target.Position.X - entity.Position.X;
			movementComponent.Speed = speed;
		}
	}
}
