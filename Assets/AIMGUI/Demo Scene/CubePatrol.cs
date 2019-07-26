using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePatrol : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    [SerializeField] float stopRadius;
    [SerializeField] float waitTime;
    [SerializeField] Transform[] waypoints;
    
    private int currentWaypointIndex;
    private bool isWaiting = false;
    private float startedWaitingTime = 0f;


    //All the variables needed for AIMGUI.
    AIMGUIContainer AIMGUI;
    enum AIMGUI_IDS { CURRENT_WAYPOINT, IS_WAITING }

    // Start is called before the first frame update
    void Start()
    {
        //Initialise an AIMGUI container.
        InitAIMGUI();

        currentWaypointIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Don't move if the cube is waiting.
        isWaiting = startedWaitingTime + waitTime > Time.time;
        if (isWaiting) { return; }

        if ( ! MoveTo(waypoints[currentWaypointIndex]))
        {
            //Move on to next waypoint.
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }

            //Mark start of waiting.
            startedWaitingTime = Time.time;

        }

    }

    private void LateUpdate() 
    {
        //Update fields.
        AIMGUI.UpdateVal( (int) AIMGUI_IDS.IS_WAITING, isWaiting);
        AIMGUI.UpdateVal( (int) AIMGUI_IDS.CURRENT_WAYPOINT, waypoints[currentWaypointIndex] );        
    }

    private bool MoveTo(Transform _pos)
    {
        Vector3 dir = (_pos.position - transform.position);
        float dist = dir.sqrMagnitude;
        if (dist <= stopRadius * stopRadius)
        {
            return false;
        }
        else
        {
            transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
            return true;
        }
    }


    //Set up AIMGUI container and fields.
    private void InitAIMGUI()
    {
        //Create a container caleld 'Patrolling Cube'.
        AIMGUI = AIMGUIManager.instance.CreateContainer("Patrolling Cube");
        //Create a field called 'Current Waypoint'.
        AIMGUI.Add( (int) AIMGUI_IDS.CURRENT_WAYPOINT, "Current Waypoint");
        //Create a field called 'Is Waiting?'.
        AIMGUI.Add( (int) AIMGUI_IDS.IS_WAITING, "Is Waiting?" );
    }
}
