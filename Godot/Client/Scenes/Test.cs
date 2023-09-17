using Godot;
using System;

public partial class Test : Node3D
{
	[Export]
	private Vector3 forward;
	[Export]
	private Vector3 up;
	[Export]
	private EulerOrder order;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var lookRotation = QuaternionHelper.LookRotation(this.forward,this.up);
		var result =lookRotation.GetEuler(order );
		GD.Print(new Vector3(Mathf.RadToDeg(result.X),Mathf.RadToDeg(result.Y),Mathf.RadToDeg(result.Z)));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
