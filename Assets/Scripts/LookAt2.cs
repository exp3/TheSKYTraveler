using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//一定周期で向きを変えるクラス
public class LookAt2 : MonoBehaviour
{
	public float a;
	public bool isTurn = false;
	private int num;
	private GameObject target;

	//ターンするまでの時間
	public float turnSpeed;

	void Start()
	{
		StartCoroutine(SwitchNum());

	}

	void Update()
	{
		a = a + 1f * num;
		//回転を指示
		transform.rotation = Quaternion.Euler(0, a , 0);
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