using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    [SerializeField] private float speed;
    private SpriteRenderer sprite;
    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(0, speed, 0);
            sprite.flipY = false;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-speed, 0, 0);
            sprite.flipX = false;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(0, -speed, 0);
            sprite.flipY = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(speed, 0, 0);
            sprite.flipX = true;
        }
    }
}
