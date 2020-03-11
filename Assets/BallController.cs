using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

  // オブジェクトと衝突時に呼ばれる
  private void OnCollisionEnter(Collision other) {
    Debug.Log("衝突");
    GetComponent<Rigidbody>().isKinematic = true;
  }

  void Start() {
  }

  void Update() {
  }

  public void Shot(Vector3 dir) {
    GetComponent<Rigidbody>().AddForce(dir);
  }
}
