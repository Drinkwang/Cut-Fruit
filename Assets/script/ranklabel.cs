using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ranklabel : MonoBehaviour {
	public Text [] iameighth;
	//public int[,] arr=new int[8,2];

	// Use this for initialization
	void Start () {
		//Application.ExternalCall ("GetRank");
		//flushrank("123~222");

	}
	public void flushrank(string a)
	{int score, rank;
		string[] a2; 
		a2 =a.Split ('~');
		score =int.Parse(a2 [0]);
		Debug.Log (score);
		rank = int.Parse(a2 [1]);
		flushrank2 (score, rank);
		Debug.Log (rank);
	}

	 void flushrank2(int score,int rank)
	{
		if(rank<=8)
			iameighth[rank-1].text=score.ToString();
		
	}
	public void ranklabeldown()
	{Application.ExternalCall ("GetRank");
	}
		

	// Update is called once per frame
	void Update () {
		
	}
	///void Textchange(int,int,Text a)
	//{
	//}
}
