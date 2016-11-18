using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    private int dustCount;

    [SerializeField] private Vector2 spawnCoordinates;
    private PolygonCollider2D coll;

    // Use this for initialization
    void Start ()
    {
        dustCount = 0;
        coll = GetComponent<PolygonCollider2D>();
        respawn();
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void AddDust()
    {
        if (this.dustCount < 10)
        {
            this.dustCount++;
            UpdateDustCountText();
        }   
    }

    public int GetDustCount()
    {
        return this.dustCount;
    }

    public void UpdateDustCountText()
    {
        GameObject obj =  GameObject.Find("DustCountText");
        obj.GetComponent<Text>().text = this.dustCount + "/10";
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Asteroid") respawn();
    }

    public void QuitLevel()
    {
        print("work");
    }

    /****************** PRIVATE METHODS **********************/
    private void respawn()
    {
        transform.position = spawnCoordinates;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

}
