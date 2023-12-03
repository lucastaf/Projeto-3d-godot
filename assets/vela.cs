using Godot;
using System;

public partial class vela : Node3D
{
	// Called when the node enters the scene tree for the first time.
	private Guerreiro personagem = null;
	private Node3D velaAcesa;
	private bool isSelected = false;
	public override void _Ready()
	{
		velaAcesa = GetNode<Node3D>("vela_acesa");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (isSelected)
		{
			if (personagem.posicaoinicial != this.Position)
			{
				isSelected = false;
				velaAcesa.Visible = false;
			}
		}

	}

	public void _on_interactable_component_interacted(Node3D body)
	{
		this.isSelected = true;
		this.personagem = (Guerreiro)body;
		personagem.posicaoinicial = this.Position;
		this.velaAcesa.Visible = true;
	}
}