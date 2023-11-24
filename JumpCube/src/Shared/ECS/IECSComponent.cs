using Godot;

public abstract partial class IECSComponent: Node
{
  public string Type => GetType().Name;
}