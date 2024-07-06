using System;
using Godot;

public partial class Enemy : RigidBody2D
{
    [Export]
    public float Magnitude = 100f;
    public Vector2 Force;
    public float Torque = 2500f;
    public int Damage = 17;
    public int Health = 25;
    private bool IsMoving = true;

    public override void _Ready()
    {
        Force = new Vector2((GD.Randf() - 0.5f) * 0.5f, 1).Normalized() * Magnitude;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (LinearVelocity.Length() < 30 && IsMoving)
        {
            ApplyCentralForce(Force);
            ApplyTorque(Torque);
        }
    }

    public void OnEnemyBodyEntered(Node node)
    {
        switch (node)
        {
            case Player player:
                player.Health -= Damage;
                GD.Print(player.Health);
                QueueFree();
                break;

            case Projectile projectile:
                Health -= projectile.Damage;
                projectile.QueueFree();
                if (Health <= 0)
                {
                    QueueFree();
                }
                break;

            default:
                QueueFree();
                break;
        }
    }
}
