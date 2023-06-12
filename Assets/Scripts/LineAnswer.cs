using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LineAnswer : MonoBehaviour
{
    public RectTransform lineAnchorObject;
    public GameObject answerObject;
    public LineRenderer myLineRenderer;
    public LineHandler myLineHandler;
    public RectTransform canvasRectTransform;
    public LineQuestion selectedQuestion;

    public Canvas canvas;

    void Start(){
        SetLineRendererStart();
    }
    public void SetLineRendererStart(){
        var linePos = Camera.main.ScreenToWorldPoint(lineAnchorObject.transform.localPosition);
        myLineRenderer.SetPosition(0, Camera.main.ScreenToWorldPoint(new Vector3(linePos.x, linePos.y, 0f)));
        linePos = new Vector3(linePos.x + 100, linePos.y + UnityEngine.Random.Range(-7f, 7f), linePos.z);
        myLineRenderer.SetPosition(1, (new Vector3(linePos.x, linePos.y, 0f)));
        linePos = new Vector3(linePos.x + 25, linePos.y + UnityEngine.Random.Range(-7f, 7f), linePos.z);
        myLineHandler.SetControlObjectPosition(linePos);
    }
    public void SetColor(Color newColor){
        myLineRenderer.startColor = newColor;
        myLineRenderer.endColor = newColor;
    }
    public void SetText(string newText){
        answerObject.GetComponent<TMP_Text>().text = newText;
    }
}
