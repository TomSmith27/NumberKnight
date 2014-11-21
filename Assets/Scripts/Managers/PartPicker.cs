using UnityEngine;
using System.Collections;

public class PartPicker : MonoBehaviour {
	public Sprite[] allHeads, allBodies, allFeet;
	int headIndex = 0;
	int bodyIndex = 0;
	int feetIndex = 0;
	SpriteRenderer headImage, bodyImage, feetImage;
	// Use this for initialization
	void Start () {
	    allHeads = Resources.LoadAll<Sprite>("Sprites/CharacterParts/Heads");
		allBodies = Resources.LoadAll<Sprite>("Sprites/CharacterParts/Bodies");
		allFeet = Resources.LoadAll<Sprite>("Sprites/CharacterParts/Feet");
		headImage = GameObject.Find ("Head").GetComponent<SpriteRenderer> ();
		bodyImage = GameObject.Find ("Body").GetComponent<SpriteRenderer> ();
		feetImage = GameObject.Find ("Feet").GetComponent<SpriteRenderer> ();

	}
	public void NextHead(int direction)
	{
		headIndex = nextPart (direction, allHeads, headIndex, headImage);
	}
	public void NextBody(int direction)
	{
		bodyIndex = nextPart (direction, allBodies, bodyIndex, bodyImage);
	}
	public void NextFeet(int direction)
	{
		feetIndex = nextPart (direction, allFeet, feetIndex, feetImage);
	}
	public int nextPart(int direction, Sprite[] Parts, int index, SpriteRenderer image)
	{
		if (direction == 1) {
				if (index == Parts.Length - 1) {
						index = 0;
				}
				else 
				{ index++; }
			} else {
			    if(index == 0)
				{
					index = Parts.Length - 1;
				}
				else { index--; }
			}
		Debug.Log (index);
		Debug.Log (Parts [index]);
			image.sprite = Parts[index];

		return index;

	}
}
