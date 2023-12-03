using Godot;
using System;

public partial class hitBox_component : Node3D
{
    [Export] public health_component health = null;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public void _on_area_entered(Area3D body)
    {
        GD.Print("body entered" + body.GetType());
        if (body is Damage_Component)
        {
            int dano = ((Damage_Component)body).damage;
            if (health != null)
                health.takeDamage(dano);
        }
    }
}
