using Godot;
using System;

public class Player : Actor
{
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	//Physics @param float delta
	public void _process(float delta){
		
		//var for jump input
		int jump;

		//speed of the player
		speed = new Vector2(800, 1000);

		//checks to
		if (Input.IsActionPressed("jump")) {
			
			jump = -1;

		} else {

			jump = 1;
		}
		
		// The player's movement vector
		// returns -1 if moving left, 1 if moving right, 0 if not moving or both keys are pressed
		Vector2 direction = new Vector2(Input.GetActionStrength("move_right") - Input.GetActionRawStrength("move_left"), jump);

		velocity = speed * direction;

	}

}
