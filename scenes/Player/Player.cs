using System;
using Godot;

public partial class Player : CharacterBody2D
{
    [Export]
    public float Speed = 300.0f;

    [Export]
    public PackedScene ProjectileScene;
    private int count = 1;

    public override void _Ready()
    {
        ProjectileScene = GD.Load<PackedScene>("res://scenes/Projectile/Projectile.tscn");
    }

    public override void _PhysicsProcess(double delta)
    {
        if (Input.IsActionPressed("shoot") && count > 0)
        {
            count--;
            Projectile projectile = ProjectileScene.Instantiate<Projectile>();
            projectile.GlobalPosition = GlobalPosition + Vector2.Up * 40;
            GetParent().AddChild(projectile);
        }

        Vector2 velocity = Input.GetVector("moveLeft", "moveRight", "moveUp", "moveDown") * Speed;
        Velocity = velocity;
        MoveAndSlide();
    }
}
