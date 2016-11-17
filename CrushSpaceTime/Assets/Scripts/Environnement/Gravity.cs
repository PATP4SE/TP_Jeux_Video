using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

    [SerializeField] private float decreasePercentage = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        Object[] objects = GameObject.FindObjectsOfType(typeof(GameObject));

        foreach (GameObject obj in objects)
        {
            Rigidbody2D rbody = obj.GetComponent<Rigidbody2D>();
            if (rbody != null)
            { 
                if (!((rbody.velocity.x <= 0.0001 && rbody.velocity.x >= -0.0001) && (rbody.velocity.y <= 0.0001 && rbody.velocity.y >= -0.0001)))
                {
                    float percent = (100f - decreasePercentage);
                    rbody.velocity = new Vector2(rbody.velocity.x * (percent / 100f), rbody.velocity.y * (percent / 100f));
                }
            }
        }
    }
}
