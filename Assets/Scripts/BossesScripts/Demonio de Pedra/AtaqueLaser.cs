using UnityEngine;
using System.Collections;

public class AtaqueLaser : MonoBehaviour {
    public Color corLaser = Color.red;
    public int DistanciaDoLaser = 100;
    public float LarguraInicial = 0.02f, LarguraFinal = 0.1f;
    public PlayersDamangeHandler Turnip, Camponesa;
    private GameObject luzColisao;
    public bool isAttacking;
    void Start()
    {
        isAttacking = false;
        luzColisao = new GameObject();
        luzColisao.AddComponent<Light>();
        luzColisao.GetComponent<Light>().intensity = 8;
        luzColisao.GetComponent<Light>().bounceIntensity = 8;
        luzColisao.GetComponent<Light>().range = LarguraFinal * 2;
        luzColisao.GetComponent<Light>().color = corLaser;
        //
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.SetColors(corLaser, corLaser);
        lineRenderer.SetWidth(LarguraInicial, LarguraFinal);
        lineRenderer.SetVertexCount(2);
    }
    void OnEnable()
    {
        Invoke("Atirar", 4f);
    }

    void Update()
    {
        Vector3 PontoFinalDoLaser = transform.position + transform.forward * DistanciaDoLaser;
        RaycastHit PontoDeColisao;
        if (Physics.Raycast(transform.position, transform.forward, out PontoDeColisao, DistanciaDoLaser))
        {
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, PontoDeColisao.point);
            float distancia = Vector3.Distance(transform.position, PontoDeColisao.point) - 0.03f;
            luzColisao.transform.position = transform.position + transform.forward * distancia;
        }
        else
        {
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, PontoFinalDoLaser);
            luzColisao.transform.position = PontoFinalDoLaser;
        }
        if (isAttacking)
        {
            if (PontoDeColisao.collider.CompareTag("Player1"))
            {
                Camponesa.HitPLayer(0.2f);
            }
            if (PontoDeColisao.collider.CompareTag("Player2"))
            {
                Turnip.HitPLayer(0.2f);
            }
        }

    }
    void Atirar()
    {

        LarguraInicial = 0.6f;
        LarguraFinal = 0.8f;
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.SetWidth(LarguraInicial, LarguraFinal);
        luzColisao.GetComponent<Light>().range = LarguraFinal;
        isAttacking = true;

    }
    void OnDisable()
    {
        luzColisao.SetActive(false);
        LarguraInicial = 0.1f;
        LarguraFinal = 0.2f;
        isAttacking = false;
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.SetWidth(LarguraInicial, LarguraFinal);
    }

    
    
}
