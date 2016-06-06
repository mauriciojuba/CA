using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class splashScreen : MonoBehaviour {

    float count = 0;
	
	// Update is called once per frame
	void Update () {
        count += Time.deltaTime;
        if (count >= 8f)
        {
            SceneManager.LoadScene(1);
        }
	}
}
