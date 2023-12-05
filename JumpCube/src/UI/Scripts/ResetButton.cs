using Godot;
using System;

public partial class ResetButton : Button
{
	public void _OnPressed()
	{
		EventBus.Instance.EmitSignal(EventBus.SignalName.UnPausedGame);
		GetTree().ReloadCurrentScene();
	}
}
