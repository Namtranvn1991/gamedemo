using UnityEngine;

public enum DIRECTION
{
	N,
	E,
	S,
	W
}
public class Direction
{
	private DIRECTION _value = DIRECTION.N;

	public static Direction North = new Direction(DIRECTION.N);

	public static Direction East = new Direction(DIRECTION.E);

	public static Direction South = new Direction(DIRECTION.S);

	public static Direction West = new Direction(DIRECTION.W);

	public DIRECTION value => _value;

	public Orientation orientation => (_value != 0 && _value != DIRECTION.S) ? Orientation.Horizontal : Orientation.Vertical;

	private Direction(DIRECTION value)
	{
		_value = value;
	}

	public float ToAngle()
	{
		switch (_value)
		{
			case DIRECTION.N:
				return 0f;
			case DIRECTION.E:
				return 90f;
			case DIRECTION.S:
				return 180f;
			case DIRECTION.W:
				return 270f;
			default:
				Debug.LogError("direction is not right");
				return 0f;
		}
	}

	public Vector3 ToVector3()
	{
		switch (_value)
		{
			case DIRECTION.N:
				return Vector3.forward;
			case DIRECTION.E:
				return Vector3.right;
			case DIRECTION.S:
				return Vector3.back;
			case DIRECTION.W:
				return Vector3.left;
			default:
				Debug.LogError("direction is not right");
				return Vector3.zero;
		}
	}

	public Vector2Int ToVector2Int()
	{
		switch (_value)
		{
			case DIRECTION.N:
				return Vector2Int.up;
			case DIRECTION.E:
				return Vector2Int.right;
			case DIRECTION.S:
				return Vector2Int.down;
			case DIRECTION.W:
				return Vector2Int.left;
			default:
				Debug.LogError("direction is not right");
				return Vector2Int.zero;
		}
	}

	public Quaternion ToEuler()
	{
		switch (_value)
		{
			case DIRECTION.N:
				return Quaternion.Euler(0f, 0f, 0f);
			case DIRECTION.E:
				return Quaternion.Euler(0f, 90f, 0f);
			case DIRECTION.S:
				return Quaternion.Euler(0f, 180f, 0f);
			case DIRECTION.W:
				return Quaternion.Euler(0f, 270f, 0f);
			default:
				Debug.LogError("direction is not right");
				return Quaternion.identity;
		}
	}

	public Direction RotateLeft()
	{
		switch (_value)
		{
			case DIRECTION.N:
				return West;
			case DIRECTION.E:
				return North;
			case DIRECTION.S:
				return East;
			case DIRECTION.W:
				return South;
			default:
				Debug.LogError("direction is not right");
				return null;
		}
	}

	public Direction RotateRight()
	{
		switch (_value)
		{
			case DIRECTION.N:
				return East;
			case DIRECTION.E:
				return South;
			case DIRECTION.S:
				return West;
			case DIRECTION.W:
				return North;
			default:
				Debug.LogError("direction is not right");
				return null;
		}
	}

	public Direction Flip()
	{
		switch (_value)
		{
			case DIRECTION.N:
				return South;
			case DIRECTION.E:
				return West;
			case DIRECTION.S:
				return North;
			case DIRECTION.W:
				return East;
			default:
				Debug.LogError("direction is not right");
				return null;
		}
	}

	public override string ToString()
	{
		return _value switch
		{
			DIRECTION.N => "north",
			DIRECTION.E => "east",
			DIRECTION.S => "south",
			DIRECTION.W => "west",
			_ => "invalid",
		};
	}
}
