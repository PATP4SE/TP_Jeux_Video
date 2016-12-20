using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    private int dustCount;
    private int energyCount;
    private bool isInSpaceShip;
    private bool triggerDisabled;

    [SerializeField] private int maxDustCount;
    [SerializeField] private int maxEnergyCount;
    [SerializeField] private Vector2 spawnCoordinates;

    private Collider2D coll;

    // Use this for initialization
    void Start ()
    {
        this.triggerDisabled = false;
        this.isInSpaceShip = false;
        dustCount = 0;
        energyCount = 0;
        coll = GetComponent<Collider2D>();
        respawn();
        UpdateWormholeAnimation();
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

    public int GetMaxDustCount()
    {
        return this.maxDustCount;
    }

    public void emptyDust()
    {
        this.dustCount = 0;
        UpdateUIDust();
    }

    public void AddEnergy()
    {
        if (this.energyCount < maxDustCount)
        {
            this.energyCount++;
            UpdateUIEnergy();
        }
    }

    public int GetEnergyCount()
    {
        return this.energyCount;
    }

    public int GetMaxEnergyCount()
    {
        return this.maxEnergyCount;
    }

    public void emptyEnergy()
    {
        this.energyCount = 0;
        UpdateUIEnergy();
    }

    public void SetIsInSpaceShip(bool _isInSpaceShip)
    {
        this.isInSpaceShip = _isInSpaceShip;
    }

    public bool GetIsInSpaceShip()
    {
        return this.isInSpaceShip;
    }

    public void DisableTriggerCollision(float seconds)
    {
        this.triggerDisabled = true;
        StartCoroutine(Wait(seconds));
    }

    public bool GetTriggerDisabled()
    {
        return this.triggerDisabled;
    }

    public void UpdateUIDust()
    {
        GameObject.Find("DustCountText").GetComponent<Text>().text = this.dustCount + "/" + this.maxDustCount;

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

    public void UpdateUIEnergy()
    {
        GameObject.Find("EnergyCountText").GetComponent<Text>().text = this.energyCount + "/" + this.maxEnergyCount;

        GameObject obj = GameObject.Find("EnergyInventory");
        Color color = obj.GetComponent<Image>().color;

        if (this.energyCount > 0)
        {
            obj.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 255);
        }
        else
        {
            obj.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 255);
        }
        UpdateWormholeAnimation();
    }

    private void UpdateWormholeAnimation()
    {
        if (this.energyCount >= this.maxEnergyCount)
        {
            GameObject.Find("Wormhole").GetComponent<Animator>().enabled = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Asteroid")
        {
            GetComponents<AudioSource>()[1].Play();
            respawn();
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "SpaceShip" && this.dustCount == maxDustCount && !GetTriggerDisabled())
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            this.dustCount = 0;
            UpdateUIDust();

            this.isInSpaceShip = true;
            this.transform.position = new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y, 2);
            this.transform.rotation = new Quaternion(0, 0, -col.gameObject.transform.rotation.z, col.gameObject.transform.rotation.w);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().SetIsInSpaceShip(true);

            GetComponent<PlayerMove>().enabled = false;
            GetComponent<Repulse>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<AudioSource>().Stop();

            col.gameObject.GetComponent<PlayerMove>().enabled = true;
            col.gameObject.GetComponent<Repulse>().enabled = true;
            col.gameObject.GetComponent<SpaceShip>().enabled = true;
            col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            col.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        }
    }

    public void QuitLevel()
    {
        print("work");
    }

    /****************** PRIVATE METHODS **********************/
    private void respawn()
    {
        transform.position = new Vector3(spawnCoordinates.x, spawnCoordinates.y, -1);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        this.triggerDisabled = false;
    }

}
