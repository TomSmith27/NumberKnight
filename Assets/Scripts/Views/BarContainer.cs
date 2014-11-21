using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class BarContainer : MonoBehaviour {

    protected const float WIDTH = 80;
    protected const float HEIGHT = 15;
    protected Vector2 pos;
    protected const int padding = 2;
    protected int offset = 0;

    public void OnGUI()
    {
        pos = Camera.main.WorldToScreenPoint(transform.position);
        pos.y = (Screen.height - pos.y) - 50 + offset;

        GUI.Button(new Rect(pos.x - WIDTH/2, pos.y, WIDTH, HEIGHT), "");
    }
}
