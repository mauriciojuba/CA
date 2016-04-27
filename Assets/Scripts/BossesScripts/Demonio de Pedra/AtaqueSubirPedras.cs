using UnityEngine;
using System.Collections;

public class AtaqueSubirPedras : MonoBehaviour {

    public PlayersDamangeHandler Turnip, Camponesa;

    //Lembrar de Abaixar o Collider para que os players só recebam hit quando ele subir.

    void OnTriggerEnter(Collider hit)
    {
        if(hit.CompareTag("Player1"))
        {
            Camponesa.HitPLayer(30f);
        }
        if (hit.CompareTag("Player2"))
        {
            Turnip.HitPLayer(30f);
        }
        
    }
}
