
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPop : MonoBehaviour
{

	public GameObject enemy1Prefab;
	public float enemySpeed;
	private int timeCount = 0;
	public int Poprate;
	public int under;
	public int max;

	void Update()
	{

		timeCount += 1;

		// 「%」と「==」の意味を復習しましょう！（ポイント）
		if (timeCount % Poprate == 0  && timeCount <= max && timeCount >= under)
		{

			// 敵のミサイルを生成する
			GameObject enemy1 = Instantiate(enemy1Prefab, transform.position, Quaternion.identity) as GameObject;

			Rigidbody enemy1Rb = enemy1.GetComponent<Rigidbody>();

			// ミサイルを飛ばす方向を決める。「forward」は「z軸」方向をさす（ポイント）
			enemy1Rb.AddForce(transform.forward * -enemySpeed);

			// ３秒後に敵のミサイルを削除する。
			Destroy(enemy1, 10.0f);

		}
	}
}