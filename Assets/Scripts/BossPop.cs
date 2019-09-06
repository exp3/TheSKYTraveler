
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPop : MonoBehaviour
{

	public GameObject enemy1Prefab;

	private int timeCount = 0;

	void Update()
	{

		timeCount += 1;

		// 「%」と「==」の意味を復習しましょう！（ポイント）
		if ( timeCount == 9000)
		{

			// 敵のミサイルを生成する
			GameObject enemy1 = Instantiate(enemy1Prefab, transform.position, Quaternion.identity) as GameObject;


		}
	}
}