using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public QuestionManager QuestionManager;
    public LineQuestion myLineQuestion;
    public LineRenderer myLineRenderer;
    public GameObject controlObject;
    public Vector3 startPosition;
    void Update(){
        myLineRenderer.SetPosition(2, (controlObject.transform.localPosition));
    }

    public void SetControlObjectPosition(Vector3 newPosWorldSpace){
        controlObject.transform.localPosition = (newPosWorldSpace);
        startPosition = newPosWorldSpace;
    }

     public void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData){
        Debug.Log("DOWN");
     }
     public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("UP");
     }
}
