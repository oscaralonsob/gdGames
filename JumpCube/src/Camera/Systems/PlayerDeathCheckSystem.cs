using Godot;
using System;

public partial class PlayerDeathCheckSystem : Node
{
	private Node2D Parent { get; set; }
	private PlayerAwareComponent PlayerAwareComponent { get; set; }

	public override void _Ready()
	{
		Parent = GetParent<Node2D>();
		
		if (Parent == null) {
			Free();
			return;
		}

		PlayerAwareComponent = Parent.GetNode<PlayerAwareComponent>("PlayerAwareComponent");
	}

	public override void _Process(double delta)
	{
		Node2D target = PlayerAwareComponent.Player;
		float cameraSize = GetViewport().GetVisibleRect().Size.Y / 2;
		if (Parent.Position.Y + cameraSize < target.Position.Y) {
			EventBus.Instance.EmitSignal(EventBus.SignalName.PlayerKilled);
		}
	}
}
