using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {

  GameObject imgLife;
  GameObject timeText;
  GameObject snowmanText;
  GameObject snowmanGenerator;
  float time = 15.0f;
  int life = 3;

  public void Attacked() {
    this.life -= 1;

    if (life == 2) {
      this.imgLife = GameObject.Find("LifeLeft");
      Destroy(this.imgLife);
    } else if (life == 1) {
      this.imgLife = GameObject.Find("LifeCenter");
      Destroy(this.imgLife);
    } else if(life == 0) {
      this.imgLife = GameObject.Find("LifeRight");
      Destroy(this.imgLife);
      End();
    }

  }

  public void End() {
    SceneManager.LoadScene("ClearScene");
  }

  void Start() {
    this.timeText = GameObject.Find("TimeCount");
    this.snowmanText = GameObject.Find("SnowmanCount");
    this.snowmanGenerator = GameObject.Find("SnowmanGenerator");
  }

  void Update() {
    this.time -= Time.deltaTime;
    this.timeText.GetComponent<Text>().text = this.time.ToString("F0");
    this.snowmanText.GetComponent<Text>().text = this.snowmanGenerator.GetComponent<SnowmanGenerator>().count.ToString("F0");
    if (this.time < 0) {
      this.timeText.GetComponent<Text>().text = "0";
      this.snowmanGenerator.GetComponent<SnowmanGenerator>().SetParameter(1000.0f, 0, 0);
      End();
    } else if (0 <= this.time && this.time < 5) {
      this.snowmanGenerator.GetComponent<SnowmanGenerator>().SetParameter(0.7f, 1.0f, 3);
    } else if (5 <= this.time && this.time < 10) {
      this.snowmanGenerator.GetComponent<SnowmanGenerator>().SetParameter(0.8f, 0.8f, 6);
    } else if (10 <= this.time && this.time < 15) {
      this.snowmanGenerator.GetComponent<SnowmanGenerator>().SetParameter(0.8f, 0.5f, 4);
    } else if (15 <= this.time && this.time < 30) {
      this.snowmanGenerator.GetComponent<SnowmanGenerator>().SetParameter(1.0f, 0.03f, 2);
    }
  }
}
