using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Generator : MonoBehaviour
{
    bool endGame = false;
    public List<animalObjects> animals;
    public List<animalObjects> used;

    public List<Image> pictures;
    public List<Image> Answers;

    public List<animalObjects> rounds;
    // Start is called before the first frame update

    public bool getEndGame(){
        return endGame;
    }
    void Start()
    {
        createRound(); 
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void createRound(){
        rounds.Clear();
        if(animals.Count == 0){
        endGame = !endGame;
        return;
        }

        for(int i = 0; i <3 ; i++){
       int index = UnityEngine.Random.Range(0,animals.Count);
       used.Add(animals[index]);
       rounds.Add(animals[index]);
       animals.RemoveAt(index);
    }

    fillObjects(rounds);
}

void fillObjects (List<animalObjects> rounds){

        for(int i = 0; i < 3; i++){
            pictures[i].GetComponent<Image>().sprite = rounds[i].animalPicture;
            pictures[i].GetComponent<dataHolder>().thisAnimalData = rounds[i];
        }
        rounds = shuffle(); 
        for(int i = 0; i < 3; i++){
                 
            Answers[i].transform.GetChild(0).transform.GetComponent<Text>().text = rounds[i].animalName; 

        }
    }

    List<animalObjects> shuffle()
    {
        List<animalObjects> randomized = new List<animalObjects>();
        
        for(int i = 0; i < 3; i++){
        int index = UnityEngine.Random.Range(0,rounds.Count);
        randomized.Add(rounds[index]);
        rounds.RemoveAt(index);
        }

        return randomized;
    }


    public void checkResults(){}

}
