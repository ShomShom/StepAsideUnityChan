using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//トリガーモードで他のオブジェクトと接触した場合の処理（追加）
	void OnTriggerEnter(Collider other) {
		//障害物に衝突した場合
		if (other.gameObject.tag == "CarTag") {
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "TrafficConeTag") {
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "CoinTag") {
			Destroy (other.gameObject);
		}	

	}
}
