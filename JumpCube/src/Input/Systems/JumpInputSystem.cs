using Godot;
using System;
using System.Collections.Generic;

public partial class JumpInputSystem : ECSSystem
{
	//TODO: movement component
	private float MaxFallingSpeed { get; set; } = 500;
	private float FallingAcceleration { get; set; } = 100;

	public override void _Ready()
	{
		base.Init(new List<Type>{
			typeof(MovementComponent),
			typeof(JumpInputComponent),
			typeof(AudioStreamPlayer2D),
		});
	}

	public override void execute(Entity entity, double delta)
	{
		MovementComponent movementComponent = entity.GetNode<MovementComponent>("MovementComponent");
		JumpInputComponent jumpInputComponent = entity.GetNode<JumpInputComponent>("JumpInputComponent");
		AudioStreamPlayer2D audioStreamPlayer2D = entity.GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");

		if (!jumpInputComponent.IsGrounded) {
				float currentFallingVelocity = movementComponent.Speed.Y + (float) delta * FallingAcceleration;
				currentFallingVelocity = -currentFallingVelocity < MaxFallingSpeed ? currentFallingVelocity : MaxFallingSpeed;

				movementComponent.Speed = new Vector2(movementComponent.Speed.X, currentFallingVelocity);
		} else {
			movementComponent.Speed = new Vector2(movementComponent.Speed.X, 0);

			if (Input.IsKeyPressed(Key.Space) && jumpInputComponent.IsGrounded) {
				jumpInputComponent.IsGrounded = false; //TODO: Leave this to the check system
				//TODO: falling and jump two different systems tbh
				float currentFallingVelocity = jumpInputComponent.JumpForce;

				movementComponent.Speed = new Vector2(movementComponent.Speed.X, -currentFallingVelocity);
				audioStreamPlayer2D.Stream = jumpInputComponent.JumpSound;
				audioStreamPlayer2D.Play();
			} 
		}
	}
}
