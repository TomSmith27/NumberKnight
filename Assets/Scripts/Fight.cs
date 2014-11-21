using UnityEngine;
using System.Collections;

public abstract class Fight : MonoBehaviour {

    public GameObject self;
    public GameObject opponent;
    public Vector3 initialPos;
	public enum GameState
	{
		Fighting

	};
    public bool Dead
    {
        get;
        set;
    }
	public GameState CurrentGameState {
				get;
				set;
	}
    public bool Attacking
    {
        get;
        set;
    }
    public HealthBar HealthBar
    {
        get;
        set;
    }
    public bool BackAtSpawn
    {
        get;
        set;
    }

	// Use this for initialization
	public void Start () {
        initialPos = this.transform.position;
        HealthBar = this.GetComponent<HealthBar>();

	}
    public void FindOpponent(string opponentTag)
    {
        var potentialOpponents = GameObject.FindGameObjectsWithTag(opponentTag);

        foreach (var opp in potentialOpponents)
        {
            if (!opp.GetComponent<Fight>().Dead)
            {
                opponent = opp;
                return;
            }
        }
    }
    void GetBackToInitalPos()
    {
        if (Vector3.Distance(this.transform.position, initialPos) > 0.25 && !BackAtSpawn)
        {
            float step = 10 * Time.deltaTime;
            this.transform.position = (Vector3.MoveTowards(this.transform.position, initialPos, step));
            if (Vector3.Distance(this.transform.position, initialPos) < 0.25)
            {
                BackAtSpawn = true;
                this.GetComponent<Animator>().SetBool("Moving", false);
            }
        }
    }
    public void DamageOpponent()
    {
            Attacking = false;
            opponent.GetComponent<HealthBar>().Health--;
            this.GetComponent<Animator>().SetTrigger("Attack");
            GameObject.Find("GUI").GetComponent<QuestionRenderer>().GenerateNewQuestion();
            this.GetComponent<AudioSource>().Play();
            BackAtSpawn = false;
    }
    public void StartAttack()
    {
        Attacking = true;
    }
    bool MoveToOpponent()
    {
        float step = 10 * Time.deltaTime;
        this.transform.position = (Vector3.MoveTowards(this.transform.position, opponent.transform.position, step));
        return (Vector3.Distance(this.transform.position, opponent.transform.position) < 1);
        
    }
	// Update is called once per frame
	public void Update () {
	 	switch(CurrentGameState)
		{
			case GameState.Fighting:
			{
		        if (Attacking)
				{ if (MoveToOpponent())
		                DamageOpponent();
				}
		        else if(!Dead)
		            GetBackToInitalPos();
				break;
			}
		}
	}
}
