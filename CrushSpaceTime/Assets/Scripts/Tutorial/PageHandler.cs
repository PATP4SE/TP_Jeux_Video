using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PageHandler : MonoBehaviour {

    private Vector2 resolution;
    private int imageNumber;
    [SerializeField] private int maxImageNumber;

    // Use this for initialization
    void Start ()
    {
        imageNumber = 0;
        resolution = new Vector2(Screen.width, Screen.height);
        AdjustImageSize();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Next()
    {
        if (imageNumber != maxImageNumber)
        {
            GameObject.Find("Image" + imageNumber).GetComponent<Image>().enabled = false;
            imageNumber++;
            GameObject.Find("Image" + imageNumber).GetComponent<Image>().enabled = true;

            AdjustImageSize();
            updateTextButtons();
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    public void Previous()
    {
        if (imageNumber != 0)
        {
            GameObject.Find("Image" + imageNumber).GetComponent<Image>().enabled = false;
            imageNumber--;
            GameObject.Find("Image" + imageNumber).GetComponent<Image>().enabled = true;

            AdjustImageSize();
            updateTextButtons();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    private void AdjustImageSize()
    {
        GameObject.Find("Image" + imageNumber).GetComponent<RectTransform>().sizeDelta = resolution;
    }

    private void updateTextButtons()
    {
        if (imageNumber == maxImageNumber)
            GameObject.Find("NextText").GetComponent<Text>().text = "JOUER";
        else if (imageNumber == 0)
            GameObject.Find("PreviousText").GetComponent<Text>().text = "RETOUR";
        else
        {
            GameObject.Find("NextText").GetComponent<Text>().text = "SUIVANT";
            GameObject.Find("PreviousText").GetComponent<Text>().text = "PRÉCÉDENT";
        }
    }


}
