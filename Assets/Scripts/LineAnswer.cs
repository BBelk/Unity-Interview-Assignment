using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineAnswer : MonoBehaviour
{
    
    public RectTransform lineAnchorObject;
    public GameObject answerObject;
    public LineRenderer myLineRenderer;
    public LineHandler myLineHandler;
    public RectTransform canvasRectTransform;
    // Start is called before the first frame update

    public Canvas canvas;

    void Start(){
        SetLineRendererStart();
    }

    void Update(){
        // SetLineRendererStart();
    }
    public void SetLineRendererStart(){
        var linePos = Camera.main.ScreenToWorldPoint(lineAnchorObject.transform.localPosition);
        myLineRenderer.SetPosition(0, Camera.main.ScreenToWorldPoint(new Vector3(linePos.x, linePos.y, 0f)));
        linePos = new Vector3(linePos.x + 500, linePos.y, linePos.z);
        myLineRenderer.SetPosition(1, (new Vector3(linePos.x, linePos.y, 0f)));
        myLineHandler.SetControlObjectPosition(linePos);

        
    }

    public void SetColor(Color newColor){
        myLineRenderer.startColor = newColor;
        myLineRenderer.endColor = newColor;
    }

    
}
