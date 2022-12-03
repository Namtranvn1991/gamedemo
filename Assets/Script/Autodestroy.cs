using UnityEngine;

public class Autodestroy : MonoBehaviour
{
	[SerializeField]
	private float timeExist;

	private void Update()
	{
		if (timeExist > 0f)
		{
			timeExist -= Time.deltaTime;
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}
}
