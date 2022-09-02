using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //Agrupamiento fijo porque solo tengo 3 armas
    [SerializeField] GameObject[] weapons;
    [SerializeField] Transform playerHand;
    // Start is called before the first frame update
    [SerializeField] List<GameObject> weaponList;
    public List<GameObject> WeaponList {get => weaponList; set => weaponList = value;}
    void Start()
    {
        weapons[1].SetActive(true);
        weapons[1].transform.parent = playerHand;
        weapons[1].transform.localPosition = Vector3.zero;
        weaponList = new List<GameObject>();
    }

    void DiseableAllWeapons()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
    }

    void EnableWeapon()
    {
        foreach (var weapon in weaponList)
        {
            weapon.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
