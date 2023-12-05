using Godot;
using System;

public partial class ContinueButton : Button
{
	public void _OnPressed()
	{
		EventBus.Instance.EmitSignal(EventBus.SignalName.UnPausedGame);
	}
}
