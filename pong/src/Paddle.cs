using Godot;
using System;
using System.Diagnostics;

public partial class Paddle : Node2D
{
	[Export]
	public int speed { get; set; } = 500;
	[Export]
	public string up_keybind { get; set; } = "left_up";
	[Export]
	public string down_keybind { get; set; } = "left_down";


	private Vector2 ScreenSize;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		Console.WriteLine(ScreenSize);
		Debug.WriteLine("Hello " + ScreenSize);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		var direction = Input.GetVector("ignore","ignore",up_keybind,down_keybind);
		Position += direction.Normalized() * speed * (float)delta;
		
		Position = new Vector2(
			x: Position.X,
			y: Mathf.Clamp(Position.Y, 40, ScreenSize.Y - 40)
		);

	}
}
