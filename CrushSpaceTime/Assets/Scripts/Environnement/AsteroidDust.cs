using UnityEngine;
using System.Collections;

public class AsteroidDust : MonoBehaviour
{


    [SerializeField]
    private Transform parent = null;
    [SerializeField]
    private float pushStrenght = 0;

    [SerializeField]
    private float attractionRadius = 0;

    private Rigidbody2D rbody;

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        push();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) <= attractionRadius)
        {
            rbody.velocity = new Vector2(0, 0);
            Quaternion temp = transform.rotation;

            transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
            rbody.AddForce(transform.forward * pushStrenght, ForceMode2D.Impulse);

            transform.rotation = temp;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            col.gameObject.GetComponent<Player>().AddDust();
        }
    }

    /*********************** PRIVATE METHODS **********************/
    private void push()
    {
        Quaternion temp = transform.rotation;

        transform.LookAt(parent.position);
        transform.rotation = new Quaternion(-transform.rotation.x, -transform.rotation.y, transform.rotation.z, transform.rotation.w);
        rbody.AddForce(transform.forward * pushStrenght, ForceMode2D.Impulse);

        transform.rotation = temp;
    }

}
