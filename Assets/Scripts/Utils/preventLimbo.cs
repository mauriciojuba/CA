using UnityEngine;
using System.Collections;

public class preventLimbo : MonoBehaviour {

    public Transform camp;

	
	void Update () {
        if (transform.position.z < camp.position.z)
        {
            if (camp.position.y <= transform.position.y)
            {
                camp.position = new Vector3(camp.position.x, camp.position.y + 3f, camp.position.z);
            }
        }
	}
}
