using Godot;
using System;

public partial class RestartLabel : Label
{
	private bool IsPaused { get; set; }
	public override void _Ready()
	{
		IsPaused = false;
		EventBus.Instance.PlayerKilled += PauseGame;
	}

	public override void _ExitTree()
  {
	  EventBus.Instance.PlayerKilled -= PauseGame;
  }

	public override void _Process(double delta)
	{
		if (!IsPaused)
			return;

		if (Input.IsKeyPressed(Key.Space)) {
			GetTree().ReloadCurrentScene();
			GetTree().Paused = false;
		}
	}

	public void PauseGame() {
		GetTree().Paused = true;
		Text = "Press Space to restart the game";
		IsPaused = true;
  }
}
