using Godot;
using System;

public partial class ObjectManager : Node
{
  [Export]
  private double TimeToSpawn { get; set; }
  private double CurrentTimeToSpawn { get; set; }
  private double TimeToDecrease { get; set; }
  private double MaxTimeToDecrease { get; set; }

  public override void _Ready()
  {
    CurrentTimeToSpawn = 0;
    MaxTimeToDecrease = (double)(TimeToSpawn / 3);
    TimeToDecrease = 0.5;
  }

  public override void _Process(double delta)
  {
    CurrentTimeToSpawn -= delta;
    if (CurrentTimeToSpawn < 0) {
      EventBus.Instance.EmitSignal(EventBus.SignalName.SpawnObject);
      if (TimeToSpawn > MaxTimeToDecrease) {
        TimeToSpawn -= TimeToDecrease;
      }
      CurrentTimeToSpawn = TimeToSpawn;
    }
  }
}
