using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataHolder : MonoBehaviour
{
    public animalObjects thisAnimalData;



    public bool checkingData(string name){
        if(thisAnimalData.name.Equals(name)){
            return true;
        }else{
            return false;
        }
    }
}
