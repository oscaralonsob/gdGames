using Godot;
using System;

public partial class TargetManager : ReferenceRect
{
	[Export]
	private PackedScene Target;
	private bool TargetActive = false;
	private Random RNG = new Random();
	private int Offset = 50;
	private double LifeTimeInMiliseconds = 5000;
	private double MinimumLifeTimeInMiliseconds = 1000;
	private double DecreasingLifeTimeInMiliseconds = 100;

	public override void _Ready()
	{
		EventBus.Instance.TargetHit += OnTargetHit;
		EventBus.Instance.TimeElapsed += OnTargetMiss;
	}

	public override void _Process(double delta)
	{
		if (!TargetActive && Target != null) {
			Target target = Target.Instantiate<Target>();
			target.Position = GetRandomPosition();
			target.SetLifeTime(LifeTimeInMiliseconds);
			GetParent().AddChild(target);
			TargetActive = true;
		}
	}

	private Vector2 GetRandomPosition() {
		Vector2 vector = new Vector2(0, 0);
		vector.X = RNG.Next((int) Position.X + Offset, (int) Size.X - Offset);
		vector.Y = RNG.Next((int) Position.Y + Offset, (int) Size.Y - Offset);
		return vector;
	}

	private void OnTargetHit() {
		TargetActive = false;
		LifeTimeInMiliseconds = LifeTimeInMiliseconds > MinimumLifeTimeInMiliseconds ? LifeTimeInMiliseconds - DecreasingLifeTimeInMiliseconds : LifeTimeInMiliseconds;
	}

	private void OnTargetMiss() {
		TargetActive = false;
	}
}
