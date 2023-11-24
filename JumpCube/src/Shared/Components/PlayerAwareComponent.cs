using Godot;
using System;

public partial class PlayerAwareComponent : IECSComponent
{
	private Node2D player = null;
	public Node2D Player { 
		get {
			if (null == player) {
				player = GetTree().GetFirstNodeInGroup("Player") as Node2D;
			}

			return player;
		} 
	}
}
