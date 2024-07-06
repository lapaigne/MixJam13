using System;
using Godot;

public partial class Projectile : CharacterBody2D
{
    public const float Speed = 100.0f;

    [Export]
    public new Vector2 Velocity = Vector2.Up * Speed;
    [Export]
    public int Damage = 45;

    public override void _PhysicsProcess(double delta)
    {
        MoveAndCollide(Velocity * (float)delta);
    }
}
