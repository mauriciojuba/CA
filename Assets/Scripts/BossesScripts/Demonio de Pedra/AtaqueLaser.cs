using UnityEngine;
using System.Collections;

public class AtaqueLaser : MonoBehaviour {
    public Color corLaser = Color.red;
    public int DistanciaDoLaser = 100;
    public float LarguraInicial = 0.02f, LarguraFinal = 0.1f;
    public PlayersDamangeHandler Turnip, Camponesa;
    private GameObject luzColisao;
    public bool isAttacking;
    float cont = 0;
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
        //assim que o script do boss ligar o gameObject o laser vai aparecer, FINO ligado o olho ao Target
        //depois de 4 segundos chama a função atirar.
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
            cont += Time.deltaTime;
            if (PontoDeColisao.collider.CompareTag("Player1") && cont >= 1)
            {
                Camponesa.HitPLayer(0.08f);

            }
            if (PontoDeColisao.collider.CompareTag("Player2") && cont >= 1)
            {
                Turnip.HitPLayer(0.08f);
            }
        }

    }
    void Atirar()
    {
        //Deixa o Lase mais grosso
        LarguraInicial = 0.6f;
        LarguraFinal = 0.8f;
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.SetWidth(LarguraInicial, LarguraFinal);
        luzColisao.GetComponent<Light>().range = LarguraFinal;
        isAttacking = true;

    }
    void OnDisable()
    {
        //Quando o script do boss desabilitar esse gameObject ele vai desligar o laser.
        luzColisao.SetActive(false);
        LarguraInicial = 0.1f;
        LarguraFinal = 0.2f;
        isAttacking = false;
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.SetWidth(LarguraInicial, LarguraFinal);
    }

    
    
}
