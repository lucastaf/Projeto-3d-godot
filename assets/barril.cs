using Godot;
using System;

public partial class barril : Node3D
{
	// Called when the node enters the scene tree for the first time.

	[Export] public PackedScene cenaMoeda = null;
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_health_component_empty()
	{
		Node3D NodeMoeda = (Node3D)cenaMoeda.Instantiate();
		NodeMoeda.Transform = this.Transform;
        this.GetParent().AddChild(NodeMoeda);
		this.QueueFree();
	}
}
