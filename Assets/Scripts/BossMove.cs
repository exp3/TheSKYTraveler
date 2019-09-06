using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{

	[Range(0, 50)]
	public float moveDistance;
	[Range(0, 2)]
	public float turnSpeed;
	public bool isTurn = false;
	private int num;
	private int timeCount = 0;

	private void Start()
	{
		StartCoroutine(SwitchNum());
	}

	void Update()
	{
		timeCount += 1;
		if (timeCount <= 200)
		{
			transform.Translate(moveDistance * Time.deltaTime * num, 0, -moveDistance * Time.deltaTime, Space.World);
		}
		else
		{
			transform.Translate(moveDistance * Time.deltaTime * num, 0, 0, Space.World);
		}

	}

	IEnumerator SwitchNum()
	{
		while (this.gameObject != null)
		{
			if (isTurn == false)
			{
				num = 1;
				yield return new WaitForSeconds(turnSpeed);
				isTurn = true;
			}
			else
			{
				num = -1;
				yield return new WaitForSeconds(turnSpeed);
				isTurn = false;
			}
		}
	}
}