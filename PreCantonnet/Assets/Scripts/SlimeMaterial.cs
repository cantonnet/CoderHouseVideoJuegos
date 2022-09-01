using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMaterial : MonoBehaviour
{
    [SerializeField] private Transform origen;
    [SerializeField] private Transform final;
    [SerializeField] 
    [Range(1f,100f)]
    private float rayDistance;
    enum slimeweapon { comun, bomba};
    [SerializeField] slimeweapon SlimeWeapon;
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
        raycastingpiel();
        armaslime();
    }

    void armaslime()
    {
        switch (SlimeWeapon)
        {
            case slimeweapon.comun:
                break;
                rend.sharedMaterial = material[0];
            case slimeweapon.bomba:
                rend.sharedMaterial = material[1];
                break;
        }
    }

    void raycastingpiel()
    {
       RaycastHit hit;
       Physics.Raycast(origen.position, final.position, out hit, rayDistance);
        {
            if(hit.transform.CompareTag("Jugador"))
            {
                rend.sharedMaterial = material[2];
                Debug.Log("Colisiona con el jugador");
            }
        }
    }
}
