using Godot;
using System;

public partial class target : Node2D
{
	private bool isActive = true;

	public override void _Process(double delta)
	{
		//TODO: kill after some time
	}
	
	
	private void onArea2dInputEvent(Node viewport, InputEvent @event, long shape_idx)
	{
		if (!isActive) {
			return;
		}

		if (@event is InputEventMouseButton eventType) {
			if (eventType.Pressed && eventType.ButtonIndex == MouseButton.Left) {
				isActive = false;
				EventBus.Instance.EmitSignal(EventBus.SignalName.TargetHit);
			}
		}
	}
}
