using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            col.gameObject.GetComponent<Player>().AddEnergy();
        }
    }
}
