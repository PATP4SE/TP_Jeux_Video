using UnityEngine;
using System.Collections;

public class Wood : MonoBehaviour {

	public GameObject bridge;
    int isSelected;
    Vector2 vect;

	// Use this for initialization
	void Start () {
		bridge = GameObject.Find("Bridge");
		print (gameObject);
        isSelected = 0;
    }
	
    void OnMouseDown()
    {
        isSelected = 1;
    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonUp(0) && isSelected == 1)
        {
            isSelected = 2;
			print("You are building a bridge with your 3 woods");
        }

        if (Input.GetMouseButtonDown(0) && isSelected == 2)
        {
            vect = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			bridge.SetActive(true);
			gameObject.SetActive(false);
            bridge.transform.position = vect;
            isSelected = 0;
            print("You built a bridge with your 3 woods !");
        }

	}
}
