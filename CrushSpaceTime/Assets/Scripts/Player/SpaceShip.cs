using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour {

    [SerializeField] private Transform bullets;
    private AudioSource[] audioSources;
    private AudioSource shotAudio;
    private KeyCode exitKey;

    // Use this for initialization
    void Start ()
    {
        audioSources = GetComponents<AudioSource>();
        shotAudio = audioSources[1];
        System.String exitKeyString = PlayerPrefs.GetString("ExitSpaceShipPref");
        if (exitKeyString.Contains("ESPACE")) exitKeyString = "Space";
        exitKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), exitKeyString);
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }

        if (Input.GetKeyDown(exitKey))
        {
            LeaveShip();
        }
    }

    private void shoot()
    {
        Instantiate(bullets, transform.position, new Quaternion());
        shotAudio.Play();
    }

    private void LeaveShip()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        this.GetComponent<PlayerMove>().enabled = false;
        this.GetComponent<Repulse>().enabled = false;
        this.GetComponent<SpaceShip>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = true;
        this.GetComponent<PolygonCollider2D>().enabled = false;

        player.GetComponent<Player>().SetIsInSpaceShip(false);
        GameObject.Find("Game Controller").GetComponent<GameController>().SetIsInSpaceShip(false);
        player.GetComponent<Player>().DisableTriggerCollision(1);

        player.transform.position = new Vector3(transform.position.x, transform.position.y, -1);

        player.GetComponent<PlayerMove>().enabled = true;
        player.GetComponent<Repulse>().enabled = true;
        player.GetComponent<CircleCollider2D>().enabled = true;
    }
}
