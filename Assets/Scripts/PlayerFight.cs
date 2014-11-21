using UnityEngine;
using System.Collections;
using System.Threading;

public class PlayerFight : Fight {

    bool submittedScore = false;
	// Use this for initialization
	new void Start () {
        base.Start();
        FindOpponent("Enemy");
      //  gui = Camera.main.GetComponent<GUIClass>();
      //  network.Setup();
	}
	
	// Update is called once per frame
	new void Update () {
        if (HealthBar.Health < 1 && !submittedScore)
        {
			//PlayerPrefs.SetInt("score",gui.EnemiesKilled);
            Application.LoadLevel("gameOver");
            submittedScore = true;
            
        }
        if(Attacking)
            this.GetComponent<Animator>().SetTrigger("Moving");
        base.Update();
            
	}
    public void PlayerAttack()
    {
        StartAttack();
        
    }
}
