using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    [SerializeField] public GameObject switchPortal;
    [SerializeField] private float secondsUntilReuse = 1;
    private GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {

	
	}

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && switchPortal != null && !player.GetComponent<Player>().GetTeleported())
        {
            player.GetComponent<Player>().Teleport(secondsUntilReuse);
            player.transform.position = switchPortal.transform.position;
        }
    }

    void OnDrawGizmosSelected()
    {
        Object[] objects = GameObject.FindGameObjectsWithTag("Portal");

        foreach (GameObject obj in objects)
        {
            if (obj.GetComponent<Portal>().switchPortal != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(obj.transform.position,0.3f);
                Gizmos.DrawLine(obj.transform.position, obj.GetComponent<Portal>().switchPortal.transform.position);
            }
        }
    }

}
