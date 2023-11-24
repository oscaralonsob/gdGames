using Godot;

public partial class JumpInputComponent : IECSComponent
{
	[Export]
	public int JumpForce { private set; get; }

	[Export]
	public bool IsGrounded { set; get; }
}
