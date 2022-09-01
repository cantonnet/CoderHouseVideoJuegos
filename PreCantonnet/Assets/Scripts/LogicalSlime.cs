using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalSlime : MonoBehaviour
{

    [SerializeField]
    [Range(1f, 10f)]
    private float speed = 2f;
    enum slimetype { Rotador, Seguidor, huir, idle};
    [SerializeField] slimetype SlimeType;
    [SerializeField] Transform playerTransform;
    public Animator animator;
    private bool caminar;
    private bool colision;
    int escala;
    public int vida = 3;
    public int damage = 1;
    float time;

    // Start is called before the first frame update
    void Start()
    {
       escala = Random.Range(1, 4);
       playerTransform = GameObject.FindWithTag("Jugador").transform;
       animator = GetComponent<Animator>();
       transform.localScale = transform.localScale * escala;
    }

    // Update is called once per frame
    void Update()
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
        morir();
        ResetState();
    }

    private void RotarAlJugador()
    {
        VerJugador();
        transform.RotateAround(playerTransform.position, Vector3.up, 5f * Time.deltaTime);
    }

    private void Movimiento()
    {
        if (speed != 0){caminar = true;}else{caminar = false;}
    }

    private void SeguirJugador()
    {
        VerJugador();
        Vector3 direction = (playerTransform.position - transform.position);
        if (direction.magnitude > 2.5f)
        {
           transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }

    private void HuirDelJugador()
    {
        NoVerJugador();
        Vector3 direction = (playerTransform.position + transform.position);
        if (direction.magnitude > 2.5f)
        {
           transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }
    
    private void VerJugador()
    {
        Quaternion newRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 1.5f * Time.deltaTime);
    }

    private void NoVerJugador()
    {
        Quaternion newRotation = Quaternion.LookRotation(playerTransform.position + transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 1.5f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Poder"))
        { 
            time += Time.deltaTime;
            colision = true;
            vida = vida - damage;
        }
    }
     private void ResetState()
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

    private void morir()
    {
        if (vida <= 0)
        { 
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Poder"))
        { 
                    colision = false;
        }
    }

}
