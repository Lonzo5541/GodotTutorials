using Godot;
using System;

public class HUD : CanvasLayer
{
	[Signal]
	public delegate void StartGame();
	
	public void ShowMessage(string text)
	{
		var message = GetNode<Label>("Message");
		message.Text = text;
		message.Show();

		GetNode<Timer>("MessageTimer").Start();
	}
	
	async public void ShowGameOver()
	{
		ShowMessage("Game Over");

		var messageTimer = GetNode<Timer>("MessageTimer");
		await ToSignal(messageTimer, "timeout");

		var message = GetNode<Label>("Message");
		message.Text = "Dodge the\nCreeps!";
		message.Show();

		GetNode<Button>("StartButton").Show();
	}
	
	public void UpdateScore(int score)
	{
		GetNode<Label>("ScoreLabel").Text = score.ToString();
	}
	
	public void _on_MessageTimer_timeout()
	{
		GetNode<Label>("Message").Hide();
	}

	public void _on_StartButton_pressed()
	{
			GetNode<Button>("StartButton").Hide();
			EmitSignal(nameof(StartGame));
	}
}
