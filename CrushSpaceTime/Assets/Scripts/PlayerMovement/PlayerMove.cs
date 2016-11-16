using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    [SerializeField] private float speed = 0;
    [SerializeField] private float decreasePercentage = 0;

    private SpriteRenderer sprite;
    private Rigidbody2D rb;


    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //rb.velocity = new Vector2(0, 0);

            Vector3 vect = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
            transform.LookAt(vect);
            rb.AddForce(transform.forward * speed, ForceMode2D.Impulse);

            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 vect = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
            transform.LookAt(vect);
            rb.AddForce(transform.forward * speed, ForceMode2D.Impulse);

            rotate(0, 0, 90);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 vect = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
            transform.LookAt(vect);
            rb.AddForce(transform.forward * speed, ForceMode2D.Impulse);

            rotate(0, 0, 180);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 vect = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
            transform.LookAt(vect);
            rb.AddForce(transform.forward * speed, ForceMode2D.Impulse);

            rotate(0, 0, -90);
        }

        if (!((rb.velocity.x <= 0.0001 && rb.velocity.x >= -0.0001) && (rb.velocity.y <= 0.0001 && rb.velocity.y >= -0.0001)))
        {
            DecreaseSpeed();
        }
    }

    /************************************ PRIVATE METHODS ************************************/
    private void rotate(float x, float y, float z)
    {
        Quaternion quat = transform.rotation;
        quat.eulerAngles = new Vector3(x, y, z);
        transform.rotation = quat;
    }

    private void DecreaseSpeed()
    {
        rb.velocity = new Vector2(rb.velocity.x * (decreasePercentage / 100), rb.velocity.y * (decreasePercentage / 100));
    }


}
