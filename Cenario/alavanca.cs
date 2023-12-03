using Godot;
using System;

public partial class alavanca : Node3D
{
	// Called when the node enters the scene tree for the first time.
	[Export] private bool LeverActive = false;
	[Signal] public delegate void activeEventHandler(bool active);
	private Node3D wand;
	private Node3D RedSphere;
	private Node3D GreenSphere;
	public override void _Ready()
	{
		wand = GetNode<Node3D>("wand");
		RedSphere = GetNode<Node3D>("RedSphere");
		GreenSphere = GetNode<Node3D>("GreenSphere");
	}

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}

	public void _on_interactable_component_interacted(Node3D body)
	{
		if (LeverActive)
		{
			LeverActive = false;
			wand.RotateObjectLocal(new Vector3(0, 0, 1), Mathf.DegToRad(-90));
			RedSphere.Visible = true;
			GreenSphere.Visible = false;
		}
		else
		{
			LeverActive = true;
            wand.RotateObjectLocal(new Vector3(0, 0, 1), Mathf.DegToRad(90));
            RedSphere.Visible = false;
            GreenSphere.Visible = true;    
        }
        EmitSignal(SignalName.active, LeverActive);
    }
}
