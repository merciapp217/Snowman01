using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanGenerator : MonoBehaviour {

  float span = 1.0f;
  float speed = -0.03f;
  int ratio = 2;
  float delta = 0;
  public GameObject Snowmans;
  public int count = 30; // ここはプライベートであるべきでは？

  public void SetParameter(float span, float speed, int ratio) {
    this.span = span;
    this.speed = speed;
    this.ratio = ratio;
  }

  public void KnockDown() {
    this.count -= 1;
    Debug.Log(this.count);
  }

  void Start() {
  }

  void Update() {
    this.delta += Time.deltaTime;
    if (this.delta > this.span) {
      this.delta = 0;
      GameObject Snowman = Instantiate(Snowmans) as GameObject;
      float x = Random.Range(-8, 8);
      float z = Random.Range(40, 80);
      Snowman.transform.position = new Vector3(x, 0, z);
      Snowman.GetComponent<SnowmanController>().speed = this.speed;
    }
  }
}
