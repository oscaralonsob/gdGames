using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

public abstract partial class ECSSystemControl: Node
{
  protected List<EntityControl> Entities { get; private set; }
  protected List<Type> Components { get; private set; }

	public override abstract void _Ready();
	public abstract void execute(EntityControl entity, double delta);

	public override void _EnterTree()
	{
		EventBus.Instance.EntityControlCreated += entityCreated;
		EventBus.Instance.EntityControlDeleted += entityDeleted;
	}

	public override void _ExitTree()
	{
		EventBus.Instance.EntityControlCreated -= entityCreated;
		EventBus.Instance.EntityControlDeleted -= entityDeleted;
	}

	protected void Init(List<Type> components)
	{
		Entities = new List<EntityControl>();
		Components = components;
	}

	public override void _PhysicsProcess(double delta)
	{
		foreach (EntityControl entity in Entities.ToList()) {
			if (IsInstanceValid(entity)) { //In case this is called while the node is being removed
				execute(entity, delta);
			}
		}
	}

	private void AddEntity(EntityControl entity) 
	{
		Entities.Add(entity);
	}

	private void RemoveEntity(EntityControl entity) 
	{
		Entities.Remove(entity);
	}

	private bool IsInterestedEntity(EntityControl entity)
	{
		foreach (Type component in Components) {
			if (!entity.HasNode(component.Name)) {
				return false;
			}
		}
		return true;
	}

	private void entityCreated(EntityControl entity) 
	{
		if (IsInterestedEntity(entity)) {
			AddEntity(entity);
		}
	}

	private void entityDeleted(EntityControl entity) 
	{
		if (IsInterestedEntity(entity)) {
			RemoveEntity(entity);
		}
	}
}
