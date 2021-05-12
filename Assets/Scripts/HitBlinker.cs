using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBlinker : MonoBehaviour
{
    public Color blinkColor;

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
            mesh.material.SetColor("_Emission", blinkColor);
            yield return new WaitForSeconds(.1f);
            mesh.material.SetColor("_Emission", normalColor);
            yield return new WaitForSeconds(.1f);
        }
    }

    void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "Ball"){
            StartCoroutine(Flasher());
        }

    }
}
