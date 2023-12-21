using Godot;
using System;
using System.Collections.Generic;

public partial class PlatformGeneratorComponent : IECSComponent
{
  [Export]
  public PackedScene PackedScene { get; private set; }

  [Export]
  public Vector2 Distance { get; private set; }

  [Export]
  public Vector2 LastPosition { get; set; } = new Vector2(int.MaxValue, int.MaxValue);
}
