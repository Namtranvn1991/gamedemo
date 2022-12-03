using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Entity
{
	protected Vector3 _direction;

	protected float _speed;

	protected float _timeExist;

	protected int _damage;

	protected LayerMask _hitLayer;

	protected LayerMask _blockLayer;

	protected float timeCounter = 0f;

	protected bool isActive = false;

	public virtual void Init(Vector3 direction, float speed, float range, int damage, LayerMask hitLayer, LayerMask blockLayer)
	{
		_direction = direction;
		_speed = speed;
		_timeExist = range / speed;
		_damage = damage;
		_hitLayer = hitLayer;
		_blockLayer = blockLayer;
		timeCounter = 0f;
		isActive = true;
	}

	private void Update()
	{
		if (isActive)
		{
			timeCounter += Time.deltaTime;
			if (timeCounter > _timeExist)
			{
				Die();
			}
			base.transform.position += _direction * _speed * Time.deltaTime;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.name);
		if ((int)_blockLayer == ((int)_blockLayer | (1 << other.gameObject.layer))) 
		{
			Debug.Log("block");
			if ((int)_hitLayer == ((int)_hitLayer | (1 << other.gameObject.layer)))
			{
				Debug.Log("hit");
				other.gameObject.GetComponent<IDamageable>()?.ReceiveDamage(_damage);
			}
			Die();
		}

	}

    public override void Die()
	{
		base.gameObject.SetActive(value: false);

	}
}