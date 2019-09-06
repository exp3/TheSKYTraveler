using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ★追加
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

	// ★追加
	public static int score = 0;
	private static Text scoreLabel;


	void Start()
	{
		score = 0;
		// ★追加
		// 「Text」コンポーネントにアクセスして取得する（ポイント）
		scoreLabel = this.gameObject.GetComponent<Text>();
		scoreLabel.text = "Score " + score;
	}

	// ★追加
	// スコアを加算するメソッド（命令ブロック）
	// 「public」をつけて外部からこのメソッドにアクセスできるようにする（重要ポイント）
	public void AddScore(int amount)
	{

		// 「amount」に入ってくる数値分を加算していく。
		score += amount;

		scoreLabel.text = "Score " + score;
	}
}