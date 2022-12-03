using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
	private Direction _direction;

	private Direction _nextDirection;

	private float _speed;


	private bool isMoving = false;

	public Direction direction => _direction;

	private void Start()
	{
		_direction = Direction.North;
		_nextDirection = null;
	}

	private void Update()
	{
		if (isMoving)
		{
			Vector3 vector = _direction.ToVector3() * (_speed);
			base.transform.position += vector * Time.deltaTime;
		}
		if (_nextDirection != null)
		{
			if (_direction.orientation != _nextDirection.orientation)
			{
				
				_direction = _nextDirection;
				_nextDirection = null;
				base.transform.position = Grid.main.FixToSubGrid(base.transform.position, 2, _direction.orientation);
				
			}
			else
			{
				_direction = _nextDirection;
				_nextDirection = null;
				base.transform.position = Grid.main.FixToSubGrid(base.transform.position, 2, _direction.orientation);
			}
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


	public void Continue()
	{
		isMoving = true;
	}


	public void TurnTo(Direction direction)
	{
		_nextDirection = direction;
	}

}
