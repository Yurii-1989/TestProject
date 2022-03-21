using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public JSON_Controller jsonController;
    

    public GameObject CarPanel;
    public GameObject StartPanel;


    public InputField NameIF;
    public InputField MassIF;
    public InputField CapacityIF;
    public InputField MaxSpeedIF;
    public InputField PowerIF;
    public GameObject ScrollViewPanels;


    

    public void LoadPanelCars()
    {
        
        foreach (Transform child in ScrollViewPanels.transform)
        {
            GameObject.Destroy(child.gameObject);
        }


        foreach (var car in jsonController.myCarObjects.carList)
        {

            GameObject CurrentCarPanel = Instantiate(CarPanel) as GameObject; ;
            CarPanelLoad CurrentCarPanelLoad = CurrentCarPanel.GetComponent<CarPanelLoad>();

            CurrentCarPanelLoad.AddCarInfo(car.Name, car.Mass, car.Capacity, car.MaxSpeed, car.Power);



            CurrentCarPanel.transform.SetParent(ScrollViewPanels.transform);
            
            
        }


        StartPanel.SetActive(false);
    }


    
}
