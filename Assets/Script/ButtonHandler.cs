using System.Collections.Generic;
using UnityEngine;

public enum Key
{
    None,
    Up,
    Down,
    Left,
    Right,
    Action1,
    Action2,
    Action3
}

public class ButtonHandler : MonoBehaviour
{
	private string keyUp;

	private string keyDown;

	private string keyLeft;

	private string keyRight;

	public int player;

	private List<Key> movement_queue = new List<Key>();

	public KeyCode keyAction1 => (player != 1) ? KeyCode.JoystickButton0 : KeyCode.J;

	public KeyCode keyAction2 => (player != 1) ? KeyCode.JoystickButton1 : KeyCode.K;

	public KeyCode keyAction3 => (player != 1) ? KeyCode.JoystickButton2 : KeyCode.L;

	public Key GetLastKey()
	{
		if (movement_queue.Count == 0)
		{
			return Key.None;
		}
		return movement_queue[movement_queue.Count - 1];
	}

	public void Refresh()
	{
		movement_queue.Clear();
	}

	private void Start()
	{
		movement_queue.Clear();
	}

	private void Update()
	{
		if (player == 1)
		{
			PushKeyToQueue();
			RemoveKeyFromQueue();
		}
		else if (player == 2)
		{
			PushControllerAxisToQueue();
			RemoveControllerAxisFromQueue();
		}
	}

	private void PushKeyToQueue()
	{
		if (Input.GetKeyDown(KeyCode.W))
		{
			movement_queue.Add(Key.Up);
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			movement_queue.Add(Key.Down);
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			movement_queue.Add(Key.Left);
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			movement_queue.Add(Key.Right);
		}
	}

	private void PushControllerAxisToQueue()
	{
		if (Input.GetAxis("ps4_horizontal") == 1f)
		{
			if (!movement_queue.Contains(Key.Right))
			{
				movement_queue.Add(Key.Right);
			}
		}
		else if (Input.GetAxis("ps4_horizontal") == -1f && !movement_queue.Contains(Key.Left))
		{
			movement_queue.Add(Key.Left);
		}
		if (Input.GetAxis("ps4_vertical") == 1f)
		{
			if (!movement_queue.Contains(Key.Up))
			{
				movement_queue.Add(Key.Up);
			}
		}
		else if (Input.GetAxis("ps4_vertical") == -1f && !movement_queue.Contains(Key.Down))
		{
			movement_queue.Add(Key.Down);
		}
	}

	private void RemoveKeyFromQueue()
	{
		if (Input.GetKeyUp(KeyCode.W))
		{
			movement_queue.Remove(Key.Up);
		}
		if (Input.GetKeyUp(KeyCode.S))
		{
			movement_queue.Remove(Key.Down);
		}
		if (Input.GetKeyUp(KeyCode.A))
		{
			movement_queue.Remove(Key.Left);
		}
		if (Input.GetKeyUp(KeyCode.D))
		{
			movement_queue.Remove(Key.Right);
		}
	}

	private void RemoveControllerAxisFromQueue()
	{
		if (Input.GetAxis("ps4_horizontal") < 1f)
		{
			movement_queue.Remove(Key.Right);
		}
		if (Input.GetAxis("ps4_horizontal") > -1f)
		{
			movement_queue.Remove(Key.Left);
		}
		if (Input.GetAxis("ps4_vertical") < 1f)
		{
			movement_queue.Remove(Key.Up);
		}
		if (Input.GetAxis("ps4_vertical") > -1f)
		{
			movement_queue.Remove(Key.Down);
		}
	}
}
