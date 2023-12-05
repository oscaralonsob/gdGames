using Godot;
using System;
using System.Collections.Generic;

public partial class PauseInputSystem : ECSSystemControl
{
	private bool Holding { get; set; }
	private bool GameIsPause { get; set; }
	public override void _Ready()
	{
		base.Init(new List<Type>{
			typeof(ActivateOnPauseComponent),
		});

		Holding = false;
		GameIsPause = false;
    EventBus.Instance.UnPausedGame += UnPausedGame;
	}
	
	public override void _ExitTree()
	{
    EventBus.Instance.UnPausedGame -= UnPausedGame;
	}

	public override void execute(EntityControl entity, double delta)
	{
    if (Input.IsKeyPressed(Key.Escape)) {
			if (!Holding) {
				if (!GameIsPause) {
					EventBus.Instance.EmitSignal(EventBus.SignalName.PausedGame);
					GetTree().Paused = true;
					GameIsPause = true;
				} else {
					EventBus.Instance.EmitSignal(EventBus.SignalName.UnPausedGame);
				}
			}
			Holding = true;
		} else if(Holding) {
			Holding = false;
		}
	}

  private void UnPausedGame() 
  {
		GetTree().Paused = false;
		GameIsPause = false;
  }
}
