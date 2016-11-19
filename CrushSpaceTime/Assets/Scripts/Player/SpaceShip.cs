using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour {

    [SerializeField] private Transform bullets;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }

    private void shoot()
    {
        Instantiate(bullets, transform.position, new Quaternion());
    }
}
