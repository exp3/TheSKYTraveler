using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ★追加
using UnityEngine.UI;

public class StageNumber : MonoBehaviour
{

	// ★追加
	private Text stageNumberText;

	void Start()
	{
		// ★追加
		// 「Text」コンポーネントにアクセスして取得する。
		stageNumberText = this.gameObject.GetComponent<Text>();
	}

	void Update()
	{
		// ★追加
		stageNumberText.color = Color.Lerp(stageNumberText.color, new Color(1, 1, 1, 0), 0.5f * Time.deltaTime);
	}
}