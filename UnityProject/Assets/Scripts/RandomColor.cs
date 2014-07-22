using UnityEngine;
using System.Collections;

public class RandomColor : MonoBehaviour {

    public Color color;
    public bool useRandomColor;


	void Start () {
        if (useRandomColor)
            renderer.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        else
            renderer.material.color = color;
	}
}
