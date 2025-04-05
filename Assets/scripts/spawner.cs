using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public List<GameObject> platform=new List<GameObject>();

    public float spawnTime;
    private float counttime;
    private Vector3 spawnposition;
    // Update is called once per frame
    void Update()
    {
        spwanplatform();
    }
    public void spwanplatform()
    {
        counttime+= Time.deltaTime;
        spawnposition = transform.position;
        spawnposition.x = Random.Range(-3.5f, 3.5f);


        if(counttime >= spawnTime)
        {
            counttime = 0;
            createplatform();
        }
    }
    public void createplatform()
    {
        int index = Random.Range(0, platform.Count);
        //Instantiate(platform[index], spawnposition, Quaternion.identity); //列表中的检索，生成的位置，生成的角度
        int spikenum=0;
        if (index == 4)
        {
            spikenum++;
        }
        if (spikenum > 1)
        {
            spikenum = 0;
            counttime=spawnTime;
            return;
        }
        
        GameObject newplatform = Instantiate(platform[index], spawnposition, Quaternion.identity);
        newplatform.transform.SetParent(this.gameObject.transform);
    }



}
