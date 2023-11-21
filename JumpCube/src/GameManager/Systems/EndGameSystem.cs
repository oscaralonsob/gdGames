using Godot;
using System;

public partial class EndGameSystem : Node
{
	public override void _Ready()
	{
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
}
