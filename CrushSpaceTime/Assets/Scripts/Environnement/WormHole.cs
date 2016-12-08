using UnityEngine;
using System.Collections;

public class WormHole : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SpaceShip")
        {
            Destroy(other.gameObject);
            GetComponent<GameController>().finishLevel();
        }
    }
}
