using Godot;
using System;

public partial class vela : Node3D
{
	// Called when the node enters the scene tree for the first time.
	public bool isEntered = false;
	private Guerreiro personagem = null;
	private Node3D velaAcesa;
	private Label texto;
	private bool isSelected = false;
	public override void _Ready()
	{
		velaAcesa = GetNode<Node3D>("vela_acesa");
		texto = GetNode<Label>("texto");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(isEntered)
		{
			texto.Visible = true;
			if (Input.IsActionJustPressed("salvar"))
			{
				select();
            }
			
		}
		if (personagem != null)
		{
			if (personagem.posicaoinicial != this.Position && isSelected)
			{
				deselect();
			}
		}
	}

	private void select()
	{
        personagem.posicaoinicial = this.Position;
        velaAcesa.Visible = true;
        GD.Print("selecionado");
		isSelected = true;
    }

	private void deselect()
	{
		GD.Print("Deselecionado");
		velaAcesa.Visible = false;
		personagem = null;
		isSelected = false;
	}

	public void _on_area_3d_body_entered(Node3D body)
	{
		if(body is Guerreiro)
		{
			personagem = (Guerreiro) body;
			isEntered = true;
		}
	}

	public void _on_area_3d_body_exited(Node3D body)
	{
        if (body is Guerreiro)
        {
            isEntered = false;
            texto.Visible = false;
			if (!isSelected)
				personagem = null;
        }
    }
}
