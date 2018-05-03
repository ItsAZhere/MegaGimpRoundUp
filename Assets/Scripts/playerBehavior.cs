using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerBehavior : MonoBehaviour {

	[SerializeField] private int health;
	public bool gameOver = false;
	public GameObject[] hearts;

	//for score
	public Text countText;
	private int count;
	public AudioSource portal;
	public AudioSource hurt;


	void Start () {

		Health = 3;
		count = 0;
		SetCountText ();

	}


	public int Health{

		get
		{
			return health;
		}


		set
		{
			health = value;



			if (health <= 0 && !gameOver)
			{
				gameOver = true;
				SceneManager.LoadScene(6); //if health is out, go to end screen


			}


			for (int i = 0; i < hearts.Length; i++)
			{
				if (i < Health)
				{
					hearts[i].SetActive(true);
				}
				else
				{
					hearts[i].SetActive(false);
				}
			}
		}

	}


	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			Destroy (other.gameObject);
			hurt.Play ();
			count = count + 1;
			SetCountText ();
		}

		if (count == 4) {
			SceneManager.LoadScene (3);
		}

		if (count == 11) {
			SceneManager.LoadScene (4);
		}

		if (count == 21) {
			SceneManager.LoadScene (5);
		}


		if (other.gameObject.tag == "Bush") {
			other.GetComponent<SpriteRenderer> ().enabled = false;
		}

		if (other.gameObject.name == "UpBorders") {
			GameObject downborder = GameObject.Find ("DownBorders");
			Vector2 newposition = new Vector2 (downborder.transform.position.x, downborder.transform.position.y + 6f);
			transform.position = newposition;
		}

		if (other.gameObject.name == "DownBorders") {
			GameObject upborder = GameObject.Find ("UpBorders");
			Vector2 newposition = new Vector2 (upborder.transform.position.x, upborder.transform.position.y - 6f);
			transform.position = newposition;
		}

		if (other.gameObject.name == "LeftBorders") {
			GameObject rightborder = GameObject.Find("RightBorders");
			Vector2 newposition = new Vector2 (rightborder.transform.position.x - 6f, rightborder.transform.position.y);
			transform.position = newposition;
		}

		if (other.gameObject.name == "RightBorders") {
			GameObject leftborder = GameObject.Find ("LeftBorders");
			Vector2 newposition = new Vector2 (leftborder.transform.position.x + 6f, leftborder.transform.position.y);
			transform.position = newposition;
		}
	}

	void SetCountText ()
	{
		countText.text = "Gimps Collected: " + count.ToString ();
	}
}

