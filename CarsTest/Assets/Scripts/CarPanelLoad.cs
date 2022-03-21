using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarPanelLoad : MonoBehaviour
{
    public Text NameText;
    public Text MassText;
    public Text CapacityText;
    public Text MaxSpeedText;
    public Text PowerText;

    public InputField NameTextIF;
    public InputField MassTextIF;
    public InputField CapacityTextIF;
    public InputField MaxSpeedTextIF;
    public InputField PowerTextIF;


    // Start is called before the first frame update
    void Start()
    {
        NameTextIF = GameObject.FindGameObjectWithTag("NameTextIF").GetComponent<InputField>();
        MassTextIF = GameObject.FindGameObjectWithTag("MassTextIF").GetComponent<InputField>();
        CapacityTextIF = GameObject.FindGameObjectWithTag("CapacityTextIF").GetComponent<InputField>();
        MaxSpeedTextIF = GameObject.FindGameObjectWithTag("MaxSpeedTextIF").GetComponent<InputField>();
        PowerTextIF = GameObject.FindGameObjectWithTag("PowerTextIF").GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCarInfo(string name, int mass, int capacity, int maxspeed, int power)
    {
        NameText.text = name;
        MassText.text = mass.ToString();
        CapacityText.text = capacity.ToString();
        MaxSpeedText.text = maxspeed.ToString();
        PowerText.text = power.ToString();
    }

    public void WriteInfo()
    {
        NameTextIF.text = NameText.text;
        MassTextIF.text = MassText.text;
        CapacityTextIF.text = CapacityText.text;
        MaxSpeedTextIF.text = MaxSpeedText.text;
        PowerTextIF.text = PowerText.text;

    }
}
