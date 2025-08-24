using UnityEngine;
using UnityEngine.UI; // For UI components
using UnityEngine.SceneManagement;

public class button_script : MonoBehaviour
{
   


    

    public void OnButtonClick(int sceneindex)
    {
        Debug.Log("Button was clicked!");
        SceneManager.LoadScene(sceneindex);
        
    }
}
