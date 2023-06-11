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
    private bool followMouse;
    void Update(){
        if(followMouse){
            Vector3 mousePosition = Input.mousePosition;

            // Convert the mouse position to world coordinates
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // Set the position of the RectTransform to follow the mouse
            this.transform.position = worldPosition;
        }
        myLineRenderer.SetPosition(2, (controlObject.transform.localPosition));
    }

    public void SetControlObjectPosition(Vector3 newPosWorldSpace){
        controlObject.transform.localPosition = (newPosWorldSpace);
        startPosition = newPosWorldSpace;
    }

     public void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData){
        Debug.Log("DOWN");
        followMouse = true;
     }
     public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("UP");
        followMouse = false;
        var endPoint = QuestionManager.FindClosestEndObject(this);
        if(endPoint == null){StartCoroutine(ReelIn());return;}
        else{
            controlObject.transform.position = endPoint.LineQuestion.lineEndObject.transform.position;
        }
     }

    float reelTime = 1f;
     public IEnumerator ReelIn(){
        var elapsedTime = 0f;
        while (elapsedTime < reelTime)
        {
            // Calculate the current position based on the elapsed time and reelTime
            float t = elapsedTime / reelTime;
            Vector3 currentPosition = Vector3.Lerp(controlObject.transform.localPosition, startPosition, t);

            // Move the transform's position
            controlObject.transform.localPosition = currentPosition;

            // Increase the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Ensure the transform's position is exactly the start position when done
        controlObject.transform.localPosition = startPosition;
     }
}
