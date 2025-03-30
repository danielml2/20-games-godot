using Godot;
using System;
using System.Diagnostics;

public partial class Player : RigidBody2D
{
	[Export]
	public int forwardSpeed = 300;
	[Export]
	public int upSpeed = 300;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		

	}

    public override void _PhysicsProcess(double delta)
    {
		if(Input.IsActionPressed("Up")) {
			Debug.WriteLine("Presssed");
			ApplyForce(Vector2.Up * upSpeed);
		}
    }


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}
