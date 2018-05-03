using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerBehavior : MonoBehaviour {

    [SerializeField] private int health;
    public bool gameOver = false;
    public GameObject[] hearts;

	//
	public Text countText;
	private int count;

	//for score
	public int score;

	void Start () {

        health = 3;
		count = 0;
		SetCountText();
	
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
			count = count + 1;
			SetCountText ();
		}
	}


	void SetCountText(){
		countText.text = "Gimps Collected: " + count.ToString ();
	}
}
