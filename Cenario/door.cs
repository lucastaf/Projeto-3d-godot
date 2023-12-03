using Godot;
using System;

public partial class door : Node3D
{
	[Export] public alavanca alavanca = null;
	private Node3D doorObject;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("pai");
		alavanca.active += active => _on_lever_interactable_active(active);
		doorObject = GetNode<Node3D>("wall_doorway/Parede/wall_doorway2/wall_doorway_door");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_lever_interactable_active(bool active)
	{
		if (active)
		{
			doorObject.RotateObjectLocal(new Vector3(0, 1, 0),Mathf.DegToRad(90));
		}
		else
		{
            doorObject.RotateObjectLocal(new Vector3(0, 1, 0), Mathf.DegToRad(-90));
        }
	}
}
