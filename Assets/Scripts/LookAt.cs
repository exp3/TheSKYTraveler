using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LookAt : MonoBehaviour
{
	public float kakudo;

	private GameObject target;

	float vecx;
	float vecz;

	float mehx;
	float mehz;

	float gaiseki;
	float nowkakudo=0;
	float sotaikaku;
	float soutaikaku;

	private void Start()
	{
		target = GameObject.Find("Player");
		StartCoroutine(Loop());
	}

	IEnumerator Loop()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.02f);
			ontimer();
		}
	}

	void ontimer()
	{
		vecx = this.gameObject.transform.position.x - target.transform.position.x;
		vecz = this.gameObject.transform.position.z - target.transform.position.z;

		mehx = this.gameObject.transform.forward.x;
		mehz = this.gameObject.transform.forward.z;

		gaiseki = (vecz * mehx) - (vecx * mehz);

		sotaikaku = Mathf.Acos(-(vecx*mehx+vecz*mehz)/(Mathf.Sqrt(vecx*vecx+vecz*vecz)*Mathf.Sqrt(mehx*mehx+mehz*mehz)));
		soutaikaku = (sotaikaku / ( 2 * 3 )) * 360;

		if (soutaikaku <= -30 || soutaikaku >= 30)
		{
			if (gaiseki < 0)
			{
				nowkakudo = nowkakudo - kakudo;
				this.gameObject.transform.rotation = Quaternion.AngleAxis(nowkakudo, new Vector3(0, 1, 0));
			}
			else
			{
				nowkakudo = nowkakudo + kakudo;
				this.gameObject.transform.rotation = Quaternion.AngleAxis(nowkakudo, new Vector3(0, 1, 0));
			}
		}
	}
}