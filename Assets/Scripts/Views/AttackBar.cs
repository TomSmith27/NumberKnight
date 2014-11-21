using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class AttackBar : BarContainer {

    public float AttackCharge
    {
        get;
        set;
    }
    void OnGUI()
    {
        base.OnGUI();
        offset = -10;
        GUI.backgroundColor = Color.cyan;
        if(AttackCharge != 0)
            GUI.Button(new Rect(pos.x - WIDTH/2, pos.y, WIDTH * AttackCharge, HEIGHT - 5),"");

    }
	// Update is called once per frame
	void Update () {
	
	}
}
