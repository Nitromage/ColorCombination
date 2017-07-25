using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject enemy;
    public Vector3 spawnValues;
    public int enemyCount;
    public float spawnWait;
    public float startWait;
    public float waveTextTimer;
    public Text Wavetext;
    public float TimeBetweenWaves;
    public Increment inc = new Increment();

    int waveCount = 1;
    bool startwave = true;
    float waveTimer;
    bool startWaveTimer;
    int enemyCountIncrement = 1;
    // List<Color> colors = new List<Color>() { Color.green, Color.red, Color.blue, Color.black, Color.white };
    List<Color> colors = new List<Color>() { Color.magenta, new Color(1,1,0,1), Color.cyan, new Color(-1,-1,-1,-2), Color.white };
    // Use this for initialization
    void Start()
    {
        
        //SpawnWave();
        /* colors.Add(Color.red + Color.green);
         colors.Add(Color.red + Color.blue);
         colors.Add(Color.green + Color.blue);*/
        colors.Add(Color.white - new Color(1,1,0,1));
        colors.Add(Color.white - Color.cyan);
        colors.Add(Color.white - Color.magenta);
    }

    IEnumerator SpawnWave()
    {
        startwave = false;
        StartCoroutine(ShowWaveText());
        yield return new WaitForSeconds(startWait);
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            GameObject go = Instantiate(enemy, spawnPosition, spawnRotation);
            int number = Random.Range(0, colors.Count);
            Color color = colors[number];
            color.a = 1;
            go.GetComponent<MeshRenderer>().material.color = color;
            //go.tag = color.ToString();
            //Debug.Log(color.ToString());
            go.GetComponent<BallColor>().ballColor = go.GetComponent<MeshRenderer>().material.color;
            //Debug.Log(go.GetComponent<MeshRenderer>().material.color.ToString());
            yield return new WaitForSeconds(spawnWait);
        }
        startWaveTimer = true;
        WaveIncrement();
    }

    void WaveIncrement()
    {
        waveCount++;
        Wavetext.text = "Wave: " + waveCount.ToString();

        if (waveCount % 2 == 0)
        {
            enemyCount += inc.EnemyCountInc;
            inc.EnemyCountInc++;
        }
        else
        {
            spawnWait -= inc.SpawnWaitInc;
            TimeBetweenWaves -= inc.TimeBetweenWavesInc;
        }
        if (waveCount % 5 == 0)
        {
            enemy.GetComponent<Moving>().speed += inc.EnemySpeedInc;
        }
    }

    IEnumerator ShowWaveText()
    {
        Color color = new Color(Wavetext.color.r, Wavetext.color.g, Wavetext.color.b, 1);
        Wavetext.color = Color.Lerp(Wavetext.color, color, 1f);
        yield return new WaitForSeconds(waveTextTimer);
        color = new Color(Wavetext.color.r, Wavetext.color.g, Wavetext.color.b, 0);
        Wavetext.color = Color.Lerp(Wavetext.color, color, 1f);
        yield return new WaitForEndOfFrame();
    }

    // Update is called once per frame
    void Update()
    {

        if (startwave)
        {
            StartCoroutine(SpawnWave());
        }
        if (startWaveTimer)
        {
            waveTimer += Time.deltaTime;
        }
        if (waveTimer > TimeBetweenWaves)
        {
            waveTimer = 0;
            startwave = true;
            startWaveTimer = false;
        }
    }

    [System.Serializable]
    public class Increment
    {
        public float EnemySpeedInc;
        public int EnemyCountInc;
        public float TimeBetweenWavesInc;
        public float SpawnWaitInc;
    }
}


