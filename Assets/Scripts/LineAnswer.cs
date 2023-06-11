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

    public Canvas canvas;

    void Start(){
        SetLineRendererStart();
    }
    public void SetLineRendererStart(){
        Vector2 movePos;
         RectTransformUtility.ScreenPointToLocalPointInRectangle(
                     canvas.transform as RectTransform,
                    //  Input.mousePosition, 
                    Camera.main.WorldToScreenPoint(lineAnchorObject.transform.position),
                     canvas.worldCamera,
                     out movePos);
        //  _lineRenderer.SetPosition(0, transform.position);
         myLineRenderer.SetPosition(0,
              canvas.transform.TransformPoint(movePos));


        // var linePos = Camera.main.ScreenToWorldPoint(lineAnchorObject.transform.position);
        var linePos = Camera.main.ScreenToWorldPoint(lineAnchorObject.transform.position);
        // myLineRenderer.SetPosition(0, linePos);?
        linePos = new Vector3(linePos.x + 5, linePos.y, linePos.z);
        myLineRenderer.SetPosition(1, linePos);
        myLineHandler.SetControlObjectPosition(linePos);
    }

    public void SetColor(Color newColor){
        myLineRenderer.startColor = newColor;
        myLineRenderer.endColor = newColor;
    }

    
}
