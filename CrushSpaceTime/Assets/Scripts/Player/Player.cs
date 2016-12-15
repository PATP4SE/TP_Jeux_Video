using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    private int dustCount;
    private int woodCount;
    private bool isInSpaceShip;

    [SerializeField] private int maxDustCount;
    [SerializeField] private int maxWoodCount;
    [SerializeField] private Vector2 spawnCoordinates;

    private Collider2D coll;

    // Use this for initialization
    void Start ()
    {
        this.isInSpaceShip = false;
        dustCount = 0;
        coll = GetComponent<Collider2D>();
        respawn();
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void AddDust()
    {
        if (this.dustCount < maxDustCount)
        {
            this.dustCount++;
            UpdateUIDust();
        }   
    }

    public int GetDustCount()
    {
        return this.dustCount;
    }

    public void AddWood()
    {
        if (this.dustCount < maxDustCount)
        {
            this.dustCount++;
            UpdateUIDust();
        }
    }

    public int GetWoodCount()
    {
        return this.dustCount;
    }

    public void SetIsInSpaceShip(bool _isInSpaceShip)
    {
        this.isInSpaceShip = _isInSpaceShip;
    }

    public bool GetIsInSpaceShip()
    {
        return this.isInSpaceShip;
    }

    public void UpdateUIDust()
    {
        GameObject.Find("DustCountText").GetComponent<Text>().text = this.dustCount + "/10";

        GameObject obj = GameObject.Find("AsteroidDustInventory");
        Color color = obj.GetComponent<Image>().color;

        if (this.dustCount > 0)
        {
            obj.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 255);
        }
        else
        {
            obj.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 255);
        }
    }

    public void UpdateUIWood()
    {
        GameObject obj = GameObject.Find("DustCountText");
        obj.GetComponent<Text>().text = this.dustCount + "/10";
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Asteroid") respawn();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "SpaceShip" && this.dustCount == maxDustCount)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            this.isInSpaceShip = true;
            this.transform.position = new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y, 1);
            this.transform.rotation = new Quaternion(0, 0, -col.gameObject.transform.rotation.z, col.gameObject.transform.rotation.w);

            GetComponent<PlayerMove>().enabled = false;
            GetComponent<Repulse>().enabled = false;
            GetComponent<AudioSource>().Stop();

            col.gameObject.GetComponent<PlayerMove>().enabled = true;
            col.gameObject.GetComponent<Repulse>().enabled = true;
            col.gameObject.GetComponent<SpaceShip>().enabled = true;
            col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            col.gameObject.GetComponent<PolygonCollider2D>().enabled = true;

            gameObject.SetActive(false);
        }
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
