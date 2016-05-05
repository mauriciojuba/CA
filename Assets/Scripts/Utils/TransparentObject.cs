using UnityEngine;
using System.Collections;

public class TransparentObject : MonoBehaviour {

    Renderer render;
    Material Standard, Transparent;
    public float count = 0;
	void Start () {
        render = GetComponent<Renderer>();
        Standard = render.sharedMaterial;
        Transparent = Resources.Load("Transparent") as Material;
	}
	void Update () {
        if (count > 5)
        {
            render.sharedMaterial = Standard;
            Destroy(this);
        }
        else
        {
            render.sharedMaterial = Transparent;
            count++;
        }
	}
}
