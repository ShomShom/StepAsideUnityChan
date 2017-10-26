using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {


	//carPrefabを入れる
	public GameObject carPrefab;
	//coinPrefabを入れる
	public GameObject coinPrefab;
	//cornPrefabを入れる
	public GameObject conePrefab;
	//Genneratorを入れる
	public GameObject Generator;
	//unityChan
	public GameObject unitychan;

	//スタート地点
	private float startPos = -160;
	//ゴール地点
	private int goalPos = 110;
	//アイテムを出すx方向の範囲
	private float posRange = 3.4f;
	//Unityちゃんとカメラの距離
	private float difference;


	// Use this for initialization
	void Start () {
		this.difference = unitychan.transform.position.z - Generator.transform.position.z;
	}

	// Update is called once per frame
	void Update () {
		if ( Generator != null ){
			float GeneratorZ = Generator.transform.position.z;
			float UnichanZ = unitychan.transform.position.z;

			//もしゆにティーちゃんと棒の距離が一定の距離以内になったら、
			if (UnichanZ - GeneratorZ >= this.difference) {
				//一定の距離ごとにアイテムを生成
				if ((GeneratorZ - startPos) % 15 == 0) {
					//どのアイテムを出すのかをランダムに設定
					int num = Random.Range (0, 10);
					if (num <= 1) {
						//コーンをx軸方向に一直線に生成
						for (float j = -1; j <= 1; j += 0.4f) {
							GameObject cone = Instantiate (conePrefab) as GameObject;
							cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, GeneratorZ);
						}
					} else {
						//レーンごとにアイテムを生成
						for (int j = -1; j < 2; j++) {
							//アイテムの種類を決める
							int item = Random.Range (1, 11);
							//アイテムを置くZ座標のオフセットをランダムに設定
							int offsetZ = Random.Range (-5, 6);
							//60%コイン配置:30%車配置:10%何もなし
							if (1 <= item && item <= 6) {
								//コインを生成
								GameObject coin = Instantiate (coinPrefab) as GameObject;
								coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, GeneratorZ + offsetZ);
							} else if (7 <= item && item <= 9) {
								//車を生成
								GameObject car = Instantiate (carPrefab) as GameObject;
								car.transform.position = new Vector3 (posRange * j, car.transform.position.y, GeneratorZ + offsetZ);
							}
						}
					}
					Destroy (Generator);
					if (GeneratorZ < goalPos) {
						Generator = Instantiate (Generator) as GameObject;
						Generator.transform.position = new Vector3 (0, Generator.transform.position.y, GeneratorZ + 15);
					}
				}
			}
		}
	}
}