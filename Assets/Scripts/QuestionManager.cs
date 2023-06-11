using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{

    public List<LineQuestion> allLineQuestions;
    public Transform leftSideTransform;
    public Transform rightSideTransform;

    void Start(){
        //get from json
    }

    public void SetLineQuestionsToStart(){
        foreach(LineQuestion newLQ in allLineQuestions){
            // newLQ.
        }
    }

}
