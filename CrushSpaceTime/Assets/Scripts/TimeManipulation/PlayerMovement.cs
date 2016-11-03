/**
*Created by William-José Simard-Touzet
**/

using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rbody;
    Animator animator;
    GUIText multiplicator;

    [SerializeField] private float speed;
    [SerializeField] private bool isTimeAlteration;
    private int ctrlSpaceCount;
    private int shiftSpaceCount;
    private float speedMultiplicator;

    void Start()
    {
        speed = 0.1f;
        ctrlSpaceCount = 0;
        shiftSpaceCount = 0;
        speedMultiplicator = 1;
        isTimeAlteration = false;

        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnGUI()
    {
        string str = "x" + speedMultiplicator.ToString();
        if (isTimeAlteration)
        {
            Vector2 pos = new Vector2(-19, -9);
            var point = Camera.main.WorldToScreenPoint(pos);
            GUI.Label(new Rect(point.x, point.y, 200, 200), str);

            //GUI.Label(new Rect(transform.position.x+2, transform.position.y + 2, 20, 20), "hello");
        }
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.T)) {
            isTimeAlteration = !isTimeAlteration;
        }

        if (isTimeAlteration) {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ctrlSpaceCount++;
                    speedMultiplicator *= 2;
                }
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    shiftSpaceCount++;
                    speedMultiplicator *= 0.5f;
                }
            }
        } else {
            speedMultiplicator = 1;
            ctrlSpaceCount = 0;
            shiftSpaceCount = 0;
        }
       
        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (movement_vector != Vector2.zero) {
            animator.SetBool("isWalking", true);
            animator.SetFloat("input_x", movement_vector.x);
            animator.SetFloat("input_y", movement_vector.y);
        }
        else {
            animator.SetBool("isWalking", false);
        }

        if (ctrlSpaceCount > 3) {
            speedMultiplicator = 1;
            ctrlSpaceCount = 0;
        }

        if (shiftSpaceCount > 3) {
            speedMultiplicator = 1;
            shiftSpaceCount = 0;
        }

        if (!isTimeAlteration) rbody.MovePosition(rbody.position + movement_vector * speed);
        else rbody.MovePosition(rbody.position + movement_vector * speed * speedMultiplicator);
        
    }
}
