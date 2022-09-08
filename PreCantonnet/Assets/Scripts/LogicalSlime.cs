using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalSlime : MonoBehaviour
{
    enum slimetype { Rotador, Seguidor, huir, idle};
    [SerializeField] slimetype SlimeType;
    [SerializeField] Transform playerTransform;
    public Animator animator;
    private bool caminar;
    private bool colision;
    int escala;
    float time;
    int vidaslime;

    [SerializeField]
    protected SlimeData slimeData;

    // Start is called before the first frame update
    void Start()
    {
       vidaslime = slimeData.vida; 
       escala = Random.Range(slimeData.escalamenor, slimeData.escalamayor);
       playerTransform = GameObject.FindWithTag("Jugador").transform;
       animator = GetComponent<Animator>();
       transform.localScale = transform.localScale * escala;
    }

    // Update is called once per frame
    void Update()
    {
        swicher();
        morir();
        ResetState();
    }

    public void swicher()
    {
        switch (SlimeType)
        {
            case slimetype.Seguidor:
                SeguirJugador();
                colision = false;
                break;
            case slimetype.Rotador:
                RotarAlJugador();
                colision = false;
                break;
            case slimetype.huir:
                HuirDelJugador();
                colision = false;
                break;
            case slimetype.idle:
                colision = true;
                break;
        }
    }

    public void RotarAlJugador()
    {
        VerJugador();
        transform.RotateAround(playerTransform.position, Vector3.up, 5f * Time.deltaTime);
    }

    public void Movimiento()
    {
        if (slimeData.speed != 0){caminar = true;}else{caminar = false;}
    }

    public void SeguirJugador()
    {
        VerJugador();
        Vector3 direction = (playerTransform.position - transform.position);
        if (direction.magnitude > 2.5f)
        {
           transform.position += direction.normalized * slimeData.speed * Time.deltaTime;
        }
    }

    public void HuirDelJugador()
    {
        NoVerJugador();
        Vector3 direction = (playerTransform.position + transform.position);
        if (direction.magnitude > 2.5f)
        {
           transform.position += direction.normalized * slimeData.speed * Time.deltaTime;
        }
    }
    
    public void VerJugador()
    {
        Quaternion newRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 1.5f * Time.deltaTime);
    }

    public void NoVerJugador()
    {
        Quaternion newRotation = Quaternion.LookRotation(playerTransform.position + transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 1.5f * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Poder"))
        { 
            time += Time.deltaTime;
            colision = true;
            vidaslime = vidaslime - slimeData.damage;
        }
    }
     public void ResetState()
    {
        if (colision == false)
                {
                caminar = true;
                SlimeType = slimetype.Seguidor;
                caminar = true;
                colision = false;
                time = 0f;
                if (caminar) animator.SetBool("caminar", true);
                }
        if (colision == true)
                {
                if (colision) animator.SetBool("colision", true);
                caminar = false;
                SlimeType = slimetype.idle;
                time = 0f;
                }
    }

    public void morir()
    {
        if (vidaslime <= 0)
        { 
            Destroy(gameObject);
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Poder"))
        { 
                    colision = false;
        }
    }

}
