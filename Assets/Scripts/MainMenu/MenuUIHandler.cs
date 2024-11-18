using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Necessary to manage what concerns UI components
using UnityEngine.UI;


//Necessary to invoke methods for scene changing etc.
using UnityEngine.SceneManagement;

//Helps managing methods while executing them in the Editor.
#if UNITY_EDITOR
using UnityEditor;
#endif


// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    //Host the player name input field
    public InputField playerNameInputField;
    


    // Start is called before the first frame update
    void Start()
    {
        // Add listener for onEndEdit. The onEndEdit returns a string by default.
        playerNameInputField.onEndEdit.AddListener(HandlePNInput);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandlePNInput(string playerName)
    {
        PlayerDataHandler.Instance.SetPlayerName(playerName);
    }
    
    

    public void StartGame()
    {
        
        SceneManager.LoadScene(1);
       
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit(); // original code to quit Unity player
#endif
    }

}
