using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IDamageable
{
	[SerializeField]
	private int initHP;

	private int _HP;

	public void ReceiveDamage(int damage)
	{
		if (_HP > damage)
		{
			_HP -= damage;
			return;
		}
		_HP = 0;
		Killed();
	}

	public void Killed()
	{
		base.gameObject.SetActive(value: false);
	}

	public void RestoreHP()
	{
		_HP = initHP;
	}

	public void Start()
	{
		_HP = initHP;
	}
}
