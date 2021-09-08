using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public float resolution = 0.5f;
    public TrajectoryManager trajectoryManager = null;

    private Vector3 previousPos = Vector3.zero;
    private Vector3[] positions = new Vector3[1024];
    private int currentIdx = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindWithTag("TrajectoryManager");
        trajectoryManager = go.GetComponent<TrajectoryManager>();

        trajectoryManager.AddTrajectory(this);
        previousPos = transform.position;
    }

    private void SavePosition(){
        // neukladaj viacej ako znesies
        if (currentIdx == positions.Length){
            return;
        }

        positions[currentIdx] = transform.position;
        currentIdx += 1;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(previousPos, transform.position);
        if (distance >= resolution){
            SavePosition();
        }
    }

    public int GetCount(){
        return currentIdx;
    }

    public Vector3[] GetPositions(){
        Vector3[] pos = new Vector3[currentIdx+1];
        for (int i=0; i < currentIdx; i += 1){
            pos[i] = positions[i];
        }
        return pos;
    }


    void OnDestroy(){
        if (trajectoryManager != null)
            trajectoryManager.RemoveTrajectory(this);
    }
}
