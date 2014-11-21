using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using QuestionStuff;

public class QuestionRenderer : MonoBehaviour {
    QuestionGenerator q = new QuestionGenerator();
    string questionString;
    List<float> answers = new List<float>();
    void Start()
    {
        GenerateNewQuestion();
    }
    public int EnemiesKilled
    {
        get;
        set;
    }
    public void GenerateNewQuestion()
    {

        questionString = q.QuestionBuilder(2);
        answers = q.AnswerGenerator(Random.Range(1, 4));
    }
    void OnGUI()
    {
        if (answers.Count > 0)
        {
            float width = Screen.width * 0.8f;
            GUI.BeginGroup(new Rect(Screen.width * 0.1f, 0, width, Screen.height * 0.5f));

            GUI.Box(new Rect(0, 0, width, Screen.height * 0.3f), questionString);
            GUI.Box(new Rect(0, Screen.height * 0.3f, width, Screen.height * 0.1f), "Enemies Killed : " + EnemiesKilled.ToString());
            for (int i = 0; i < answers.Count; i++)
            {
                if (GUI.Button(new Rect((int)(width * 0.1f) + i * ((width * 0.8f) / answers.Count), Screen.height * 0.1f, (width * 0.8f) / answers.Count, Screen.height * 0.15f), answers[i].ToString()))
                {

                    if (answers[i] == q.CorrectAnswer)
                    {
                        GameObject player = GameObject.FindGameObjectWithTag("Player");
                        answers.Clear();
                        player.GetComponent<PlayerFight>().PlayerAttack();
                    }
                }
            }

            GUI.EndGroup();
        }
    }
}
