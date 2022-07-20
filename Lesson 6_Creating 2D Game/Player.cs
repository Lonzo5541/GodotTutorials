using Godot;
using System;

[Signal]
public delegate void Hit();

public class Player : Area2D
{
    // Declare member variables here

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
    
}
