using UnityEngine;
using System.Collections;

public class AsteroidDust : MonoBehaviour {


    [SerializeField] private Transform parent;
    [SerializeField] private float pushStrenght;

    private Rigidbody2D rbody;

    // Use this for initialization
    void Start ()
    {
        rbody = GetComponent<Rigidbody2D>();
        Push();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!((rbody.velocity.x <= 0.0001 && rbody.velocity.x >= -0.0001) && (rbody.velocity.y <= 0.0001 && rbody.velocity.y >= -0.0001)))
        {
            DecreaseSpeed();
        }
    }
    
    private void Push()
    {
        Vector2 vect = parent.position;

        Quaternion temp = transform.rotation;

        transform.LookAt(vect);
        transform.rotation = new Quaternion(-transform.rotation.x, -transform.rotation.y, transform.rotation.z, transform.rotation.w);
        GetComponent<Rigidbody2D>().AddForce(transform.forward * pushStrenght, ForceMode2D.Impulse);

        transform.rotation = temp;
    }

    private void DecreaseSpeed()
    {
        rbody.velocity = new Vector2(rbody.velocity.x * (99 / 100), rbody.velocity.y * (99 / 100));
    }
}
