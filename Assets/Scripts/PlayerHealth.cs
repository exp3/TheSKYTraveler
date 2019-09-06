using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

	public GameObject effectPrefab;
	public int playerHP;
	private Slider playerHPSlider;
	public GameObject[] playerIcons;
	public int destroyCount = 0;
	public bool isMuteki = false;

	void Start()
	{
		playerHPSlider = GameObject.Find("PlayerHPSlider").GetComponent<Slider>();
		playerHPSlider.maxValue = playerHP;
		playerHPSlider.value = playerHP;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("EnemyMissile") && isMuteki == false)
		{

			playerHP -= 1;


			playerHPSlider.value = playerHP;

			Destroy(other.gameObject);

			if (playerHP == 0)
			{

				// ★（追加）
				// HPが０になったら破壊された回数を１つ増加させる。
				destroyCount += 1;

				// ★（追加）
				// 命令ブロック（メソッド）を呼び出す。
				UpdatePlayerIcons();

				GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity) as GameObject;
				Destroy(effect, 1.0f);
				this.gameObject.SetActive(false);

				if (destroyCount < 4)
					// リトライの命令ブロック（メソッド）を１秒後に呼び出す。
					Invoke("Retry", 1.0f);
				else
					// ゲームオーバーシーンに遷移する。
					Invoke("GameOver", 2.0f);
			}
		}
		if (other.gameObject.CompareTag("Enemy") && isMuteki == false)
		{

			playerHP -= 1;


			playerHPSlider.value = playerHP;

			if (playerHP == 0)
			{

				// ★（追加）
				// HPが０になったら破壊された回数を１つ増加させる。
				destroyCount += 1;

				// ★（追加）
				// 命令ブロック（メソッド）を呼び出す。
				UpdatePlayerIcons();

				GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity) as GameObject;
				Destroy(effect, 1.0f);
				this.gameObject.SetActive(false);

				if (destroyCount < 4)
					// リトライの命令ブロック（メソッド）を１秒後に呼び出す。
					Invoke("Retry", 1.0f);
				else
					// ゲームオーバーシーンに遷移する。
					Invoke("GameOver", 1.0f);
			}
		}
	}

	// ★（追加）
	// プレーヤーの残機数を表示する命令ブロック（メソッド）
	void UpdatePlayerIcons()
	{

		// for文（繰り返し文）・・・まずは基本形を覚えましょう！
		for (int i = 0; i < playerIcons.Length; i++)
		{
			if (destroyCount <= i)
			{
				playerIcons[i].SetActive(true);
			}
			else
			{
				playerIcons[i].SetActive(false);
			}
		}
	}

	void Retry()
	{
		this.gameObject.SetActive(true);
		playerHP = 2; // ここの数字は自分が決めたプレーヤーのHP数にすること
		playerHPSlider.value = playerHP;

		isMuteki = true;
		Invoke("MutekiOff", 2.0f);
	}

	void MutekiOff()
	{
		isMuteki = false;
	}
	void GameOver()
	{
		SceneManager.LoadScene("GameOver");
	}
}