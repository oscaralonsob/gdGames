using Godot;
using System;

public partial class Score : Label
{
	private double CurrentScore { get; set; }
	public override void _Ready()
	{
		CurrentScore = 0;
		Text = "Score: 0";
	}

	public override void _Process(double delta)
	{
		CurrentScore += delta;
		Text = "Score: " + (int) (CurrentScore*10);
	}
}
