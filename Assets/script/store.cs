using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class store : MonoBehaviour {
	private AudioSource my;
	public  bool[] b5;
	public  GameObject[] a5;
	public  int conum;
	public Text a;
	public GameObject bg;

	// Use this for initialization
	void Start () {
		my = gameObject.GetComponent<AudioSource> ();
		bg = GameObject.Find ("maide");
	

		for (int i = 0; i < 5;i++ ) {
			PlayerPrefs.GetString ("d" + i);
			Debug.Log (PlayerPrefs.GetString ("d" + i));
			if (PlayerPrefs.GetString ("d" + i) == "True") {
				
				b5 [i] = true;}
		}
	
	}
	void Awake()
	{	
	}

	// Update is called once per frame
	void Update () {
		conum = PlayerPrefs.GetInt ("coin");
		a.text = "x" + conum;
		for (int i = 0; i < 5; i++) {
			if (b5 [i] == true) {
				Color coa = a5 [i].transform.GetChild(0).GetComponent<Image> ().color;
				Color a = new Color (coa.r,coa.g, coa.b, 0.2f);
				a5 [i].transform.GetChild (0).GetComponent<Image> ().color = a;
			}
		}

	}
	public void buttondown(GameObject a)
	{//Debug.Log (a.GetComponent<Transform> ().GetChild(0).name);
		Transform child=a.GetComponent<Transform> ().GetChild(0);
		if (b5 [int.Parse (child.name) - 1] == false && conum > 0) {
			child.GetComponent<Image> ().CrossFadeAlpha (0.2f, 0.4f, true);
			my.Play ();
			b5 [int.Parse (child.name) - 1] = true;
			conum--;

		} else if (b5 [int.Parse (child.name) - 1] == true) {
			for (int i = 0; i < 5; i++) {
				bg.transform.GetChild (i).gameObject.SetActive (false);
			}
			bg.transform.GetChild (int.Parse (child.name) - 1).gameObject.SetActive (true);
			//Debug.Log ("你已经换装成功！");
		}
			

	//	Debug.Log(b5 [0].ToString());
		PlayerPrefs.SetInt("coin",conum);
		PlayerPrefs.SetString ("d0", b5 [0].ToString());
		PlayerPrefs.SetString ("d1", b5 [1].ToString());
		PlayerPrefs.SetString ("d2", b5 [2].ToString());
		PlayerPrefs.SetString ("d3", b5 [3].ToString());
		PlayerPrefs.SetString ("d4", b5 [4].ToString());
	}
	public void aaa()
	{for (int i = 0; i < 5; i++) {
			bg.transform.GetChild (i).gameObject.SetActive (false);
		}
	}
}
