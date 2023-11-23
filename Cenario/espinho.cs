using Godot;
using System;

public partial class espinho : Node3D
{

    private void _on_area_3d_body_entered(Node3D body)
    {
        if(body is Guerreiro)
        {
            ((Guerreiro)body).dead();
        }
    }
}
