using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    [SerializeField] private float maxSpeed = 0;
    [SerializeField] private float minSpeed = 0;
    private Rigidbody2D rbody;

    void Start()
    {
        float speed = Random.Range(minSpeed, maxSpeed);
        rbody = GetComponent<Rigidbody2D>();
        rbody.velocity = new Vector2(0, speed);
    }
}
