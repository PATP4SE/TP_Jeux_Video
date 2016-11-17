using UnityEngine;
using System.Collections;

public class SpaceGravity : MonoBehaviour
{

    [SerializeField] private float decreasePercentage = 0;
    private Rigidbody2D rbody;
    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rbody != null)
        {
            if (!((rbody.velocity.x <= 0.0001 && rbody.velocity.x >= -0.0001) && (rbody.velocity.y <= 0.0001 && rbody.velocity.y >= -0.0001)))
            {
                float percent = (100f - decreasePercentage);
                rbody.velocity = new Vector2(rbody.velocity.x * (percent / 100f), rbody.velocity.y * (percent / 100f));
            }
        }
    }
}
