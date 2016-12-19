using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public GameObject spaceShip;
    private Camera camera;
    private float cameraHeight;
    private float cameraWidth;
    private Boundary boundary;
    private GameController gameControllerScript;

    //[SerializeField] private float speed = 0;

    // Use this for initialization
    void Start () {
        camera = Camera.main;
        cameraHeight = 2f * camera.orthographicSize;
        cameraWidth = cameraHeight * camera.aspect;
        boundary = player.GetComponent<PlayerMove>().getBoundary();
        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (gameControllerScript.GetIsInSpaceShip())
        {
            transform.position = new Vector3
            (
                Mathf.Clamp(spaceShip.transform.position.x, boundary.xMin + cameraWidth * 0.5f, boundary.xMax - cameraWidth * 0.5f),
                Mathf.Clamp(spaceShip.transform.position.y, boundary.yMin + cameraHeight * 0.5f, boundary.yMax - cameraHeight * 0.5f),
                -5.0f
            );

        } else
        {
            transform.position = new Vector3
            (
                Mathf.Clamp(player.transform.position.x, boundary.xMin - player.transform.localScale.x + cameraWidth * 0.5f, boundary.xMax + player.transform.localScale.x - cameraWidth * 0.5f),
                Mathf.Clamp(player.transform.position.y, boundary.yMin - player.transform.localScale.y + cameraHeight * 0.5f, boundary.yMax + player.transform.localScale.y - cameraHeight * 0.5f),
                -5.0f
            );
        }
    }
}
