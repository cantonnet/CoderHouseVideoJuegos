using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //Agrupamiento fijo porque solo tengo 3 armas
    //TDA1
    [SerializeField] GameObject[] weapons;
    [SerializeField] Transform playerHand;
    // Start is called before the first frame update
    //TDA 2
    [SerializeField] List<GameObject> weaponList;
    public List<GameObject> WeaponList {get => weaponList; set => weaponList = value;}
    //TDA3
    [SerializeField] private Queue weaponQueue;
    public Queue WeaponQueue {get => weaponQueue; set => weaponQueue = value;}

    //TDA5 diccionario
    private Dictionary<string, GameObject> weaponDirectory;
    public Dictionary<string, GameObject> WeaponDirectory {get => weaponDirectory; set => weaponDirectory = value;}

    void Start()
    {
        // weapons[1].SetActive(true);
        // weapons[1].transform.parent = playerHand;
        // weapons[1].transform.localPosition = Vector3.zero;
        weaponList = new List<GameObject>();
        weaponQueue = new Queue();
        weaponDirectory = new Dictionary<string, GameObject>();
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
        foreach (GameObject weapon in weaponList)
        {
            weapon.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) EnableAllWeapon();
        //Input de queq
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (weaponQueue.Count > 0)
            {
            GameObject weapon = weaponQueue.Dequeue() as GameObject;
            weapon.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponDirectory["WeaponA"].SetActive(true);
            weaponDirectory["WeaponA"].transform.parent = playerHand;
            weaponDirectory["WeaponA"].transform.localPosition = Vector3.zero;
            weaponDirectory["WeaponB"].SetActive(false);
            weaponDirectory["WeaponC"].SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponDirectory["WeaponB"].SetActive(true);
            weaponDirectory["WeaponB"].transform.parent = playerHand;
            weaponDirectory["WeaponB"].transform.localPosition = Vector3.zero;
            weaponDirectory["WeaponA"].SetActive(false);
            weaponDirectory["WeaponC"].SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponDirectory["WeaponC"].SetActive(true);
            weaponDirectory["WeaponC"].transform.parent = playerHand;
            weaponDirectory["WeaponC"].transform.localPosition = Vector3.zero;
            weaponDirectory["WeaponA"].SetActive(false);
            weaponDirectory["WeaponB"].SetActive(false);
        } 

    }

    void EnableAllWeapon()
    {
        foreach (GameObject weapon in weaponList)
        {
            weapon.SetActive(true);
        }
    }
}
