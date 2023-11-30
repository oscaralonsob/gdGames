using Godot;
using System;
using System.Collections.Generic;

//I think this can be problematic when multiple collisions
public partial class GroundedCheckSystem : ECSSystem
{
	public override void _Ready()
	{
		base.Init(new List<Type>{
			typeof(GroundedCheckComponent),
			typeof(JumpInputComponent), //TODO: move to ground check
			typeof(Area2D),
		});
	}

	public override void execute(Entity entity, double delta)
	{
		Area2D area2D = entity.GetNode<Area2D>("Area2D");
		JumpInputComponent jumpInputComponent = entity.GetNode<JumpInputComponent>("JumpInputComponent");
		GroundedCheckComponent groundedCheckComponent = entity.GetNode<GroundedCheckComponent>("GroundedCheckComponent");
		bool alreadyOverlapping = groundedCheckComponent.PreviousFrameWasOverlapping;
		bool overlapping = false;

		if (area2D.HasOverlappingAreas()) {
			foreach (Area2D other in area2D.GetOverlappingAreas()) {
				if (other.GetParent().IsInGroup("Ground")) {
					overlapping = true; 
					if (!alreadyOverlapping) {
						Node2D otherNode = other.GetParent<Node2D>();
						if (otherNode.Position.Y > entity.Position.Y) {
							jumpInputComponent.IsGrounded = true;
						}
					}
				}
			}
		}

		if (alreadyOverlapping && !overlapping) {
			jumpInputComponent.IsGrounded = false;
		}
		groundedCheckComponent.PreviousFrameWasOverlapping = overlapping;
	}
}