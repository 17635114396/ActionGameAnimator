using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{

    [SerializeField] float maxHeight = 4f;
    [SerializeField] float moveSpeed = 1f;

    private float currentHeight;
    private float offset;

    //AIMGUI.
    private AIMGUIContainer AIMGUI;
    private enum AIMGUI_IDS { POS, MOVE_SPEED, VECT3_POS }


    // Start is called before the first frame update
    void Start()
    {
        InitAIMGUI();
        offset = transform.position.y;
        AIMGUI.UpdateVal((int) AIMGUI_IDS.MOVE_SPEED, moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        currentHeight = offset + Mathf.PingPong(Time.time, maxHeight);
        transform.position = Vector3.up * currentHeight;
        AIMGUI.UpdateVal((int) AIMGUI_IDS.POS, currentHeight);
        AIMGUI.UpdateVal( (int) AIMGUI_IDS.VECT3_POS, transform.position);
    }

    //Set up AIMGUI container and fields.
    void InitAIMGUI()
    {
        //Create a container caleld 'Moving Cube'.
        AIMGUI = AIMGUIManager.instance.CreateContainer("Moving Cube");

        /*
        I use an ENUM to track IDs for fields becuase it's readable.
        You can track IDs however you want.   
        */

        //Create fields, assigning IDs and names.
        AIMGUI.Add( (int) AIMGUI_IDS.MOVE_SPEED, "Move Speed");
        AIMGUI.Add( (int) AIMGUI_IDS.POS, "Current Height");
        AIMGUI.Add( (int) AIMGUI_IDS.VECT3_POS, "Position");
    }
}
