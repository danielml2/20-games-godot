using Godot;
using System;
using System.Diagnostics;

public partial class GameManager : Node2D
{
	[Export]
	private Ball ballReference;

	[Export]
	private Label rightLabel;
	[Export]
	private Label leftLabel;

	private int rightScore = 0;
	private int leftScore = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ballReference.Score += onScore;
	}


	public void onScore(string side) {
		Debug.WriteLine("Scored" + side);
		if(side == "Left")
			rightScore++;
		else 
			leftScore++;	

		leftLabel.Text = leftScore + "";	   				
		rightLabel.Text = rightScore + "";	   				
	}




}
