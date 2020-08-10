 using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class dead : MonoBehaviour {
	public Image one,two,three;
	public GameObject gameover, start;
	public cut cut;
	public int length=3;
	Color s = Color.white;
	public bool isup = false;
	public bool money = false;
	public store sto;
	public Font a;
	//public int score ;
	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
	}
	

	void OnTriggerEnter2D(Collider2D x)
	{//Debug.Log ("hellow");
		if (x.tag == "fruit"||x.tag == "boom") {
			switch (length) {
			case 3:
				
				three.color=s;
				break;
			case 2:
				two.color=s;
				break;
			case 1:
				one.color = s;
				StartCoroutine ("e");
			break;}
			length--;
		}
		Destroy (x.gameObject);}
		IEnumerator e()
		{yield return new WaitForSeconds(1f);
		Debug.Log ("you 'r dead");
		gameover.SetActive (true);
		if (DOO.finalscore <= cut.goal)
			DOO.finalscore = cut.goal;
		DOO.instance.jj ();
				}

	public void OnStart()
	{start.SetActive (false);
		Time.timeScale = 1;
	}
	public  void OnOver()
	{//score = cut.goal;
	//	Application.ExternalCall ("SetScore",score);
	SceneManager.LoadScene (0);
	}
	public void Onup()
	{if (isup == false) {
			Application.ExternalCall ("SetRank", cut.goal);

			isup = true;	}}
	public void ad()
	{if (money == false) {
		//	Application.ExternalCall ("playad");
			sto.conum = PlayerPrefs.GetInt ("coin");
			sto.conum++;
			PlayerPrefs.SetInt("coin",sto.conum);
			money = true;
		}	}
	void OnGUI()
	{if (money == true) {
			GUIStyle guis = new GUIStyle ();
			guis.font = a;
			guis.fontSize = 40;
			//	Debug.Log ("dangdangdang");
		//	GUI.Label (new Rect (200, 500, 1000, 800), "已观看完获得金币",guis);
			float time = 0;
			time = time + Time.deltaTime;
			if (time >2)
			money = false;
		
		
		}
		if (isup == true) {
			GUIStyle guis = new GUIStyle ();
			guis.font = a;
			guis.fontSize = 40;
		//	Debug.Log ("dangdangdang");
		//	GUI.Label (new Rect (200, 100, 1000, 800), "已经提交！",guis);
		}
	}
}
