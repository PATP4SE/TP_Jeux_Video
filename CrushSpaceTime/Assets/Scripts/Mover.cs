using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    [SerializeField] private float maxSpeed = 0;
    [SerializeField] private float minSpeed = 0;
    private Rigidbody2D rbody;
    private float speed;
    private float timeAlteration;

    public bool repusled = false;

    void Start()
    {
        timeAlteration = 0;
        speed = Random.Range(minSpeed, maxSpeed);
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!repusled) rbody.velocity = new Vector2(0, speed * timeAlteration);
    }

    public float getTimeAlteration()
    {
        return timeAlteration;
    }

    public void setTimeAlteration(float pTimeAlteration)
    {
        timeAlteration = pTimeAlteration;
    }
}
