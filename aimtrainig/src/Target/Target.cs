using Godot;
using System;

public partial class Target : Node2D
{
	private double lifeTimeLeft = 1000;
	private bool isActive = true;

	public override void _Ready()
	{
		EventBus.Instance.TargetHit += OnTargetHit;
		EventBus.Instance.TimeElapsed += OnTargetHit;
	}

	public override void _Process(double delta)
	{
		lifeTimeLeft -= delta * 1000;
		if (lifeTimeLeft < 0) {
			EventBus.Instance.EmitSignal(EventBus.SignalName.TimeElapsed);
		} 
		GD.Print(lifeTimeLeft);
	}

	public void SetLifeTime(double miliseconds)
	{
		lifeTimeLeft = miliseconds;
	}
	
	
	private void onArea2dInputEvent(Node viewport, InputEvent @event, long shape_idx)
	{
		if (!isActive) {
			return;
		}

		if (@event is InputEventMouseButton eventType) {
			if (eventType.Pressed && eventType.ButtonIndex == MouseButton.Left) {
				EventBus.Instance.EmitSignal(EventBus.SignalName.TargetHit);
			}
		}
	}

	private void OnTargetHit() {
		if(!isActive) {
			return;
		}
		isActive = false;
		QueueFree();
	}
}
