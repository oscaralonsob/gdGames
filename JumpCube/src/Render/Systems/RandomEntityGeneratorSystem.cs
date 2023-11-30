using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class RandomEntityGeneratorSystem : ECSSystem
{
	private int offset = 25;
	public override void _Ready()
	{
		base.Init(new List<Type>{
			typeof(RandomEntityGeneratorComponent),
		});
	}

	public override void execute(Entity entity, double delta)
	{
		RandomEntityGeneratorComponent randomEntityGeneratorComponent = entity.GetNode<RandomEntityGeneratorComponent>("RandomEntityGeneratorComponent");
		Vector2 cameraSize = GetViewport().GetVisibleRect().Size;
		Vector2 positionMax = GetViewport().GetCamera2D().GlobalPosition + cameraSize / 2;
		Vector2 positionMin = new Vector2(positionMax.X, positionMax.Y - cameraSize.Y);
		if (!randomEntityGeneratorComponent.Initialized) {
			positionMin = positionMax - cameraSize;
			randomEntityGeneratorComponent.Initialized = true;
		}
		
		int currentEntities = 0;

		foreach (Node node in randomEntityGeneratorComponent.Nodes.ToList()) {
			if (IsInstanceValid(node)) {
				currentEntities++;
			} else {
				randomEntityGeneratorComponent.Nodes.Remove(node);
			}
		}

		while (currentEntities < randomEntityGeneratorComponent.MaxNumberOfNodes) {
			generate(randomEntityGeneratorComponent, getRandomPosition(positionMin, positionMax));
			currentEntities++;
		}
	}

	private void generate(RandomEntityGeneratorComponent randomEntityGeneratorComponent, Vector2 position) {
		Node2D node2D = randomEntityGeneratorComponent.PackedScene.Instantiate<Node2D>();
		node2D.Position = position;
		randomEntityGeneratorComponent.Nodes.Add(node2D);
		GetTree().Root.AddChild(node2D);
	}

	private Vector2 getRandomPosition(Vector2 cameraPositionMin, Vector2 cameraPositionMax) {
		Vector2 position = new Vector2();
		Random random = new Random();

		if (cameraPositionMax.X == cameraPositionMin.X) {
			position.X = cameraPositionMax.X; 
		} else {
			position.X = (float) random.NextDouble() * (cameraPositionMax.X - cameraPositionMin.X) + cameraPositionMin.X;
		}

		position.Y = (float) random.NextDouble() * (cameraPositionMax.Y - cameraPositionMin.Y) + cameraPositionMin.Y + offset;


		return position;
	}
	/*
	* TODO:
	* Crear un helper que sea random y que de random entre el 1 y el 10 (por ejemplo) 
	* Ademas, dado un max y un min, que te lo extrapole. 
	* De esta forma las nubes siempre estaran en las mismas X posiciones pero seran mas "aleatorias"
	*/
}
