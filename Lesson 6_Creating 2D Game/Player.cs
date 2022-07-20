using Godot;
using System;

public class Player : Area2D
{
    // Declare member variables here

    public int Speed = 400; // movement speed of player
    public Vector2 ScreenSize; //game window size

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        ScreenSize = GetViewportReact().Size();

    }

    public override void _Process(float delta){

        var velocity = Vector2.Zero; // player movement vector
        var animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite";)

        //conditions of player inputs
        if (Input.IsActionPressed("move_right"))
        {
            velocity.x += 1;
        } else if (Input.IsActionPressed("move_left"))
        {
            velocity.x += -1;
        } else if (Input.IsActionPressed("move_down"))
        {
            velocity.y += 1;
        } else if (Input.IsActionPressed("move_up"))
        {
            velocity.y += -1;
        }

        if (velocity.Length() > 0){

            veolcity = velocity.Normalized() * speed;
            animatedSprite.Play();
        } else
        {
            animatedSprite.Stop();
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
