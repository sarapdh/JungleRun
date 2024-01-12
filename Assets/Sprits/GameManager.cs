using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Renderer background;
    public GameObject Col;
    public GameObject Box;
    public List<GameObject> Cols;
    public List<GameObject> Boxs;
    public float speed = 2;
    public bool GameOver = false;
    public bool start = false;
    public GameObject MainMenu;
    public GameObject GameOverMenu;


    void Start()
    {
        for(int i = 0;i<40;i++){
           Cols.Add(Instantiate(Col, new Vector2(i,0),Quaternion.identity));
        }
    Boxs.Add(Instantiate(Box,new Vector2(7,-3),Quaternion.identity));
    Boxs.Add(Instantiate(Box,new Vector2(18,-3),Quaternion.identity));
    }


    void Update()
    {

        if(start == false){
            if(Input.GetKeyDown(KeyCode.X)){
                start = true;
            }
        }
        if(start == true && GameOver == true){
            GameOverMenu.SetActive(true);
            if(Input.GetKeyDown(KeyCode.X)){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if(start == true && GameOver == false){
            MainMenu.SetActive(false);
            background.material.mainTextureOffset = background.material.mainTextureOffset + new Vector2(0.15f,0)*Time.deltaTime;

         for(int i = 0;i<Cols.Count;i++){
            if(Cols[i].transform.position.x <= -20){
               Cols[i].transform.position = new Vector3(20,0) ;
            }
           Cols[i].transform.position = Cols[i].transform.position + new Vector3(-1,0)*Time.deltaTime * speed;
        }
        for(int i = 0;i<Boxs.Count;i++){
            if(Boxs[i].transform.position.x <= -10){
                float randomB = Random.Range(11,18);
               Boxs[i].transform.position = new Vector3(randomB,-3);
            }
           Boxs[i].transform.position = Boxs[i].transform.position + new Vector3(-1,0)*Time.deltaTime * speed;
        }

        }
    }
}
