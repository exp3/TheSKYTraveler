using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking2 : MonoBehaviour {
	Text scoreLabell2;

	// Use this for initialization
	void Start () {
		int hightscore1 = Ranking.hightscore;
		scoreLabell2 = this.gameObject.GetComponent<Text>();
		scoreLabell2.text = "No.1 " + hightscore1;

	}
}
