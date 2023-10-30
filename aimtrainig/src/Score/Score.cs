using Godot;
using System;

public partial class Score : Label
{
	private int totalHits = 0;
	private int totalShoots = 0;

	public override void _Ready()
  {
	  EventBus.Instance.TargetHit += OnTargetHit;
	  EventBus.Instance.Shoot += OnShoot;
		PrintScore();
  }

  public void OnTargetHit()
  {
		totalHits++;
		PrintScore();
  }

  public void OnShoot()
  {
		totalShoots++;
		PrintScore();
  }

	private void PrintScore() {
		float accuracy = totalShoots == 0 ? 0 : totalHits  * 100 / totalShoots;
		Text = "Hits: " + totalHits +  "\nShoots: " + totalShoots +  "\nAccuracy: " + accuracy + "%";
	}
}
