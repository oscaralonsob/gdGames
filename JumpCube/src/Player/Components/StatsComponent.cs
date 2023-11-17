using Godot;
using System;

public partial class StatsComponent : Node
{
	[Export]
	public int Speed { private set; get; }
	[Export]
	public int JumpForce { private set; get; }
}


/*
 * TODO:
 *  Hacer un velocity component donde se pone la velocidad, ya sea lateral o no 
 *	Cambiar el movement system por 2 distintos, 
 *		- uno es el que lee los inputs y pone la velocidad en este component
 *		- El que pilla eso y lo muevo
 *	El jump system no mueve, solo tiene pilla el imput del salto o no y si choca con el suelo para actualizar la velocidad
 *
*/