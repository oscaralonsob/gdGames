using Godot;
using System;
using System.Collections.Generic;

public partial class CameraMovementRestrictedSystem : ECSSystem
{
	public override void _Ready()
	{
		base.Init(new List<Type>{
			typeof(MovementComponent),
			typeof(CameraMovementRestrictedComponent),
			typeof(Sprite2D),
		});
	}

	public override void execute(Entity entity, double delta)
	{
		MovementComponent movementComponent = entity.GetNode<MovementComponent>("MovementComponent");
		
		Sprite2D sprite2D = entity.GetNode<Sprite2D>("Sprite2D");

		Vector2 cameraOrigin = GetViewport().GetCamera2D().GlobalPosition - GetViewport().GetVisibleRect().Size / 2;
		Vector2 cameraDestination = GetViewport().GetCamera2D().GlobalPosition + GetViewport().GetVisibleRect().Size / 2;
		Vector2 spriteSize = sprite2D.Texture.GetSize() * sprite2D.Scale.X;
		Vector2 spriteOrigin = entity.Position - sprite2D.Texture.GetSize() * sprite2D.Scale.X / 2;
		Vector2 position = entity.Position;

		if (spriteOrigin.X < cameraOrigin.X) {
			position.X = cameraOrigin.X + spriteSize.X / 2;
		} else if (spriteOrigin.X + spriteSize.X > cameraDestination.X) {
			position.X = cameraDestination.X - spriteSize.X / 2;
		} 
		entity.Position = position;
	}
}
