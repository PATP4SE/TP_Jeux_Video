using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

    [SerializeField] private float speed = 0;
    [SerializeField] private float decreasePercentage = 0;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
	    rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(0, 0);

            Quaternion temp = transform.rotation;

            transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);

            rb.AddForce(transform.forward * speed, ForceMode2D.Impulse);

            transform.rotation = temp;
        }

        if (!((rb.velocity.x <= 0.0001 && rb.velocity.x >= -0.0001) && (rb.velocity.y <= 0.0001 && rb.velocity.y >= -0.0001)))
        {
            DecreaseSpeed();
        }

	}

    private void DecreaseSpeed()
    {
        rb.velocity = new Vector2(rb.velocity.x * (decreasePercentage/100) , rb.velocity.y * (decreasePercentage/100));
    }
}
