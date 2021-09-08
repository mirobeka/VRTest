using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryManager : MonoBehaviour
{

    public GameObject linePrefab = null;
    private List<GameObject> lines = new List<GameObject>();
    private List<Trajectory> trajectories = new List<Trajectory>();

    public void DisplayTrajectoriesDelayed(float delay){
            StartCoroutine( DelayedDisplay(delay) );
    }

    private IEnumerator DelayedDisplay(float delay){
        yield return new WaitForSeconds(delay);
        DisplayTrajectories();
    }

    public void DisplayTrajectories(){
        RemoveExistingLines();

        foreach (Trajectory t in trajectories){
            GameObject go = Instantiate(linePrefab);
            lines.Add(go);
            LineRenderer lr = go.GetComponent<LineRenderer>();
            lr.loop = false;
            lr.positionCount = t.GetCount();
            lr.SetPositions(t.GetPositions());
        }

        trajectories.Clear();
    }

    public void RemoveExistingLines(){
        // vymaz nakreslene ciary
        foreach (GameObject go in lines){
            Destroy(go);
        }
    }

    public void AddTrajectory(Trajectory trajectory){
        trajectories.Add(trajectory);
    }

    public void RemoveTrajectory(Trajectory trajectory){
        trajectories.Remove(trajectory);
    }
}
