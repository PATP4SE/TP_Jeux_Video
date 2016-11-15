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
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Translate(0, speed, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Translate(-speed, 0, 0);

            rotate(0, 0, 90);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Translate(0, -speed, 0);

            rotate(0, 0, 180);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Translate(speed, 0, 0);

            rotate(0, 0, -90);
        }

        if (!((rb.velocity.x <= 0.0001 && rb.velocity.x >= -0.0001) && (rb.velocity.y <= 0.0001 && rb.velocity.y >= -0.0001)))
        {
            print("asdasdasd");
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
