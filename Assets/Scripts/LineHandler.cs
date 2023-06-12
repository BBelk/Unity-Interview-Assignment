using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public QuestionManager QuestionManager;
    public LineAnswer myLineAnswer;
    public LineRenderer myLineRenderer;
    public GameObject controlObject;
    public Vector3 startPosition;
    private bool followMouse;
    void Update(){
        if(followMouse){
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            this.transform.position = worldPosition;
        }
        myLineRenderer.SetPosition(2, (controlObject.transform.localPosition));
    }

    public void SetControlObjectPosition(Vector3 newPosWorldSpace){
        controlObject.transform.localPosition = (newPosWorldSpace);
        startPosition = newPosWorldSpace;
    }

     public void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData){
        followMouse = true;
        var endPoint = QuestionManager.FindClosestEndObject(this);
        if(endPoint != null){
            endPoint.LineQuestion.SetLineHandler(null);
        }
     }
     public void OnPointerUp(PointerEventData eventData) {
        followMouse = false;
        var endPoint = QuestionManager.FindClosestEndObject(this);
        if(endPoint == null){ReelInFunc();return;}
        else{
            controlObject.transform.position = endPoint.LineQuestion.lineEndObject.transform.position;
            endPoint.LineQuestion.SetLineHandler(this);
            myLineAnswer.selectedQuestion = endPoint.LineQuestion;
        }
     }

     public void ReelInFunc(){
        StartCoroutine(ReelIn());
     }

    float reelTime = 1f;
     public IEnumerator ReelIn(){
        var elapsedTime = 0f;
        while (elapsedTime < reelTime){
            float t = elapsedTime / reelTime;
            Vector3 currentPosition = Vector3.Lerp(controlObject.transform.localPosition, startPosition, t);
            controlObject.transform.localPosition = currentPosition;
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        controlObject.transform.localPosition = startPosition;
     }
}
