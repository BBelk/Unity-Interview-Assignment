using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
      private LineRenderer line;
    private Vector3 mousePos;
    public Material material;
    private int currLines = 0;

    public GameObject startLineObject;

    public List<LineHandler> allLineHandlers;

    void Start()
    {
        // var worldPos = startLineObject.transform.position;
        var worldPos = Camera.main.ScreenToWorldPoint(startLineObject.transform.position);
        Debug.Log("World Pos: " + worldPos);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            line.SetPosition(0, mousePos);
    }


}
