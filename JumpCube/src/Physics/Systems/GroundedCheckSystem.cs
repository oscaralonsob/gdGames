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
			typeof(AudioStreamPlayer2D),
		});
	}

	public override void execute(Entity entity, double delta)
	{
		Area2D area2D = entity.GetNode<Area2D>("Area2D");
		JumpInputComponent jumpInputComponent = entity.GetNode<JumpInputComponent>("JumpInputComponent");
		GroundedCheckComponent groundedCheckComponent = entity.GetNode<GroundedCheckComponent>("GroundedCheckComponent");
		AudioStreamPlayer2D audioStreamPlayer2D = entity.GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");

		bool alreadyOverlapping = groundedCheckComponent.PreviousFrameWasOverlapping;
		bool overlapping = false;

		if (area2D.HasOverlappingAreas()) {
			foreach (Area2D other in area2D.GetOverlappingAreas()) {
				if (other.GetParent().IsInGroup("Ground")) {
					overlapping = true; 
					if (!alreadyOverlapping) {
						Node2D otherNode = other.GetParent<Node2D>();
						if (otherNode.Position.Y > entity.Position.Y + area2D.GetNode<CollisionShape2D>("CollisionShape2D").Shape.GetRect().Size.Y/2) {
							jumpInputComponent.IsGrounded = true;

							audioStreamPlayer2D.Stream = jumpInputComponent.GroundSound;
							audioStreamPlayer2D.Play();
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
