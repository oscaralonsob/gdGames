using Godot;
using System;
using System.Collections.Generic;

public partial class ActivateOnPauseSystem : ECSSystemControl
{
  private bool GameIsPause { get; set; }
	public override void _Ready()
	{
		base.Init(new List<Type>{
			typeof(ActivateOnPauseComponent),
		});

    GameIsPause = false;
    EventBus.Instance.PausedGame += PausedGame;
    EventBus.Instance.UnPausedGame += UnPausedGame;
	}

  public override void _ExitTree()
	{
    EventBus.Instance.PausedGame -= PausedGame;
    EventBus.Instance.UnPausedGame -= UnPausedGame;
	}

	public override void execute(EntityControl entity, double delta)
	{
    entity.Visible = GameIsPause;
	}

  private void PausedGame() 
  {
    GameIsPause = true;
  }

  private void UnPausedGame() 
  {
    GameIsPause = false;
  }
}
