using Godot;
using System;

public partial class Level2 : Node3D
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_interactable_component_interacted(Node3D body)
	{
		GetTree().ChangeSceneToFile("res://Levels/game_over_screen.tscn");

    }
}
