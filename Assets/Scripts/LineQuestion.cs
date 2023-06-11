using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LineQuestion : MonoBehaviour
{
    public GameObject answerObject;
    public GameObject questionObject;
    public GameObject lineAnchorObject;
    public GameObject lineEndObject;
    public LineRenderer myLineRenderer;

    public LineHandler myLineHandler;

    public void SetLineRendererStart(){
        var linePos = lineAnchorObject.transform.position;
        myLineRenderer.SetPosition(0, linePos);
        linePos = new Vector3(linePos.x + 5, linePos.y, linePos.z);
        myLineRenderer.SetPosition(1, linePos);
        myLineHandler.SetControlObjectPosition(linePos);
    }

    public void SetColor(Color newColor){
        myLineRenderer.startColor = newColor;
        myLineRenderer.endColor = newColor;
    }
}
