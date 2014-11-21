using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class HealthBar : BarContainer {

    public int MaxHealth = 10;
    float health = 10;
	public GUISkin customSkin;
	protected GUIStyle HealthBarStyle;
	// Use this for initialization
	void Start () {
        health = MaxHealth;
		//HealthBarStyle = customSkin.customStyles [3];
	}
    public float Health
    {
        get { return health; }
        set { health = value; } 
    }
    void OnGUI()
    {
        base.OnGUI();
        GUI.backgroundColor = HealthColour();
        string healthText = string.Format("Health {0} / {1}", health, MaxHealth);
        GUI.Button(new Rect(pos.x - WIDTH/2, pos.y, (WIDTH) * (health/MaxHealth), HEIGHT), "");
    }
    Color HealthColour()
    {
        if (health > MaxHealth * 0.7f)
            return Color.green;
        else if (health > MaxHealth * 0.4f)
            return Color.yellow;
        else
            return Color.red;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
