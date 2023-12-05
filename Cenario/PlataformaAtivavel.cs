using Godot;
using System;

public partial class PlataformaAtivavel : Node3D
{

	[Export] public alavanca alavanca;
	private Node3D plataformMesh;
	private CollisionShape3D plataformColission;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        alavanca.active += active => _on_lever_interactable_active(active);
		plataformMesh = GetNode<Node3D>("floor_tile_small_gltf/floor_tile_small");
		plataformColission = GetNode<CollisionShape3D>("floor_tile_small_gltf/floor_tile_small/StaticBody3D/CollisionShape3D");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_lever_interactable_active(bool active)
	{
		if (active)
		{
			plataformMesh.Visible = true;
			plataformColission.Disabled = false;
		}
		else
		{
			plataformMesh.Visible = false;
			plataformColission.Disabled = true;
		}
	}
}
