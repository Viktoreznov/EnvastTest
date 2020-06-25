using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
    public AudioSource[] sfx;
    bool Winner =  false;
    bool Loser = false;
    float time = 60;

    int score = 0;
    int stars = 0;

    public int Coins;

    public int numberOfAttempts = 0;

    public Generator generator;

    public GameObject youLosePopup;

    public GameObject youWinPopup;

    public GameObject youFinishedPopup; 
    public Text timeRemaining;
    
    public GameObject[] Stars;
    public Sprite winStar;
    public Sprite starLost;

    public Button repeatButton;

    public Text totalCoinsText;
    void Awake()
    {
        if(PlayerPrefs.HasKey("amountOfCoins")){
            Coins = PlayerPrefs.GetInt("amountOfCoins");
        }else{
            Coins = 0;
        }
        numberOfAttempts++;
    }


    void Update()
    {
        totalCoinsText.text = Coins.ToString();
        time -= Time.deltaTime;
        timeRemaining.text = ((int) time).ToString();

        if(time < 0){
            Loser = true;
            Time.timeScale = 0;
            youLosePopup.SetActive(true);
        }

        if(generator.getEndGame()){
            youFinishedPopup.SetActive(true);
        }
    }

    public void tryAgain(){
       Time.timeScale = 1;
        score = 0;
        time = 60;
        numberOfAttempts = 1;
        Loser = false;
        youLosePopup.SetActive(false);
        youWinPopup.SetActive(false);
        for(int i = 0; i < generator.pictures.Count; i++){
            generator.pictures[i].GetComponent<PositionSaver>().reset();
        } 
    }

    public void restart(){
        Time.timeScale = 1;
        score = 0;
        time = 60;
        numberOfAttempts++;
        Loser = false;
        youLosePopup.SetActive(false);
        youWinPopup.SetActive(false);
        for(int i = 0; i < generator.pictures.Count; i++){
            generator.pictures[i].GetComponent<PositionSaver>().reset();
        }
    }



    public void check(){

        Time.timeScale = 0;
        testAnswers();
        settingStars(stars);
    }

    private void testAnswers(){
        Debug.Log("the number of attempts is :"+ numberOfAttempts);
        foreach(Image slot in generator.Answers){
            if(slot.transform.parent.GetComponent<itemSlot>().pictureDragged[0].GetComponent<dataHolder>().thisAnimalData.animalName == slot.transform.GetChild(0).GetComponent<Text>().text)
            score++;
        }

        if(score == 3){
            Winner = true;
            youWinPopup.SetActive(true);
            sfx[0].Play();
            score = 0;
            if(numberOfAttempts == 1){
            stars = 3;
            repeatButton.gameObject.SetActive(false);
            Coins+=100;
            }
            else if (numberOfAttempts>1 && numberOfAttempts <= 4){
            stars = 2;
            repeatButton.gameObject.SetActive(true);
            Coins+=60;
            }
            else if(numberOfAttempts >4 && numberOfAttempts < 6){
            stars = 1;
            repeatButton.gameObject.SetActive(true);
            Coins+=30;
            }
            else {stars = 0; repeatButton.gameObject.SetActive(true); Coins += 10;}
        }else{
            youLosePopup.SetActive(true);
            sfx[1].Play();
        }

        PlayerPrefs.SetInt("amountOfCoins",Coins);
    }

    void settingStars(int stars){
        for (int i =0 ; i < stars; i++){
            Stars[i].GetComponent<Image>().sprite = winStar;
        }
        for(int i = stars; i< 3; i++ ){
            Stars[i].GetComponent<Image>().sprite = starLost;
        }
    }


    public void nextRound(){
        
        numberOfAttempts = 1;
        score = 0;
        time = 60; 

        generator.createRound();
        
        youWinPopup.SetActive(false);

        for(int i = 0; i < generator.pictures.Count; i++){
            generator.pictures[i].GetComponent<PositionSaver>().reset();
        }  
        
    }

    public void mainScreen(){
        SceneManager.LoadScene("WelcomeScreen");
    }
    
}
