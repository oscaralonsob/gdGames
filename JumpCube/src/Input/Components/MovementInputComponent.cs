using Godot;

public partial class MovementInputComponent : IECSComponent
{
  [Export]
	public int Speed { private set; get; }
}
