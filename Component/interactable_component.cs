using Godot;
using System;

public partial class interactable_component : Area3D
{

	[Signal] public delegate void interactedEventHandler(Node3D body);
	[Export] public string MessageText;
    private Node3D personagem;
    private bool isEntered = false;
    private Label mesageLabel;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		mesageLabel = GetNode<Label>("texto");
		mesageLabel.Text = MessageText;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        if (isEntered) {
            if (Input.IsActionJustPressed("interagir"))
            {
                EmitSignal(SignalName.interacted,personagem);
            }
        }
	}

	public void _on_body_entered(Node3D body)
	{
        if (body is Guerreiro)
        {
            personagem = (Guerreiro)body;
            isEntered = true;
            mesageLabel.Visible = true;
        }
    }

	public void _on_body_exited(Node3D body)
	{
        if (body is Guerreiro)
        {
            isEntered = false;
            mesageLabel.Visible = false;
        }
    }
}
