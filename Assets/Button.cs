using UnityEngine;
using UnityEngine.UI; // For UI components
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public Button myButton;

    void Start()
    {
        // Make sure the button is assigned in the Inspector
        if (myButton != null)
        {
            //myButton.onClick.AddListener(OnButtonClick);
        }
    }

    public void OnButtonClick()
    {
        Debug.Log("Button was clicked!");
        SceneManager.LoadScene("start");

    }
}
