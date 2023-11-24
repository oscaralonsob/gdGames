using Godot;
using System;
using System.Collections.Generic;

public partial class EndGameSystem : ECSSystem
{
	public override void _Ready()
	{
		base.Init(new List<Type>{});
		EventBus.Instance.PlayerKilled += PauseGame;
	}

	public override void _ExitTree()
	{
		EventBus.Instance.PlayerKilled -= PauseGame;
	}

	private void PauseGame()
	{
		GetTree().Paused = true;
	}

	public override void execute(Entity entity, double delta)
	{
		//Do nothing, only events
	}
}
