using Godot;
using System;
using System.Collections.Generic;

public partial class ScoreDisplaySystem : ECSSystemControl
{
	private float currentScore { get; set; }
	private float startingPosition { get; set; }
	public override void _Ready()
	{
		base.Init(new List<Type>{
			typeof(PlayerAwareComponent),
			typeof(Label),
			typeof(ScoreDisplayComponent),
		});

		currentScore = 0;
		startingPosition = float.MinValue;
	}

	public override void execute(EntityControl entity, double delta)
	{
		PlayerAwareComponent playerAwareComponent = entity.GetNode<PlayerAwareComponent>("PlayerAwareComponent");
		Label label = entity.GetNode<Label>("Label");

		if (startingPosition == float.MinValue) {
			startingPosition = playerAwareComponent.Player.Position.Y;
		}

		currentScore = (startingPosition - playerAwareComponent.Player.Position.Y) / 1000;

		label.Text = string.Format("{0:0.00}", currentScore) + " m";
	}
}
