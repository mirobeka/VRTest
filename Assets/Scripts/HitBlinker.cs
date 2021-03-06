using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitBlinker : MonoBehaviour
{
    public int points = 0;
    public PointsManager pointsManager = null;
    public Color blinkColor;
    public UnityEvent onHit = null;

    private Renderer mesh = null;
    private Color normalColor;

    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        normalColor = mesh.material.GetColor("_Emission");
    }

    IEnumerator Flasher() 
    {
        for (int i = 0; i < 3; i++)
        {
            onHit.Invoke();
            mesh.material.SetColor("_Emission", blinkColor);
            yield return new WaitForSeconds(.1f);
            mesh.material.SetColor("_Emission", normalColor);
            yield return new WaitForSeconds(.1f);
        }
    }

    void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "Ball"){
            StartCoroutine(Flasher());
            pointsManager.AddPoint(points);
        }
    }
}
