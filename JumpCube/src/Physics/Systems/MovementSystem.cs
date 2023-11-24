using Godot;
using System;
using System.Collections.Generic;

public partial class MovementSystem : ECSSystem
{
	public override void _Ready()
	{
		base.Init(new List<Type>{
			typeof(MovementComponent)
		});
	}

	public override void execute(Entity entity, double delta)
	{
		MovementComponent movementComponent = entity.GetNode<MovementComponent>("MovementComponent");
		
		entity.Position += movementComponent.Speed * (float) delta;
	}
}
