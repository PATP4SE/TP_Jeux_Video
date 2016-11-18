using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {


    private Collider2D coll;
    [SerializeField] private Transform asteroidDust;

	// Use this for initialization
	void Start ()
    {
        coll = GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (coll.bounds.Contains(mousePosition))
            {
                Destroy(this.gameObject);
                Instantiate(asteroidDust, transform.position, new Quaternion());
            }
        }
    }
}
