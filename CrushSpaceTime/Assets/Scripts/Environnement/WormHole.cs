using UnityEngine;
using System.Collections;

public class WormHole : MonoBehaviour {

    private GameObject spaceShip;
    private Animator spaceShipAnim;
    private bool hasEnteredWormhole;

	// Use this for initialization
	void Start () {
        spaceShip = GameObject.FindGameObjectWithTag("SpaceShip");
        spaceShipAnim = spaceShip.GetComponent<Animator>();
        hasEnteredWormhole = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SpaceShip")
        {
            spaceShipAnim.SetBool("isOverWormhole", true);
            spaceShipAnim.Play("SpaceShip_Disapear");
            hasEnteredWormhole = true;
        }
    }

    public bool gethasEnteredWormhole()
    {
        return hasEnteredWormhole;
    }
}
