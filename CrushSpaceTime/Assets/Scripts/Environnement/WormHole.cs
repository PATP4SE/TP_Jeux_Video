using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (other.gameObject.tag == "SpaceShip" && player.GetComponent<Player>().GetEnergyCount() == player.GetComponent<Player>().GetMaxEnergyCount())
        {
            spaceShipAnim.SetBool("isOverWormhole", true);
            spaceShipAnim.Play("SpaceShip_Disapear");
            hasEnteredWormhole = true;
            StartCoroutine(DestroyPlayer());
            StartCoroutine(NextLevel());
        }
    }

    private IEnumerator DestroyPlayer()
    {
        yield return new WaitForSeconds(2);
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        GameObject.FindGameObjectWithTag("SpaceShip").SetActive(false);
    }

    private IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(5);
        if (SceneManager.GetActiveScene().name == "Level1")
            SceneManager.LoadScene(2);
        else
            SceneManager.LoadScene(0);
    }

    public bool gethasEnteredWormhole()
    {
        return hasEnteredWormhole;
    }
}
