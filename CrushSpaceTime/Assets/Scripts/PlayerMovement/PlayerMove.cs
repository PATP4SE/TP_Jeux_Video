using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    [SerializeField] private float speed = 0;
    [SerializeField] private float decreasePercentage = 0;

    private SpriteRenderer sprite;
    private Rigidbody2D rbody;


    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 vect = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
            transform.LookAt(vect);
            rbody.AddForce(transform.forward * speed, ForceMode2D.Impulse);

            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 vect = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
            transform.LookAt(vect);
            rbody.AddForce(transform.forward * speed, ForceMode2D.Impulse);

            rotate(0, 0, 90);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 vect = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
            transform.LookAt(vect);
            rbody.AddForce(transform.forward * speed, ForceMode2D.Impulse);

            rotate(0, 0, 180);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 vect = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
            transform.LookAt(vect);
            rbody.AddForce(transform.forward * speed, ForceMode2D.Impulse);

            rotate(0, 0, -90);
        }
    }

    /************************************ PRIVATE METHODS ************************************/
    private void rotate(float x, float y, float z)
    {
        Quaternion quat = transform.rotation;
        quat.eulerAngles = new Vector3(x, y, z);
        transform.rotation = quat;
    }


}
