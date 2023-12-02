using Godot;
using System;

public partial class health_component : Node3D
{

	[Signal] public delegate void emptyEventHandler();
	[Signal] public delegate void fullEventHandler();
	[Export] private int vida = 10;
	[Export] private int vidaMaxima = 10;
	[Export] public ProgressBar lifeBar = null;
	// Called when the node enters the scene tree for the first time.
	public int Health
	{
		get { return vida; }
		set { vida = value; }
	}

	public int MaxiumHealth
	{
		get { return vidaMaxima; }
		set { setMaxiumHealth(value);}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(lifeBar != null)
		{
			lifeBar.MaxValue = vidaMaxima;
			lifeBar.Value = vida;
		}
	}

	private void setHealth(int value)
	{
		vida = value;
		if (value > vidaMaxima)
		{
			vida = vidaMaxima;
			EmitSignal(SignalName.full);
		}
		if(value <= 0)
		{
			vida = 0;
			EmitSignal(SignalName.empty);
		}
		

		if(lifeBar != null)
		{
			lifeBar.Value = vida;
		}
	}

	private void setMaxiumHealth(int value)
	{
		if(value < 0)
		{
			value = 0;
		}
		vidaMaxima = value;
		if(lifeBar != null)
		lifeBar.MaxValue = vidaMaxima;
		if (vida > value)
		{
			setHealth(value);
		}
	}



}
