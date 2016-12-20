using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public GameObject menuCanvas;
    public GameObject optionsCanvas;
    public InputField upInput;
    public InputField leftInput;
    public InputField downInput;
    public InputField rightInput;
    public InputField repulseInput;

    private bool isOptionPanelActive;
    private string up;
    private string left;
    private string down;
    private string right;
    private string repulse;


    public void Start()
    {
        menuCanvas.SetActive(true);
        optionsCanvas.SetActive(false);
        isOptionPanelActive = false;

        setAllCommands();
    }

    void Update()
    {
        if (isOptionPanelActive)
        {
            InputField focusedIF = null;
            if (upInput.isFocused) focusedIF = upInput;
            else if (leftInput.isFocused) focusedIF = leftInput;
            else if (downInput.isFocused) focusedIF = downInput;
            else if (rightInput.isFocused) focusedIF = rightInput;
            else if (repulseInput.isFocused) focusedIF = repulseInput;

            if (focusedIF != null)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    focusedIF.text = "Fleche Haut";
                    up = "UpArrow";
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    focusedIF.text = "Fleche Gauche";
                    left = "LeftArrow";
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    focusedIF.text = "Fleche Bas";
                    down = "DownArrow";
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    focusedIF.text = "Fleche Droite";
                    right = "RightArrow";
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    focusedIF.text = "Espace";
                    repulse = "Space";
                }
                else if (focusedIF.text.Length >= 2 && !focusedIF.text.Contains("Espace") && !focusedIF.text.Contains("Fleche"))
                {
                    focusedIF.text = focusedIF.text.Substring(focusedIF.text.Length-1);
                }
            }
        }
    }

    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void OnClickOptions()
    {
        menuCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
        isOptionPanelActive = true;
    }

    public void OnClickCancel()
    {
        setAllCommands();
        menuCanvas.SetActive(true);
        optionsCanvas.SetActive(false);
        isOptionPanelActive = false;
    }

    public void OnClickSave()
    {
        menuCanvas.SetActive(true);
        optionsCanvas.SetActive(false);

        if (up == null) up = upInput.text.ToUpper();
        if (left == null) left = leftInput.text.ToUpper();
        if (down == null) down = downInput.text.ToUpper();
        if (right == null) right = rightInput.text.ToUpper();
        if (repulse == null) repulse = repulseInput.text.ToUpper();

        PlayerPrefs.SetString("UpPref", up);
        PlayerPrefs.SetString("LeftPref", left);
        PlayerPrefs.SetString("DownPref", down);
        PlayerPrefs.SetString("RightPref", right);
        PlayerPrefs.SetString("RepulsePref", repulse);
    }

    private void setAllCommands()
    {
        if (!PlayerPrefs.HasKey("UpPref")) PlayerPrefs.SetString("UpPref", "W");
        if (!PlayerPrefs.HasKey("LeftPref")) PlayerPrefs.SetString("LeftPref", "A");
        if (!PlayerPrefs.HasKey("DownPref")) PlayerPrefs.SetString("DownPref", "S");
        if (!PlayerPrefs.HasKey("RightPref")) PlayerPrefs.SetString("RightPref", "D");
        if (!PlayerPrefs.HasKey("RepulsePref")) PlayerPrefs.SetString("RepulsePref", "Space");

        upInput.text = PlayerPrefs.GetString("UpPref");
        leftInput.text = PlayerPrefs.GetString("LeftPref");
        downInput.text = PlayerPrefs.GetString("DownPref");
        rightInput.text = PlayerPrefs.GetString("RightPref");
        repulseInput.text = PlayerPrefs.GetString("RepulsePref");

        if (upInput.text.Contains("Up")) upInput.text = "Fleche Haut";
        if (leftInput.text.Contains("Left")) leftInput.text = "Fleche Gauche";
        if (downInput.text.Contains("Down")) downInput.text = "Fleche Bas";
        if (rightInput.text.Contains("Right")) rightInput.text = "Fleche Droite";
        if (repulseInput.text.Contains("Space")) repulseInput.text = "Espace";
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
}
