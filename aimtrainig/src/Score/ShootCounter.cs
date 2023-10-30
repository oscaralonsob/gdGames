using Godot;
using System;

public partial class ShootCounter : Node
{
	private bool released = true;

	public override void _Process(double delta)
	{
		if (!released && !Input.IsMouseButtonPressed(MouseButton.Left)) {
			released = true;
			return;
		}

		if (released && Input.IsMouseButtonPressed(MouseButton.Left)) {
			released = false;
			EventBus.Instance.EmitSignal(EventBus.SignalName.Shoot);
		}
	}
}
