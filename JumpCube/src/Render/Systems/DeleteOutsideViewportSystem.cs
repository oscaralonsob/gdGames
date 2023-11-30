using Godot;
using System;
using System.Collections.Generic;

public partial class DeleteOutsideViewportSystem : ECSSystem
{
	public override void _Ready()
	{
		base.Init(new List<Type>{
			typeof(DeleteOutsideViewportComponent),
			typeof(Sprite2D),
		});
	}

	public override void execute(Entity entity, double delta)
	{
		Sprite2D sprite2D = entity.GetNode<Sprite2D>("Sprite2D");

		Vector2 cameraPosition = GetViewport().GetCamera2D().GlobalPosition - GetViewport().GetVisibleRect().Size / 2;
		Vector2 spriteOrigin = entity.Position - sprite2D.Texture.GetSize() / 2;

		if (spriteOrigin.X + sprite2D.Texture.GetSize().X < cameraPosition.X ||
		    spriteOrigin.Y > cameraPosition.Y + GetViewport().GetVisibleRect().Size.Y) {
			deleteEntity(entity);
		}
	}

	private void deleteEntity(Entity entity) 
	{
		entity.Free();
	}
}
