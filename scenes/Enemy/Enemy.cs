using System;
using Godot;

public partial class Enemy : RigidBody2D
{
    [Export]
    public float Magnitude = 100f;
    public Vector2 Force;

    public override void _Ready()
    {
        Mass = 10;
        Force = new Vector2((GD.Randf() - 0.5f) * 0.5f, 1).Normalized() * Magnitude;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (LinearVelocity.Length() < 30)
        {
            ApplyCentralForce(Force);
        }
    }

    public void OnEnemyBodyEntered(Node node)
    {
        GD.Print(node.Name);
        //
    }
}
