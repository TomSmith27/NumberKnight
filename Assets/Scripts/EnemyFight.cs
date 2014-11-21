using UnityEngine;
using System.Collections;

public class EnemyFight : Fight {

    public float attackFrequency = 5.0f;
    float timer;

	// Use this for initialization
	new void Start () {
        base.Start();
        FindOpponent("Player");
        attackBar = this.GetComponent<AttackBar>();
	}
    public AttackBar attackBar
    {
        get;
        set;
    }

	// Update is called once per frame
	new void Update () {
		switch (CurrentGameState) {
				case GameState.Fighting:
						{
                            if (!Attacking)
                                timer += Time.deltaTime;
                            attackBar.AttackCharge = timer / attackFrequency;
								if (!Dead) {
										base.Update ();
										if (timer > attackFrequency) {
												StartAttack ();
												timer = 0;
										}
										if (HealthBar.Health < 1) {
												Dead = true;
                                                GameObject.Find("GUI").GetComponent<QuestionRenderer>().EnemiesKilled++;
												Instantiate (self, initialPos, Quaternion.identity);
										}
								} else
										Die ();
							break;
						}
		default:
			return;

				}

	}
    void Die()
    {
        opponent.GetComponent<Fight>().FindOpponent("Enemy");
        if (Dead)
        {
            float step = 10 * Time.deltaTime;
            this.transform.position = (Vector3.MoveTowards(this.transform.position, new Vector3(20, this.transform.position.y, 0), step));
            if (Vector3.Distance(this.transform.position, new Vector3(20, this.transform.position.y, 0)) < 1)
            {            
                Debug.Log("Dead");
                Destroy(this.gameObject);
            }
        }
        
    }
}
