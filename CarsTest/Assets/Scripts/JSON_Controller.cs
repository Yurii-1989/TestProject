using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;


public class JSON_Controller : MonoBehaviour
{
    public GameController gameController;
    public TextAsset jsonData;
    public CarObjects myCarObjects = new CarObjects();

    
    void Start()
    {
        AssetDatabase.Refresh();
        myCarObjects = JsonUtility.FromJson<CarObjects>(jsonData.text);
    }

   [ContextMenu("Load")]
   public void LoadCars()
   {
        AssetDatabase.Refresh();
        myCarObjects = JsonUtility.FromJson<CarObjects>(jsonData.text);
    }


   [ContextMenu("Save")]
   public void SaveCars()
   {
        File.WriteAllText(AssetDatabase.GetAssetPath(jsonData), JsonUtility.ToJson(myCarObjects));
        EditorUtility.SetDirty(jsonData);
    }

    public void AddCar()
    {
        LoadCars();
        CarArreyElement currentCarInfo = new CarArreyElement();

        currentCarInfo.Name = gameController.NameIF.text;
        currentCarInfo.Mass = System.Convert.ToInt32(gameController.MassIF.text);
        currentCarInfo.Capacity = System.Convert.ToInt32(gameController.CapacityIF.text);
        currentCarInfo.MaxSpeed = System.Convert.ToInt32(gameController.MaxSpeedIF.text);
        currentCarInfo.Power = System.Convert.ToInt32(gameController.PowerIF.text);

        myCarObjects.carList.Add(currentCarInfo);

        File.WriteAllText(AssetDatabase.GetAssetPath(jsonData), JsonUtility.ToJson(myCarObjects));
        EditorUtility.SetDirty(jsonData);

        gameController.LoadPanelCars();
        Debug.Log("Add " + currentCarInfo.Name);
    }

    public void DeleteCar()
    {
        LoadCars();
        CarArreyElement currentCarInfo = new CarArreyElement();

        currentCarInfo.Name = gameController.NameIF.text;

        foreach (var car in myCarObjects.carList)
        {
            
            if (car.Name == currentCarInfo.Name)
            {
                Debug.Log("Delete "+ car.Name);
                
                myCarObjects.carList.Remove(car);
                File.WriteAllText(AssetDatabase.GetAssetPath(jsonData), JsonUtility.ToJson(myCarObjects));
                EditorUtility.SetDirty(jsonData);
                break;
            }
            
        }

        LoadCars();
        gameController.LoadPanelCars();
    }

    public void ChangeCar()
    {
        LoadCars();
        CarArreyElement currentCarInfo = new CarArreyElement();

        currentCarInfo.Name = gameController.NameIF.text;
        currentCarInfo.Mass = System.Convert.ToInt32(gameController.MassIF.text);
        currentCarInfo.Capacity = System.Convert.ToInt32(gameController.CapacityIF.text);
        currentCarInfo.MaxSpeed = System.Convert.ToInt32(gameController.MaxSpeedIF.text);
        currentCarInfo.Power = System.Convert.ToInt32(gameController.PowerIF.text);

        foreach (var car in myCarObjects.carList)
        {

            if (car.Name == currentCarInfo.Name)
            {
                car.Mass = currentCarInfo.Mass;
                car.Capacity = currentCarInfo.Capacity;
                car.MaxSpeed = currentCarInfo.MaxSpeed;
                car.Power = currentCarInfo.Power;




                File.WriteAllText(AssetDatabase.GetAssetPath(jsonData), JsonUtility.ToJson(myCarObjects));
                EditorUtility.SetDirty(jsonData);

                Debug.Log("Changes in " + car.Name);
                break;
            }

        }

        LoadCars();
        gameController.LoadPanelCars();
    }

    [System.Serializable]
    public class CarObjects
    {
        public List<CarArreyElement> carList;
    }



    [System.Serializable]
    public class CarArreyElement
    {
        public string Name;
        public int Mass;
        public int Capacity;
        public int MaxSpeed;
        public int Power;
    }


}
