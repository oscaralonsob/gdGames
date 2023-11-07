using Godot;
using System;

//TODO: probably this will be removed since the movement is done by the background/world
public partial class ObjectSpawner : Node
{
  [Export]
  private PackedScene Object { get; set; }
  [Export]
  private Node2D ReferenceToSpawn { get; set; }

  public override void _Ready()
  {
	  EventBus.Instance.SpawnObject += Spawn;
  }

  public override void _ExitTree()
  {
	  EventBus.Instance.SpawnObject -= Spawn;
  }

  public void Spawn() {
    Node2D node = Object.Instantiate<Node2D>();
    Vector2 position = new Vector2(1200, 334);

    node.Position = position;
    GetTree().CurrentScene.AddChild(node);
  }
}
