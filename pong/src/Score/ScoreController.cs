using Godot;
using System;

public partial class ScoreController : Label
{
  private int Player1Score { get; set; }
  private int Player2Score { get; set; }

  public override void _Ready()
  {
	  EventBus.Instance.GoalScored += OnGoalScored;
  }

  public void OnGoalScored(int player)
  {
	Player1Score += player == 0 ? 1 : 0;
	Player2Score += player == 1 ? 1 : 0;

	Text = "\n" + Player1Score + " - " + Player2Score;
  }
}
