using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    // enemy Prefab
    public GameObject enemyPrefab;
    public int max_enemy = 5;
    public static int enemy_count = 0;
    // time Var
    public float spawnTime = 2.1f;
    float time = 0f;
    float difficulty_time = 0f;
    float d_s_time = 15f;
    // Update is called once per frame
    void Update(){
        difficulty_time += Time.deltaTime;
          time += Time.deltaTime;
          if(time > spawnTime && enemy_count < max_enemy && !player.playerDead && resetVariables.play){
            findLocation();
            time = 0f;
          }

         if(difficulty_time > d_s_time){
           difficulty_time = 0f;
           d_s_time -= 0.2f;
           spawnTime -= 0.015f;
         } 
          
    }

    void generateEnemys(Vector3 enemy_pos){

      GameObject enemy_Clone = Instantiate(enemyPrefab , enemy_pos , Quaternion.identity);

      enemy_count++;
    }

    void findLocation(){

      // enemy pos
      Vector3 enemy_pos;
      int x_coor , z_coor;

      // which side to respawn
      int side = Random.Range(1, 4);

      switch (side) {

        case 1:     // Straight / North
          x_coor = Random.Range(-30 , 30);
          z_coor = Random.Range(40 , 50);
          enemy_pos = new Vector3(x_coor , transform.position.y , z_coor);
          generateEnemys(enemy_pos);
          break;

        case 2:     // left Side
          x_coor = Random.Range(-40, -35);
          z_coor = Random.Range(-10, 20);
          enemy_pos = new Vector3(x_coor , transform.position.y , z_coor);
          generateEnemys(enemy_pos);
          break;

        case 3:     // Right side
          x_coor = Random.Range(35, 40);
          z_coor = Random.Range(-10, 20);
          enemy_pos = new Vector3(x_coor , transform.position.y , z_coor);
          generateEnemys(enemy_pos);
          break;

        case 4:     // back / south
          x_coor = Random.Range(-30 , 30);
          z_coor = Random.Range(-20, -15);
          enemy_pos = new Vector3(x_coor , transform.position.y , z_coor);
          generateEnemys(enemy_pos);
          break;

      }

    }

}
