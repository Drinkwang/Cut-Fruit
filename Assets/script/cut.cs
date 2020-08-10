using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class cut : MonoBehaviour {
	public GameObject fruit,mine,original,gameover;
	public LineRenderer cutline;
	public Text score;
	[Range(0,1000)]
	public float size;
	public  int goal=0;
	public Text fial;

	private List<Vector3> allvertex= new List<Vector3>();
	// Use this for initialization
	void Start () {
		Debug.Log(Screen.currentResolution.height);
		Debug.Log(Screen.currentResolution.width);

		InvokeRepeating("makefruit",2,5);
	}
	void makefruit(){int random = Random.Range (0, 100);
		if(random>50)
			Instantiate(mine,original.transform.position,Quaternion.identity);
		else	Instantiate(fruit,original.transform.position,Quaternion.identity); }
	// Update is called once per frame
	void Update ()
	{
		
		score.text = "Score:" + goal;
		if (Input.GetMouseButton (0)&&gameover.activeSelf==false) {
			StartCoroutine (too());
			allvertex.Add (new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0));

			Vector3[] temp = allvertex.ToArray ();
			cutline.SetVertexCount (temp.Length);
			cutline.SetPositions (temp);

		
			RaycastHit2D[] a;
			a = Physics2D.RaycastAll (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			foreach (RaycastHit2D t in a) {
				if (t.collider.tag == "fruit") {
					t.transform.GetChild (1).GetComponent<Rigidbody2D> ().AddForce (Vector3.left * size);
					t.transform.GetChild (2).GetComponent<Rigidbody2D> ().AddForce (Vector3.right * size);

					Destroy (t.transform.GetChild (0).gameObject);
					t.collider.tag = "Finish";
					goal++;
					//Debug.Log ("HELLO");
				}if (t.collider.tag == "boom") {
					
					Destroy(t.transform.gameObject.GetComponent<Rigidbody2D> ());
					t.transform.GetComponent<Animator> ().SetBool ("start", true);
					AnimatorStateInfo s= t.transform.GetComponent<Animator> ().GetCurrentAnimatorStateInfo(0);
					if(s.IsName("boom")&&s.normalizedTime>0.5f)
					{gameover.SetActive (true);
						Destroy (t.transform.gameObject);
					} 
					//Debug.Log ("HELLO");
					goal++;

				}
					
			}
		} 


		

	}
	private IEnumerator too()
	{yield return new WaitForSeconds (0.2f);
		allvertex.Clear ();
	}
}

