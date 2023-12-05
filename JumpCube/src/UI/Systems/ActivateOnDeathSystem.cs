using Godot;
using System;
using System.Collections.Generic;

public partial class ActivateOnDeathSystem : ECSSystemControl
{
  private bool PlayerKilled { get; set; }
	public override void _Ready()
	{
		base.Init(new List<Type>{
			typeof(ActivateOnDeathComponent),
		});

    PlayerKilled = false;
    EventBus.Instance.PlayerKilled += PlayerKilledEvent;
    EventBus.Instance.UnPausedGame += UnPausedGame;
	}

  public override void _ExitTree()
	{
    EventBus.Instance.PlayerKilled -= PlayerKilledEvent;
    EventBus.Instance.UnPausedGame -= UnPausedGame;
	}

	public override void execute(EntityControl entity, double delta)
	{
    entity.Visible = PlayerKilled;
	}

  private void PlayerKilledEvent() 
  {
    PlayerKilled = true;
  }

  private void UnPausedGame() 
  {
    PlayerKilled = false;
  }
}
