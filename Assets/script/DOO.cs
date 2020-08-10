using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DOO : MonoBehaviour {
	public static DOO instance=null;
	//private int[][] my;

	public static int finalscore=0;
	public Text fial;

	public void jj(){
		fial.text = "最高分:" + DOO.finalscore;
	}
	// Use this for initialization
	void Awake () {
		jj ();
		if (instance != null) {

			Destroy (this.gameObject);
			return;
		
		} else if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/*public void getmessagerank(int score,int rank)
	{
		
	}*/
}
