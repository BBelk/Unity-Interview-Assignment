using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LineQuestion : MonoBehaviour
{    
    public GameObject lineEndObject;
    public GameObject questionObject;
    public LineHandler currentLineHandler;
    public void SetLineHandler(LineHandler newLH){
        if(newLH == null){currentLineHandler = null;return;}
        if(currentLineHandler != null && currentLineHandler != newLH){currentLineHandler.ReelInFunc();}
        currentLineHandler = newLH;
    }
    public void SetText(string newText){
        questionObject.GetComponent<TMP_Text>().text = newText;
    }
    
}
