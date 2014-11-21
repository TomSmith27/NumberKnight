using UnityEngine;
using System.Collections;
using Assets.Scripts.WebServices;
using System.Collections.Generic;

[ExecuteInEditMode]
public class GameOverScreen : MonoBehaviour
{

	Vector2 _slightPadding = new Vector2(Screen.width * 0.025f,Screen.height * 0.05f); 
	Rect _area, leftArea, middleArea; 
	float timer = 0f;
	bool submittedTimer = false;
    ScoresService s;
	// Use this for initialization
	new void Start () {
		
	}
	new void OnGUI() 	
	{ 
		timer += Time.deltaTime;
		
	//	base.OnGUI ();
		_area = new Rect(0,0 , Screen.width, Screen.height); 
		leftArea = new Rect(_slightPadding.x,_slightPadding.y,_area.width * 0.3f,_area.height);
		GUI.Box(_area,"");
		middleArea = new Rect(_area.width*0.32f + _slightPadding.x,_slightPadding.y,_area.width * 0.63f,_area.height);
		GUI.BeginGroup(_area); 	
		GUI.BeginGroup(leftArea);
		GUI.Box(new Rect(0,0,leftArea.width,leftArea.height*0.9f),"Stats"); 
		CreateStats (leftArea);
		
		GUI.EndGroup(); 		GUI.BeginGroup(middleArea);
		GUI.Box(new Rect(0,0,middleArea.width,middleArea.height*0.9f),"Leaderboards"); 	
		GUI.Button(new Rect(_slightPadding.x,_slightPadding.y +  middleArea.height * 0.05f,middleArea.width * 0.3f, middleArea.height * 0.1f),"Top Players"); 
		GUI.Button(new Rect(_slightPadding.x + (middleArea.width*0.3f),_slightPadding.y +  middleArea.height * 0.05f,middleArea.width * 0.3f, middleArea.height * 0.1f),"Your Rank"); 
		GUI.Button(new Rect(_slightPadding.x + (middleArea.width*0.6f),_slightPadding.y +  middleArea.height * 0.05f,middleArea.width * 0.3f, middleArea.height * 0.1f),"Friends"); 	
		GUI.EndGroup(); 
		GUI.EndGroup(); 
	}
	void CreateStats(Rect _area)
	{
		GUI.Label (new Rect (0, _area.height * 0.1f, _area.width*0.5f, _area.height * 0.1f), "Score : ");
		GUI.Label (new Rect (_area.width*0.6f, _area.height * 0.1f, _area.width*0.5f, _area.height * 0.1f), PlayerPrefs.GetInt("score").ToString());
        GUI.Label(new Rect(0, _area.height * 0.2f, _area.width * 0.5f, _area.height * 0.1f), "Correct Answers : ");
        GUI.Label(new Rect(_area.width * 0.6f, _area.height * 0.2f, _area.width * 0.5f, _area.height * 0.1f), PlayerPrefs.GetInt("correctAnswers").ToString());
        GUI.Label(new Rect(0, _area.height * 0.3f, _area.width * 0.5f, _area.height * 0.1f), "Incorrect Answers : ");
        GUI.Label(new Rect(_area.width * 0.6f, _area.height * 0.3f, _area.width * 0.5f, _area.height * 0.1f), PlayerPrefs.GetInt("incorrectAnswers").ToString());
	}
    void RenderHighScores(Rect _area)
    {
        List<ScoresModel> scores = s.GetScores(0, 10);
    }


}
