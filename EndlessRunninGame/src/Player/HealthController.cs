using Godot;
using System;

public partial class HealthController : Node2D
{
	private void OnPlayerBodyEntered(Node body)
	{
		if (body.IsInGroup("Object")) {
			EventBus.Instance.EmitSignal(EventBus.SignalName.PlayerKilled);
		}
	}
}
