using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AIMGUIManager : MonoBehaviour
{

    public static AIMGUIManager instance;

    private List<AIMGUIContainer> containers = new List<AIMGUIContainer>();


    [MenuItem("GameObject/UI/AIMGUI Manager")]
    public static void Init()
    {
        GameObject go = new GameObject("AIMGUI Manager");
        AIMGUIManager man = go.AddComponent<AIMGUIManager>();
        man.fontColour = Color.white;
        man.backgroundColour = Color.black;
    }

    [SerializeField] Color backgroundColour;
    [SerializeField] Color fontColour;


    [Header("Keybindings.")]
    [SerializeField] KeyCode hideKeycode = KeyCode.V;

    //Visibility switches.
    private bool showAIMGUI = true;


    private void Awake()
    {
        instance = this;
        if (hideKeycode == KeyCode.None) { Debug.LogWarning("AIMGUI: Hide key not assigned."); }
        if (backgroundColour.a == 0f) { Debug.LogWarning("AIMGUI: Background colour is set to be invisible."); }
        if (fontColour.a == 0f) { Debug.LogWarning("AIMGUI: Font colour is set to be invisible."); }
    } 
    


    public AIMGUIContainer CreateContainer(string _name)
    {
        AIMGUIContainer _r = new AIMGUIContainer(_name);
        containers.Add(_r);
        return _r;
    }

    public void RemoveContainer(AIMGUIContainer container)
    {
        if (containers.Remove(container) == false) { Debug.LogError("Error in removing container!"); }
    }


    private void Update()
    {
        if (Input.GetKeyDown(hideKeycode)) { showAIMGUI = !showAIMGUI; }
    }


    private void OnGUI()
    {

#if UNITY_EDITOR || DEVELOPMENT_BUILD

        GUI.backgroundColor = backgroundColour;
        GUI.contentColor = fontColour;

        if (showAIMGUI)
        {
            int x = 5, y = 5;
            int maxX = 0;

            foreach (AIMGUIContainer container in containers)
            {

                //Check if the containers are overflowing off the screen.
                if (container.height + y + 5 >= Screen.height)
                {
                    y = 5;
                    x += maxX + 5;
                    maxX = 0;
                }

                container.Draw(x, y);
                y += container.height + 5;


                if (container.width > maxX) { maxX = container.width; }
            }
        }

#endif
    }

}
