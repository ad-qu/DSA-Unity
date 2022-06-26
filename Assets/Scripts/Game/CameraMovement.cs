using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Target;
    private Vector3 TargetPos;
    public float Smoothing;
    public float CameraForward;

    private void Awake()
    {
        DontDestroyOnLoad(Target);
    }

    // Update is called once per frame
    void Update()
    {
        TargetPos = new Vector3(Target.transform.position.x, Target.transform.position.y, transform.position.z);

        if(Target.transform.localScale.x == 1) 
        {
            TargetPos = new Vector3(TargetPos.x + CameraForward, TargetPos.y + 2 , transform.position.z);
        }
        
        if(Target.transform.localScale.x == -1) 
        {
            TargetPos = new Vector3(TargetPos.x - CameraForward, TargetPos.y + 2, transform.position.z);
        }
        
        transform.position = Vector3.Lerp(transform.position, TargetPos, Smoothing*Time.deltaTime);
    }
}
