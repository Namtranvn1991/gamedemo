using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
	protected EnemyMovement _movement;


	public EnemyMovement movement => _movement;


	protected bool Check(LayerMask layer, Direction direction, float distance = 0.2f)
	{
		return Physics.CheckSphere(base.transform.position + direction.ToVector3() * distance, 0.4f, layer);
	}

	protected bool Look(LayerMask layer, Direction direction, float distance = 0.2f)
	{
		return Physics.SphereCast(new Ray(base.transform.position, direction.ToVector3()), 0.4f, distance, layer);
	}

	protected Collider[] Overlap(LayerMask layer, Direction direction, float distance = 0.2f)
	{
		Collider[] array = Physics.OverlapSphere(base.transform.position + direction.ToVector3() * distance, 0.4f, layer);
		List<Collider> list = new List<Collider>();
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (collider.transform != base.transform)
			{
				list.Add(collider);
			}
		}
		return list.ToArray();
	}

	public virtual void ChangeBehavior()
	{
	}

	public virtual void ChangeBehaviorToNormal()
	{
	}

	public virtual bool ChooseTarget()
	{
		return false;
	}
}
