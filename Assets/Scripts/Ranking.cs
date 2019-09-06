using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ★追加
using UnityEngine.UI;

public class Ranking: MonoBehaviour
{

	// ★追加
	Text scoreLabel1;
	public static int hightscore = 0;

	void Start()
	{
		int score1 = ScoreManager.score;
		// ★追加
		// 「Text」コンポーネントにアクセスして取得する（ポイント）
		scoreLabel1 = this.gameObject.GetComponent<Text>();
		if(score1 > hightscore)
		{
			hightscore = score1;
		}
		scoreLabel1.text = "Score " + score1;
	}
}