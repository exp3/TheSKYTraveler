using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ★追加（ステージクリアー）
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{

	public GameObject effectPrefab;
	public int enemyHP;
	public int scoreValue;
	private ScoreManager sm;



	void Start()
	{
		sm = GameObject.Find("ScoreLabel").GetComponent<ScoreManager>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Missile"))
		{
			GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity) as GameObject;
			Destroy(effect, 0.5f);
			enemyHP -= 1;
			Destroy(other.gameObject);


			if (enemyHP == 0)
			{

				// ★変更（ステージクリアー）
				// ↓下記の１行を「//」で「コメントアウト」にする（重要ポイント）
				// Destroy (transform.root.gameObject);

				// ★追加（ステージクリアー）
				// 親オブジェクトを非表示にする
				transform.root.gameObject.SetActive(false);


				sm.AddScore(scoreValue);


				// ★追加（ステージクリアー）
				// （条件）親オブジェクトに「Boss」というTagがついていたならば（ポイント）
				if (this.gameObject.transform.root.CompareTag("Boss"))
				{
					// １秒後にシーン遷移のメソッドを実行する。
					Invoke("GoNextStage", 1);
				}
				Destroy(gameObject);
			}
		}
		if (other.gameObject.CompareTag("Player"))
		{
			GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity) as GameObject;
			Destroy(effect, 0.5f);
			enemyHP -= 1;

			if (enemyHP == 0)
			{

				// ★変更（ステージクリアー）
				// ↓下記の１行を「//」で「コメントアウト」にする（重要ポイント）
				// Destroy (transform.root.gameObject);

				// ★追加（ステージクリアー）
				// 親オブジェクトを非表示にする
				transform.root.gameObject.SetActive(false);


				sm.AddScore(scoreValue);


				// ★追加（ステージクリアー）
				// （条件）親オブジェクトに「Boss」というTagがついていたならば（ポイント）
				if (this.gameObject.transform.root.CompareTag("Boss"))
				{
					// １秒後にシーン遷移のメソッドを実行する。
					Invoke("GoNextStage", 1);
				}
				Destroy(gameObject);
			}
		}

		// ★追加（ステージクリアー）
		// シーン遷移のメソッド

	}
	void GoNextStage()
	{
		SceneManager.LoadScene("GameClear");
	}
}