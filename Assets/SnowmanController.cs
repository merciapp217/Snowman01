using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanController : MonoBehaviour {

  public float speed;
  GameObject GameDirector;
  GameObject SnowmanGenerator;
  GameObject CameraController;

  public void OnTriggerEnter(Collider other) {
    string tag = other.gameObject.tag;

    if(tag == "MainCamera") {
      this.CameraController.GetComponent<CameraController>().HitDamage();
      this.GameDirector.GetComponent<GameDirector>().Attacked();
    } else if(tag == "Ball02") {
      Destroy(other.gameObject);
      Destroy(this.gameObject);
      this.SnowmanGenerator.GetComponent<SnowmanGenerator>().KnockDown();
    }
  }

  void Start() {
    this.GameDirector = GameObject.Find("GameDirector");
    this.SnowmanGenerator = GameObject.Find("SnowmanGenerator");
    this.CameraController = GameObject.Find("Main Camera");
  }

  void Update() {
    transform.Translate(0, 0, this.speed);

    // スノーマンがカメラの見えない位置にきたら消す
    float z = transform.position.z;
    if(z < -10.0f) {
      Destroy(this.gameObject);
    }
  }
}
