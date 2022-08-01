using Godot;
using System;

public class Actor : KinematicBody2D
{
	Vector2 velocity = Vector2.Zero; //actor movement vector
	float gravity = 500; //gravity strength
	Vector2 speed = new Vector2(300, 1000); //actor movement speed

	public override void _Ready(){
		
	}
	
	public void _physics_process(float delta){

		velocity.y += gravity * delta; //applied gravity on actor

		velocity = MoveAndSlide(velocity); //actor moves and slides in a given direction
	}

}
