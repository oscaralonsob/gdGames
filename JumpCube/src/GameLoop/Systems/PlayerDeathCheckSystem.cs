using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerDeathCheckSystem : ECSSystem
{
	public override void _Ready()
	{
		base.Init(new List<Type>{
			typeof(PlayerAwareComponent),
			typeof(DeathLimitComponent),
			typeof(Camera2D),
			typeof(AudioStreamPlayer2D),
		});
	}

	public override void execute(Entity entity, double delta)
	{
		PlayerAwareComponent playerAwareComponent = entity.GetNode<PlayerAwareComponent>("PlayerAwareComponent");
		AudioStreamPlayer2D audioStreamPlayer2D = entity.GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
		Camera2D camera2D = entity.GetNode<Camera2D>("Camera2D");

		Node2D target = playerAwareComponent.Player;
		float cameraSize = camera2D.GetViewport().GetVisibleRect().Size.Y / 2;
		if (entity.Position.Y + cameraSize < target.Position.Y) {
			audioStreamPlayer2D.Play();
			EventBus.Instance.EmitSignal(EventBus.SignalName.PlayerKilled);
		}
	}
}
