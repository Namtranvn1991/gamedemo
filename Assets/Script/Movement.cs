using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	private Vector3 _velocity;

	private bool _lockedRotation = false;

	private Direction _direction = Direction.North;

	private bool isMoving = false;

	private float _speed;


	public int movementGridSize = 2;


	protected float stop_time = -1f;

    public bool lockedRotation
	{
		get
		{
			return _lockedRotation;
		}
		set
		{
			_lockedRotation = value;
		}
	}


    public Vector3 velocity
    {
		get
		{
			return _velocity;
		}
	}

	public Direction direction => _direction;

	public float speed => _speed;


	private void Update()
	{
		if (isMoving)
		{
			_velocity = _direction.ToVector3();
			base.transform.position += _velocity * Time.deltaTime;
		}
		base.transform.rotation = _direction.ToEuler();
	}

	public void Move(float speed)
	{
		isMoving = true;
		_speed = speed;
	}

	public void Stop()
	{
		isMoving = false;
		_speed = 0f;
	}


	public void TurnTo(Direction direction)
	{
		if (!_lockedRotation)
		{
			if (_direction.value != direction.value)
			{
				_direction = direction;
			}
			base.transform.position = Grid.main.FixToSubGrid(base.transform.position, movementGridSize, _direction.orientation);
		}
	}
}
