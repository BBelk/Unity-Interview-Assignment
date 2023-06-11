using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public List<LineObject> allLineObjects;
    public Transform leftSideTransform;
    public Transform rightSideTransform;
    public QuestionWrapper questionWrapper;

    private const string jsonFilePath = "Assets/Included/questions.json";

    public void SetLineQuestionsToStart(){
        foreach(LineObject newLQ in allLineObjects){
            // newLQ.
        }
    }

    public LineObject FindClosestEndObject(LineHandler currentLH){
        foreach(LineObject LO in allLineObjects){
            
            var distance = Vector3.Distance(new Vector3(currentLH.controlObject.transform.position.x, currentLH.controlObject.transform.position.y, 0f), new Vector3(LO.LineQuestion.lineEndObject.transform.position.x, LO.LineQuestion.lineEndObject.transform.position.y, 0f));
            Debug.Log("DISTANCE: " + distance);
            if(distance < 1.1f){
                return LO;
            }
        }
        return null;
    }

    void Start()
    {
        // Read the JSON file
        string jsonText = System.IO.File.ReadAllText(jsonFilePath);
        Debug.Log("JSONTEXT " + jsonText);

        // Parse the JSON data
        questionWrapper = JsonUtility.FromJson<QuestionWrapper>(jsonText);

        // Access and display the parsed data
        var questions = questionWrapper.questions;
        Debug.Log("ALL QUESTIONS" + questions.Length);
    }
}

public class QuestionWrapper
{
    public Question[] questions;
}
public class Question
{
    public int questionNumber;
    public string text;
    public string expectedAnswer;
    public int weight;
}
