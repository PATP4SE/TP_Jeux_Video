using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    [SerializeField] private float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(0, speed, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-speed, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(0, -speed, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(speed, 0, 0);
        }
    }
}
