using System;
using System.Collections.Generic;
using Godot;

public abstract partial class ECSSystem: Node
{
  protected List<Entity> Entities { get; private set; }
  protected List<Type> Components { get; private set; }

	public abstract void execute(Entity entity, double delta);
	public override abstract void _Ready();

	public override void _EnterTree()
	{
		EventBus.Instance.EntityCreated += entityCreated;
	}

	public override void _ExitTree()
	{
		EventBus.Instance.EntityCreated -= entityCreated;
	}

	protected void Init(List<Type> components)
	{
		Entities = new List<Entity>();
		Components = components;
	}

	public override void _PhysicsProcess(double delta)
	{
		foreach (Entity entity in Entities) {
			execute(entity, delta);
		}
	}

	private void AddEntity(Entity entity) 
	{
		Entities.Add(entity);
	}

	private void RemoveEntity(Entity entity) 
	{
		Entities.Remove(entity);
	}

	private bool IsInterestedEntity(Entity entity)
	{
		foreach (Type component in Components) {
			if (!entity.HasNode(component.Name)) {
				return false;
			}
		}
		return true;
	}

	private void entityCreated(Entity entity) 
	{
		if (IsInterestedEntity(entity)) {
			AddEntity(entity);
		}
	}
}
