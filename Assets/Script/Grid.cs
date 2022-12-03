using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
	[SerializeField]
	private Vector2Int _size;

	[SerializeField]
	private float _tileSize = 1f;

	[SerializeField]
	private int _subGridSize = 2;

	private static Grid _main = null;

	public Vector2Int size => _size;

	public float tileSize => _tileSize;

	private float subTileSize => _tileSize / (float)_subGridSize;

	public static Grid main => _main;

	public Vector3 minPos => Vector3.zero - new Vector3(_size.x, 0f, _size.y) * _tileSize / 2f;

	private void Awake()
	{
		if (_main == null)
		{
			_main = this;
		}
		else
		{
			Object.DestroyImmediate(base.gameObject);
		}
	}

	public Vector2Int GetGridPosition(Vector3 worldPoint)
	{
		Vector2Int zero = Vector2Int.zero;
		zero.x = (int)((worldPoint.x - minPos.x) / _tileSize);
		zero.y = (int)((worldPoint.z - minPos.z) / _tileSize);
		if (zero.x < 0 || zero.x >= _size.x)
		{
			Debug.LogWarning("world point is out bounds");
			zero.x = 0;
		}
		if (zero.y < 0 || zero.y >= _size.y)
		{
			Debug.LogWarning("world point is out bounds");
			zero.y = 0;
		}
		return zero;
	}

	public Vector3 FixToMovementGrid(Vector3 worldPoint, Orientation orient)
	{
		Vector3 vector = worldPoint - minPos;
		if (orient == Orientation.Vertical)
		{
			int num = Mathf.RoundToInt(vector.x / subTileSize);
			vector.x = (float)num * subTileSize;
		}
		else
		{
			int num2 = Mathf.RoundToInt(vector.z / subTileSize);
			vector.z = (float)num2 * subTileSize;
		}
		return minPos + vector;
	}

	public Vector3 FixToMovementGrid(Vector3 worldPoint)
	{
		Vector3 vector = worldPoint - minPos;
		int num = Mathf.RoundToInt(vector.x / subTileSize);
		int num2 = Mathf.RoundToInt(vector.z / subTileSize);
		vector.x = (float)num * subTileSize;
		vector.z = (float)num2 * subTileSize;
		return minPos + vector;
	}

	public Vector3 FixToSubGrid(Vector3 worldPoint, int subGridValue, Orientation orientation)
	{
		Vector3 vector = worldPoint - minPos;
		float num = 1f / (float)subGridValue;
		if (orientation == Orientation.Vertical)
		{
			int num2 = Mathf.RoundToInt(vector.x / num);
			if (subGridValue % 2 == 0)
			{
				vector.x = (float)num2 * num;
			}
			else
			{
				vector.x = ((float)num2 + 0.5f) * num;
			}
		}
		else
		{
			int num3 = Mathf.RoundToInt(vector.z / num);
			if (subGridValue % 2 == 0)
			{
				vector.z = (float)num3 * num;
			}
			else
			{
				vector.z = ((float)num3 + 0.5f) * num;
			}
		}
		return minPos + vector;
	}

	public Vector3 FindNearestFixedPoint(Vector3 worldPoint)
	{
		Vector2Int gridPosition = GetGridPosition(worldPoint);
		return GetWorldPoint(gridPosition);
	}

	public Vector3 FixToBaseGrid(Vector3 worldPoint)
	{
		Vector3 vector = worldPoint - minPos;
		int num = (int)(vector.x / _tileSize);
		int num2 = (int)(vector.z / _tileSize);
		vector.x = ((float)num + 0.5f) * _tileSize;
		vector.z = ((float)num2 + 0.5f) * _tileSize;
		return minPos + vector;
	}

	public Vector3 GetWorldPoint(Vector2Int gridPos)
	{
		return minPos + new Vector3((float)gridPos.x + 0.5f, 0f, (float)gridPos.y + 0.5f) * _tileSize;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.black;
		for (int i = 0; i <= _size.x; i++)
		{
			Vector3 vector = minPos + Vector3.right * _tileSize * i;
			Vector3 to = vector + Vector3.forward * _size.y * _tileSize;
			Gizmos.DrawLine(vector, to);
		}
		for (int j = 0; j <= _size.y; j++)
		{
			Vector3 vector2 = minPos + Vector3.forward * _tileSize * j;
			Vector3 to2 = vector2 + Vector3.right * _size.x * _tileSize;
			Gizmos.DrawLine(vector2, to2);
		}
	}
}
