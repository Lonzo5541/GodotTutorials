using Godot;
using System;

public class Actor : KinematicBody2D
{
	decimal gravity = 3000.0;

	public override void _Ready(){
		
	}
	
	public void _PhysicsProcess(float delta){
		
		Vector2 velocity = new Vector2.Zero;

		velocity.y += gravity * delta;

		MoveAndSlide(velocity);
	}

}
