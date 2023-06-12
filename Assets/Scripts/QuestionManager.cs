using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public List<LineObject> allLineObjects;
    public Transform leftSideTransform;
    public Transform rightSideTransform;
    public QuestionWrapper questionWrapper;
    public List<Color> allPossibleColors;

    private const string jsonFilePath = "Assets/Included/questions.json";

    public void SetLineQuestionsToStart(){
        foreach(LineObject newLQ in allLineObjects){
            // newLQ.
        }
    }

    public LineObject FindClosestEndObject(LineHandler currentLH){
        foreach(LineObject LO in allLineObjects){
            var distance = Vector3.Distance(new Vector3(currentLH.controlObject.transform.position.x, currentLH.controlObject.transform.position.y, 0f), new Vector3(LO.LineQuestion.lineEndObject.transform.position.x, LO.LineQuestion.lineEndObject.transform.position.y, 0f));
            if(distance < 1.1f){
                return LO;
            }
        }
        return null;
    }

    void Start(){
        string jsonText = System.IO.File.ReadAllText(jsonFilePath);
        questionWrapper = JsonUtility.FromJson<QuestionWrapper>(jsonText);
        var questions = questionWrapper.questions;
        Debug.Log("Questions: " + questionWrapper);
        GenerateLineObjects(questionWrapper.questions);
    }

    
    public void GenerateLineObjects(Question[] questions){
        for(int x = 0; x< questions.Length - 1; x++ ){
            var newLO = Instantiate(allLineObjects[0], this.transform);
            allLineObjects.Add(newLO);
            var newLA = Instantiate(allLineObjects[0].LineAnswer, leftSideTransform);
            var newLQ = Instantiate(allLineObjects[0].LineQuestion, rightSideTransform);
            newLO.LineAnswer = newLA;
            newLO.LineQuestion = newLQ;
        }
        for(int y = 0; y < questions.Length; y++){
            var getLO = allLineObjects[y];
            getLO.weight = questions[y].weight;
            getLO.LineAnswer.SetText(questions[y].expectedAnswer);
            getLO.LineQuestion.SetText(questions[y].text);
            getLO.LineAnswer.SetColor(allPossibleColors[y]);
        }
        RandomizeChildrenOrder(leftSideTransform);
        RandomizeChildrenOrder(rightSideTransform);
    }

    void RandomizeChildrenOrder(Transform parentTransform)
    {
        int childCount = parentTransform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            int randomIndex = Random.Range(i, childCount);
            parentTransform.GetChild(i).SetSiblingIndex(randomIndex);
        }
    }
}


[System.Serializable]
public class QuestionWrapper
{
    public Question[] questions;
}
[System.Serializable]
public class Question
{
    public int questionNumber;
    public string text;
    public string expectedAnswer;
    public int weight;
}
