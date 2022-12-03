using UnityEngine;


public class Action : MonoBehaviour
{
	private enum Status
	{
		NONE,
		WAIT,
		RUN
	}

	[SerializeField]
	protected float coolDownTime;

	protected float coolDownReduction = 0f;

	[SerializeField]
	protected float delayTime;

	[SerializeField]
	protected float duration;

	[SerializeField]
	protected float effectTime;

	private bool _effectPlayed = false;

	private bool _available = true;

	private Status _status = Status.NONE;

	private float timeCounter = 0f;

	private float timeCounterCoolDown = 0f;

	[SerializeField]
	protected int _maxTime = int.MaxValue;

	protected int _remain;

	protected float actualCoolDownTime => coolDownTime - coolDownReduction;

	public float DelayTime
	{
		get
		{
			return delayTime;
		}
		set
		{
			delayTime = value;
		}
	}

	public bool available => _available;

	public bool isActive => (_status != 0) ? true : false;

	public float cooldownPercentage
	{
		get
		{
			if (_available)
			{
				return 0f;
			}
			return 1f - timeCounterCoolDown / actualCoolDownTime;
		}
	}

	public int remain
	{
		get
		{
			if (_maxTime == int.MaxValue)
			{
				return -10;
			}
			return _remain;
		}
	}

	private void Update()
	{
		if (_status != 0 && _available)
		{
			_available = false;
			timeCounter += Time.deltaTime;
			if (timeCounter >= effectTime && !_effectPlayed)
			{
				_effectPlayed = true;
				PlayEffect();
			}
			if (timeCounter >= delayTime && _status == Status.WAIT )
			{
				BeginAction();
				_status = Status.RUN;
			}
			if (_status == Status.RUN)
			{
				RunAction();
			}
			if (timeCounter >= delayTime + duration && _status == Status.RUN)
			{
				EndAction();
				_status = Status.NONE;
			}
		}
		if (!_available)
		{
            timeCounterCoolDown += Time.deltaTime;
			if (timeCounterCoolDown > actualCoolDownTime)
			{
				FinishCoolDown();
			}
		}
	}

	public void Call()
	{
		_effectPlayed = false;
		_status = Status.WAIT;
		timeCounter = 0f;
	}

	public void FinishCoolDown()
	{
		_available = true;
		timeCounterCoolDown = 0f;
	}




	protected virtual void BeginAction()
	{
	}

	protected virtual void EndAction()
	{
	}

	protected virtual void RunAction()
	{
	}

	protected virtual void PlayEffect()
	{
	}
}
