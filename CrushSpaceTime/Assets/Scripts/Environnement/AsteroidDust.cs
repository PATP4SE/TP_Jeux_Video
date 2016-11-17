using UnityEngine;
using System.Collections;

public class AsteroidDust : MonoBehaviour {


    [SerializeField] private Transform parent = null;
    [SerializeField] private float pushStrenght = 0;
    [SerializeField] private float attractionRadius = 0;

    // Use this for initialization
    void Start ()
    {
        push();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector2.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) <= attractionRadius)
        //{
        //    Quaternion temp = transform.rotation;

        //    transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
        //    //transform.rotation = new Quaternion(-transform.rotation.x, -transform.rotation.y, transform.rotation.z, transform.rotation.w);
        //    GetComponent<Rigidbody2D>().AddForce(transform.forward * pushStrenght, ForceMode2D.Impulse);

        //    transform.rotation = temp;
        //}
    }

    private void push()
    {
        Quaternion temp = transform.rotation;

        transform.LookAt(parent.position);
        transform.rotation = new Quaternion(-transform.rotation.x, -transform.rotation.y, transform.rotation.z, transform.rotation.w);
        GetComponent<Rigidbody2D>().AddForce(transform.forward * pushStrenght, ForceMode2D.Impulse);

        transform.rotation = temp;
    }
   
}
