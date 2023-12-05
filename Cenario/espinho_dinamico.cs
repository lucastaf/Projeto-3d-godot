using Godot;
using System;

public partial class espinho_dinamico : Node3D
{
	// Called when the node enters the scene tree for the first time.
	[Export] public bool active;
	[Export] public double timeOut = 3;
	private CollisionShape3D spikeColision;
	private Node3D spikeMesh;
	public override void _Ready()
	{
		spikeColision = GetNode<CollisionShape3D>("Espinho/spikes/Damage_Component/CollisionShape3D");
		spikeMesh = GetNode<Node3D>("Espinho/spikes");
		if (!active)
		{
			spikeColision.Disabled = true;
			spikeMesh.Visible = false;
		}
		Timer timer = GetNode<Timer>("Timer");
		timer.WaitTime = timeOut;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_timer_timeout()
	{
		if (active)
		{
			active = false;
			spikeColision.Disabled = true;
			spikeMesh.Visible = false;
		}
		else{
			active = true;
			spikeColision.Disabled = false;
			spikeMesh.Visible = true;
		}
	}
}
