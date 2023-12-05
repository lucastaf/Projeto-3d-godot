using Godot;
using System;

public partial class Level1 : Node3D
{
	private Guerreiro player;
	private Label coinsLabel;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		coinsLabel = GetNode<Label>("ContadorMoedas");
		player = GetNode<Guerreiro>("Knight");

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		coinsLabel.Text = player.totalMoedas.ToString() + "/12";
		if(player.totalMoedas == 12)
		{
			GetTree().ChangeSceneToFile("res://Levels/Level2.tscn");
		}
	}
}
