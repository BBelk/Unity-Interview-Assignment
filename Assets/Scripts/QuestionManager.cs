using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.Networking;

public class QuestionManager : MonoBehaviour
{
    public List<LineObject> allLineObjects;
    public Transform leftSideTransform;
    public Transform rightSideTransform;
    public QuestionWrapper questionWrapper;
    public List<Color> allPossibleColors;
    public GameObject errorTextObject;
    public GameObject scoreDisplayObject;
    public GameObject scoreTextObject;
    public GameObject scoreSuperlativeObject;
    public Animation scoreDisplayAnimation;
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
        string filePath = Application.streamingAssetsPath + "/questions.json";
    #if UNITY_WEBGL && !UNITY_EDITOR
        StartCoroutine(LoadJSONFileWebGL(filePath));
    #else
        LoadJSONFile(filePath);
    #endif
    }

    void LoadJSONFile(string filePath)
    {
        if (File.Exists(filePath)){
            string dataAsJson = File.ReadAllText(filePath);
            QuestionWrapper questionWrapper = JsonUtility.FromJson<QuestionWrapper>(dataAsJson);
            GenerateLineObjects(questionWrapper.questions);
        }
        else{
            Debug.LogError("Failed to load JSON file: " + filePath);
        }
    }

    IEnumerator LoadJSONFileWebGL(string filePath)
    {
        UnityWebRequest www = UnityWebRequest.Get(filePath);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            string dataAsJson = www.downloadHandler.text;
            QuestionWrapper questionWrapper = JsonUtility.FromJson<QuestionWrapper>(dataAsJson);
            GenerateLineObjects(questionWrapper.questions);
        }
        else
        {
            Debug.LogError("Failed to load JSON file: " + www.error);
        }
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
        var orderInLayer = -999;
        for(int y = 0; y < questions.Length; y++){
            var getLO = allLineObjects[y];
            getLO.weight = questions[y].weight;
            getLO.LineAnswer.SetText(questions[y].expectedAnswer);
            getLO.LineAnswer.myLineRenderer.sortingOrder = orderInLayer += 1;
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

    public void CheckAnswersButton(){
        var totalPossible = 0;
        var totalDone = 0;
        foreach(LineObject newLO in allLineObjects){
            if(newLO.LineAnswer.selectedQuestion == null){
                StartCoroutine(ActivateErrorTextObject());
                return;
            }
            totalPossible += newLO.weight;
            if(newLO.LineAnswer.selectedQuestion == newLO.LineQuestion){
                totalDone += newLO.weight;
                newLO.correct = true;
            }
        }
        
        scoreTextObject.GetComponent<TMP_Text>().text = totalDone + "/" + totalPossible;
        if(totalDone == totalPossible){scoreSuperlativeObject.SetActive(false);}
        scoreDisplayObject.SetActive(true);
        scoreDisplayAnimation.Play("displayScoreAnim");
    }
    public IEnumerator ActivateErrorTextObject(){
        errorTextObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        errorTextObject.SetActive(false);
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
