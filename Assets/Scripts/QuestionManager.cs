using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public List<LineObject> allLineObjects;
    public Transform leftSideTransform;
    public Transform rightSideTransform;
    public QuestionWrapper questionWrapper;
    public Question[] questions;

    private const string jsonFilePath = "Assets/Included/questions.json";

    void Start()
    {
        // Read the JSON file
        string jsonText = System.IO.File.ReadAllText(jsonFilePath);
        Debug.Log("JSONTEXT " + jsonText);

        // Parse the JSON data
        questionWrapper = JsonUtility.FromJson<QuestionWrapper>(jsonText);

        // Access and display the parsed data
        questions = questionWrapper.questions;
        Debug.Log("ALL QUESTIONS" + questions.Length);
    }

    // Rest of your code...
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
