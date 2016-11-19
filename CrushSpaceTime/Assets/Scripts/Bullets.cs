using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour {

    [SerializeField] private float speed;

	// Use this for initialization
	void Start ()
    {
        transform.rotation = GameObject.FindGameObjectWithTag("SpaceShip").transform.rotation;
        push();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    private void push()
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();

        rbody.velocity = new Vector2(0, 0);
        Quaternion temp = transform.rotation;


        if (transform.rotation.z == 0)
        {
            transform.LookAt(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z));
        }
        else if (transform.rotation.z == -1f)
        {
            transform.LookAt(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z));
        }
        else if (transform.rotation.z > 0)
        {
            transform.LookAt(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z));
        }
        else if (transform.rotation.z < 0)
        {
            transform.LookAt(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z));
        }

        rbody.AddForce(transform.forward * speed, ForceMode2D.Impulse);

        transform.rotation = temp;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        print("asdasdasd");
        if (col.gameObject.name.Contains("AsteroidWithoutMovement"))
        {
            Destroy(this.gameObject);
            Destroy(col.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        print("222");
        if (col.gameObject.name.Contains("AsteroidWithoutMovement"))
        {
            Destroy(this.gameObject);
            Destroy(col.gameObject);
        }
    }

}
