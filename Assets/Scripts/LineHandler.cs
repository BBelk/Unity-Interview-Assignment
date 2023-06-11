using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public LineRenderer myLineRenderer;
    public GameObject controlObject;
    public Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myLineRenderer.SetPosition(2, Camera.main.ScreenToWorldPoint(controlObject.transform.position));
    }

    public void SetControlObjectPosition(Vector3 newPosWorldSpace){
        controlObject.transform.position = newPosWorldSpace;
        startPosition = newPosWorldSpace;
    }
}
