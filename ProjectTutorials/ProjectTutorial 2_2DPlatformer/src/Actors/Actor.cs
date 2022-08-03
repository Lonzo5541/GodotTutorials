using Godot;
using System;

public class Actor : KinematicBody2D
{

	//actor movement vector
	public Vector2 velocity = Vector2.Zero; 

	//gravity strength
	public float gravity = 500; 

	//actor movement speed
	public Vector2 speed = new Vector2(300, 1000); 

	public override void _Ready(){
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	//Physics process @param float delta
	public void _physics_process(float delta){

		//applied gravity on actor
		velocity.y += gravity * delta; 

		velocity = MoveAndSlide(velocity); //actor moves and slides in a given direction
	}

}
