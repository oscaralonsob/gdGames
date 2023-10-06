using Godot;
using System;

public partial class WallManager : ReferenceRect
{
	[Export]
	private ReferenceRect Bot { get; set; }
	[Export]
	private ReferenceRect Top { get; set; }
	[Export]
	private PackedScene WallReference { get; set; }

	public override void _Ready()
	{
		Wall scene = WallReference.Instantiate<Wall>();
		AddChild(scene);
		scene.Init(Top.Position, Top.Size);

	 	scene = WallReference.Instantiate<Wall>();
		AddChild(scene);
		scene.Init(Bot.Position, Bot.Size);
	}
}
