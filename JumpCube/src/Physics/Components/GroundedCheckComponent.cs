using Godot;
using System;

public partial class GroundedCheckComponent : Node
{
	public bool PreviousFrameWasOverlapping { get; set; } = false;
}
