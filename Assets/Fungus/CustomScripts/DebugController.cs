using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour
{
    [SerializeField]GameObject DebugCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ToggleDebugMenu();
    }

    public void ToggleDebugMenu()//Toggle the debug canvas with Shift + D
    {
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.D))
        {
            DebugCanvas.SetActive(!DebugCanvas.activeSelf);
            Time.timeScale = DebugCanvas.activeSelf ? 0 : 1;//Pause/play the game when debug canvas is toggled
        }
    }

    public void CloseDebugMenu()//Deactivate the debug canvas
    {
        DebugCanvas.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
