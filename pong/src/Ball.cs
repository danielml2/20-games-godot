using Godot;
using System;
using System.Diagnostics;

public partial class Ball : Area2D
{
	[Export]
	public int speed = 400;

	private Random random = new Random();
	public Vector2 direction = Vector2.Right;

	private Vector2 ScreenSize;
	private Vector2 CENTER = new Vector2(576,324);
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ResetPosition();
		ScreenSize = GetViewportRect().Size;
		Console.WriteLine(ScreenSize);
	}
    public override void _PhysicsProcess(double delta)
    {
        Position += direction * (float)delta * speed;
		Position = new Vector2(
			x: Mathf.Clamp(Position.X, -20, ScreenSize.X + 20),
			y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
		);
    }

    private void OnBodyEntered(Node2D body)
	{
		var reflect_y = body.HasMeta("reflect_y") && body.GetMeta("reflect_y").AsBool();
		Debug.WriteLine("COLLISION!!!");
		if (reflect_y)
		{
			var angle = (float)random.NextDouble() * 45;
			Debug.WriteLine($"collision angle: {angle}");
			direction = new Vector2(direction.X, -direction.Y);
		}

		var reflect_x = body.HasMeta("reflect_x") && body.GetMeta("reflect_x").AsBool();

		if (reflect_x)
		{
			direction = new Vector2(-direction.X, (float)random.NextDouble() * 2 - 1);
			direction = direction.Normalized();
		}

		var isGoal = body.HasMeta("goal_side") ? body.GetMeta("goal_side").AsString() : "";
		if(isGoal != "") {
			EmitSignal(SignalName.Score, body.GetMeta("goal_side"));
			ResetPosition();
		}

	}

	public void ResetPosition() {
			Position = CENTER;
			direction = new Vector2((float)random.NextDouble() > 0.5 ? -1 : 1, (float)random.NextDouble() * 2 - 1);
			direction = direction.Normalized();
	}


    [Signal]
	public delegate void ScoreEventHandler(String side);



}
