using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public partial class PlatformGeneratorSystem : ECSSystem
{
	PseudoRandomGenerator RandomGenerator { get; set; }

	public override void _Ready()
	{
		base.Init(new List<Type>{
			typeof(PlatformGeneratorComponent),
		});

		RandomGenerator = new PseudoRandomGenerator(100);
	}

	public override void execute(Entity entity, double delta)
	{
		PlatformGeneratorComponent platformGeneratorComponent = entity.GetNode<PlatformGeneratorComponent>("PlatformGeneratorComponent");
		Vector2 cameraSize = GetViewport().GetVisibleRect().Size;
		float currentHeight = GetViewport().GetCamera2D().GlobalPosition.Y;
		float maxHeight = currentHeight - cameraSize.Y/2;

		if (platformGeneratorComponent.LastPosition.Y == int.MaxValue) {
			platformGeneratorComponent.LastPosition = new Vector2((float) Math.Floor(GetViewport().GetCamera2D().GlobalPosition.X), (float) Math.Floor(currentHeight));
		}

		while (platformGeneratorComponent.LastPosition.Y > maxHeight) {
			platformGeneratorComponent.LastPosition = new Vector2(platformGeneratorComponent.LastPosition.X, platformGeneratorComponent.LastPosition.Y - platformGeneratorComponent.Distance.Y);
			Vector2 positionToSpawnMin = platformGeneratorComponent.LastPosition - new Vector2(platformGeneratorComponent.Distance.X,0);
			Vector2 positionToSpawnMax = platformGeneratorComponent.LastPosition + new Vector2(platformGeneratorComponent.Distance.Y,0);
			generate(platformGeneratorComponent, getRandomPosition(positionToSpawnMin, positionToSpawnMax));
		}
	}

	private void generate(PlatformGeneratorComponent platformGeneratorComponent, Vector2 position) {
		Node2D node2D = platformGeneratorComponent.PackedScene.Instantiate<Node2D>();
		node2D.Position = position;
		GetTree().Root.GetNode<Node>("Level").AddChild(node2D);
	}

	private Vector2 getRandomPosition(Vector2 cameraPositionMin, Vector2 cameraPositionMax) {
		Vector2 position = new Vector2
		{
				X = RandomGenerator.Next(cameraPositionMin.X, cameraPositionMax.X),
				Y = RandomGenerator.Next(cameraPositionMin.Y, cameraPositionMax.Y)
		};
		
		return position;
	}
}
