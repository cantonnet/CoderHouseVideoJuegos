using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    private static HUDManager instance;
    public static HUDManager Instance {get => instance; }
    [SerializeField] private Text selectedtext;
    [SerializeField] private GameObject weaponPanel;
    public Material[] imagenes;
    [SerializeField] private Slider hpbar;
    [SerializeField] private Slider mpbar;


    private void Awake() {
        if (instance == null)
        {
            instance = this;
            Debug.Log(instance);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        instance.hpbar.value = 50;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSelectedText(string newText)
    {
        selectedtext.text = newText;
    }

    public void EnableWeapon(int childIndex)
    {
        if (childIndex == 0)
        {
            Instance.weaponPanel.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.blue;
        }
        if (childIndex == 1)
        {
            Instance.weaponPanel.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.green;
        }
        if (childIndex == 2)
        {
            Instance.weaponPanel.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
        }
    }

    public static void SetHPBar (int newValue)
    {
        instance.hpbar.value = newValue;
    }

    public static void SetMPBar (int newValue)
    {
        instance.mpbar.value = newValue;
    }
}
