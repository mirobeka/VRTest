using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PointsManager : MonoBehaviour
{
    public TextMesh pointsLabel = null;
    private int points = 0;

    void Awake()
    {
        GameObject go = GameObject.Find("Points/Number");
        pointsLabel = go.GetComponent<TextMesh>();
    }

    public void ResetPoinst()
    {
        points = 0;
        UpdateText();
    }

    public void AddPoint(int p)
    {
        points += p;
        UpdateText();
    }

    void UpdateText()
    {
        pointsLabel.text = String.Format("{0}", points);
    }
}
