using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineAnswer : MonoBehaviour
{
    
    public GameObject lineAnchorObject;
    public GameObject answerObject;
    public LineRenderer myLineRenderer;
    public LineHandler myLineHandler;
    // Start is called before the first frame update
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
