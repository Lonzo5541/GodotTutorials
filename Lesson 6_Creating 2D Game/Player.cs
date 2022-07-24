using Godot;
using System;


public class Player : Area2D
{
	// Declare member variables here
	[Signal]
	public delegate void Hit();

	public int Speed = 400; // movement speed of player
	public Vector2 ScreenSize; //game window size

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;

		Hide();

	}

	public override void _Process(float delta){

		//player input events
		var velocity = Vector2.Zero; // The player's movement vector.

		if (Input.IsActionPressed("move_right"))
		{
			velocity.x += 1;
		} 
		if (Input.IsActionPressed("move_left"))
		{
			velocity.x -= 1;
		} 
		if (Input.IsActionPressed("move_down"))
		{
			velocity.y += 1;
		} 
		if (Input.IsActionPressed("move_up"))
		{
			velocity.y -= 1;
		}

		var animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");

		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
			animatedSprite.Play();
		} else{
			animatedSprite.Stop();
		}

		//update player position
		Position += velocity * delta;
		Position = new Vector2(
			x: Mathf.Clamp(Position.x, 0, ScreenSize.x),
			y: Mathf.Clamp(Position.y, 0, ScreenSize.y)
		);

		//animate player when moving
		if (velocity.x != 0)
		{
			animatedSprite.Animation = "walk";
			animatedSprite.FlipV = false;
			// See the note below about boolean assignment.
			animatedSprite.FlipH = velocity.x < 0;
		}
		else if (velocity.y != 0)
		{
			animatedSprite.Animation = "up";
			animatedSprite.FlipV = velocity.y > 0;
		}       

	}
	
	public void Start(Vector2 pos){

	Position = pos;
	Show();
	GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
	}

	public void _on_Player_body_entered(object body)
	{
		Hide(); // Player disappears after being hit.
		EmitSignal(nameof(Hit));

		// Must be deferred as we can't change physics properties on a physics callback.
		GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred("disabled", true);
	}
	
	public void resetSprite(){
		
		var velocity = Vector2.Zero;
		var animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
		
		animatedSprite.Animation = "Idle";
		animatedSprite.FlipV = velocity.y > 0;
	}

}
