using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaLuz : MonoBehaviour
{
    [SerializeField] private Transform origen;
    [SerializeField] private Transform final;
    [SerializeField] 
    [Range(1f,100f)]
    private float rayDistance;
    public Material[] material;
    Renderer rend;


    // Start is called before the first frame update
    void Start()
    { 
       rend = GetComponent<Renderer>();
       rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        raycasting();
    }

    void raycasting()
    {
       RaycastHit hit;
       Physics.Raycast(origen.position, final.position, out hit, rayDistance);
        {
            if(hit.transform.CompareTag("Criatura"))
            {
                rend.sharedMaterial = material[0];
                Debug.Log("Colisiona con el jugador");
                Debug.Log("Colisiona con la criatura");
            }
        }
    }
}
