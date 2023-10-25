using Godot;
using System;

public partial class PaddleManager : ReferenceRect
{
	[Export]
	private ReferenceRect Left { get; set; }
	[Export]
	private ReferenceRect Right { get; set; }
	[Export]
	private PackedScene PaddleReference { get; set; }

	public override void _Ready()
	{
		Paddle scene = PaddleReference.Instantiate<Paddle>();
		AddChild(scene);
		scene.Init(Left.Position + new Vector2(50, 0), new Vector2(10, 50), 1);

	 	scene = PaddleReference.Instantiate<Paddle>();
		AddChild(scene);
		scene.Init(Right.Position - new Vector2(50, 0), new Vector2(10, 50));
	}
}
