using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour {

  public GameObject ball01Prefab;
  public GameObject ball02Prefab;
  public GameObject ball03Prefab;

  void Start() {
  }

  void Update() {
    if (Input.GetMouseButtonDown(0)) {
      GameObject ball02 = Instantiate(ball02Prefab) as GameObject;
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      Vector3 worldDir = ray.direction;

      ball02.GetComponent<BallController>().Shot(worldDir.normalized * 2000);
    }
  }

}
