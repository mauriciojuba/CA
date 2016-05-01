using UnityEngine;
using System.Collections;

public class TransparentObject : MonoBehaviour {

    Renderer render;
    Material Standard, Tranparent;
    public bool beTransparent;
    float count = 0;
	void Start () {
        render = GetComponent<Renderer>();
        Standard = render.sharedMaterial;
        Tranparent = Resources.Load("Transparent") as Material;
	}
	void Update () {
        if (beTransparent)
        {
            render.sharedMaterial = Tranparent;
        }
	}
}
