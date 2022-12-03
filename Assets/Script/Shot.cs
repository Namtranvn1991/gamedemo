using UnityEngine;


public class Shot : Action
{
	[SerializeField]
	private Transform initPoint;

	[SerializeField]
	private Bullet bullet;

	public LayerMask hitLayer;

	public LayerMask blockLayer;

	[SerializeField]
	private int _damage;

	[SerializeField]
	private float _range;

	[SerializeField]
	private float bulletSpeed;

	public float range => _range;

	public int remainBullet => _remain;

	public bool outBullet => _remain <= 0;

	private void Start()
	{
		_remain = _maxTime;
	}

	public void Restore()
	{
		_remain = _maxTime;
	}

	protected override void BeginAction()
	{
		_remain--;
		Bullet bullet = Object.Instantiate(this.bullet, initPoint.position, base.transform.rotation);
		bullet.Init(base.transform.rotation * Vector3.forward, bulletSpeed, _range, _damage, hitLayer, blockLayer);
	}

	public void ShotBullet()
    {
		Bullet bullet = Object.Instantiate(this.bullet, initPoint.position, base.transform.rotation);
		bullet.Init(base.transform.rotation * Vector3.forward, bulletSpeed, _range, _damage, hitLayer, blockLayer);
	}
}
