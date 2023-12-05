    using Godot;
using System;

public partial class Guerreiro : CharacterBody3D
{
    AnimationTree animacoes;
    AnimationNodeStateMachinePlayback stateAnimacoes;
    Label UiMoedas;
    health_component vida;
    public int totalMoedas = 0;
    public const float Speed = 5.0f;
    public const float JumpVelocity = 5.0f;
    private bool onGround = true;
    private int numPulos;
    public Vector3 posicaoinicial;
    private CollisionShape3D atackColission;

    // Get the gravity from the project settings to be synced with RigidBody nodes.
    public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

    public override void _Ready()
    {
        vida = GetNode<health_component>("HealthComponent");
        posicaoinicial = this.Position;
        UiMoedas = GetNode<Label>("Moedas");
        animacoes = GetNode<AnimationTree>("AnimationState");
        stateAnimacoes = (AnimationNodeStateMachinePlayback)animacoes.Get("parameters/playback");
        atackColission = GetNode<CollisionShape3D>("Damage_Component/HitBox Colision");
    }

    public override void _PhysicsProcess(double delta)
    {

        if (Input.IsActionJustPressed("Restart"))
        {
            GetTree().ReloadCurrentScene();
        }

        if (this.GlobalPosition.Y < -10)
        {
            dead();
        }

        Vector3 velocity = Velocity;

        // Add the gravity.
        if (!IsOnFloor())
        {
            if (onGround)
                animacoes.Set("parameters/conditions/onAir", true);
            velocity.Y -= gravity * (float)delta;

            animacoes.Set("parameters/conditions/onGround", false);

            onGround = false;
        }
        else
        {
            animacoes.Set("parameters/conditions/onAir", false);
            animacoes.Set("parameters/conditions/onGround", true);
            onGround = true;
            numPulos = 2;
        }

        // Handle Jump.

        if (Input.IsActionJustPressed("pulo") && numPulos > 0)
        {
            velocity.Y = JumpVelocity;
            numPulos--;
        }
        if (Input.IsActionJustPressed("ataque"))
        {
            stateAnimacoes.Travel("Atacando");
            atackColission.Disabled = false;
        }




        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actions with custom gameplay actions.
        Vector2 inputDir = Input.GetVector("esquerda", "direita", "frente", "tras");
        Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
        if (direction != Vector3.Zero)
        {
            velocity.X = direction.X * Speed;
            velocity.Z = direction.Z * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
        }

        animacoes.Set("parameters/IWR/blend_position", inputDir);
        Velocity = velocity;
        MoveAndSlide();
    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsMouseButtonPressed(MouseButton.Right)) Input.MouseMode = Input.MouseModeEnum.Captured;
        if (Input.IsKeyPressed(Key.Escape)) Input.MouseMode = Input.MouseModeEnum.Visible;

        if(@event is InputEventMouseMotion eventMouseMotion && Input.MouseMode == Input.MouseModeEnum.Captured)
        {
            float posicaoX = eventMouseMotion.Relative.X * -1;
            this.RotateY(posicaoX/500);
        }

        
    }

    public void moedaColetada()
    {
        totalMoedas++;
        UiMoedas.Text = totalMoedas.ToString();
    }

    public void dead()
    {
        vida.Health = vida.MaxiumHealth;
        this.Position = posicaoinicial;
    }

    public void _on_animation_state_animation_finished(string animationName)
    {
        if (animationName == "1H_Melee_Attack_Slice_Diagonal")
        {
            atackColission.Disabled = true;
        }
    }
}
