using Godot;
using System;
using System.Collections.Generic;

public partial class RandomEntityGeneratorComponent : IECSComponent
{
  [Export]
  public PackedScene PackedScene { get; private set; }

  [Export]
  public int MaxNumberOfNodes { get; private set; }

  [Export]
  public bool Initialized { get; set; }

  public List<Node> Nodes { get; set; } = new List<Node>();
}
