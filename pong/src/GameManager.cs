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

		if(leftScore == 5 || rightScore == 5) {
			GameOver();
		} else {
			leftLabel.Text = leftScore + "";	   				
			rightLabel.Text = rightScore + "";	 
		}  				
	}


	public async void GameOver() {
		leftLabel.Text = leftScore == 5 ? "5 Left wins!" : leftScore + "";
		rightLabel.Text = rightScore == 5 ? "5 Right wins!" : rightScore + "";

		ballReference.setFreeze(true);
		await System.Threading.Tasks.Task.Delay(TimeSpan.FromMilliseconds(3000));
		leftScore = 0;
		rightScore = 0;
		leftLabel.Text = leftScore + "";	   				
		rightLabel.Text = rightScore + "";
		ballReference.setFreeze(false);

	}




}
