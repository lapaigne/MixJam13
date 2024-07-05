using Godot;
using System;

public partial class Projectile : CharacterBody2D
{
	public const float Speed = 100.0f;
    [Export]
    public new Vector2 Velocity = Vector2.Up * Speed;

	public override void _PhysicsProcess(double delta)
	{
        if (MoveAndCollide(Velocity * (float)delta) != null)
        {
            GD.Print("Hit");
            QueueFree();
        }
	}
}
