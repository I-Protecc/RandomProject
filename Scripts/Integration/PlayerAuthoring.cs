using Godot;

namespace RpgProject.Scripts.Integration;

public partial class PlayerAuthoring : CharacterBody2D
{
	[Export]
	public float Speed { get; set; } = 1;


	private CharacterBody2D _characterBody2D;
	private Node2D _playerNode2D;
	private NavigationAgent2D _navigationAgent2D;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_playerNode2D = GetParent<Node2D>();
		_characterBody2D = GetNode<CharacterBody2D>(".") as CharacterBody2D; 
		_navigationAgent2D = GetNode<NavigationAgent2D>("NavigationAgent2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public void _physics_process(double delta)
	{
		Movement();
	}


	
	
	private void Movement()
	{
		Vector2 currentPosition = new Vector2(_playerNode2D.GlobalPosition.X, _playerNode2D.GlobalPosition.Y);
		Vector2 targetPosition = new Vector2(_playerNode2D.GlobalPosition.X, _playerNode2D.GlobalPosition.Y);
		
		if(Input.IsActionJustReleased("left"))
		{
			targetPosition.X -= 1;
			GD.Print("Left");
		}
		else if (Input.IsActionJustReleased("right"))
		{
			targetPosition.X += 1;
			GD.Print("Right");
		}
		else if (Input.IsActionJustReleased("up"))
		{
			targetPosition.Y -= 1;
			GD.Print("Up");
		}
		else if (Input.IsActionJustReleased("down"))
		{
			targetPosition.Y += 1;
			GD.Print("Down");
		}

		if (targetPosition != currentPosition)
		{
			Vector2 direction = currentPosition.DirectionTo(targetPosition);

			Velocity = direction * Speed; 
			
			MoveAndSlide();
		}
		
	}
}