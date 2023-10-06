using Godot;
using System;

public partial class LimitManager : ReferenceRect
{
	[Export]
	private ReferenceRect Right { get; set; }
	[Export]
	private ReferenceRect Left { get; set; }
	[Export]
	private PackedScene LimitReference { get; set; }

	public override void _Ready()
	{
		Limit scene = LimitReference.Instantiate<Limit>();
		AddChild(scene);
		scene.Init(Left.Position, Left.Size);

	 	scene = LimitReference.Instantiate<Limit>();
		AddChild(scene);
		scene.Init(Right.Position, Right.Size);
	}
}
