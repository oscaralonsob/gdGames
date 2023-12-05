using Godot;
using System;

public partial class QuitButton : Button
{
	public void _OnPressed()
	{
		GetTree().Quit();
	}
}
