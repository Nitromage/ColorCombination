using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    //public EasyIncrement EasyInc;
    //public HardIncrement HardInc;
    public EasyIncrement EasyInc;
    public HardIncrement HardInc;
    public int Difficulty;
    public int TestStartWave;
    public GameObject player;
    List<Color> ColorList;
    

    int waveCount;
    bool startwave = true;
    float waveTimer;
    bool startWaveTimer;
    int enemyCountIncrement = 1;
    int enemySpawnCount = 1;
    List<Color> rgbEasy = new List<Color>() { Color.green, Color.red, Color.blue, Color.black };
    List<Color> rgbHard = new List<Color>() { Color.green, Color.red, Color.blue, Color.black, Color.white, (Color.red + Color.gray), (Color.red + Color.blue), (Color.green + Color.blue) };

    List<Color> rybEasy = new List<Color>() { Color.red, new Color(1, 1, 0, 1), Color.blue, Color.white };
    List<Color> rybHard = new List<Color>() { Color.red, new Color(1, 1, 0, 1), Color.blue, Color.white, new Color(1, 0.5f, 0, 1), Color.black, Color.magenta, Color.green };

    void Awake()
    {
        waveCount = TestStartWave;
        Difficulty = PlayerPrefs.GetInt("Difficulty");
        PlayerPrefs.DeleteKey("Difficulty");
        if (Difficulty == 0)
        {
            ColorList = rybEasy;
        }
        else
        {
            ColorList = rybHard;
        }
    }
    // Use this for initialization
    void Start()
    {

    }

    IEnumerator SpawnWave()
    {
        startwave = false;
        StartCoroutine(ShowWaveText());
        yield return new WaitForSeconds(startWait);
        for (int i = 0; i < enemyCount; i++)
        {
            for (int x = 0; x < enemySpawnCount; x++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                GameObject go = Instantiate(enemy, spawnPosition, spawnRotation);
                int number = Random.Range(0, ColorList.Count);
                Color color = ColorList[number];
                color.a = 1;
                go.GetComponent<MeshRenderer>().material.color = color;
                go.GetComponent<BallColor>().ballColor = go.GetComponent<MeshRenderer>().material.color;
            }
            yield return new WaitForSeconds(spawnWait);
        }
        startWaveTimer = true;
        if (Difficulty == 0)
        {
            EasyWaveIncrement();
        }
        else HardWaveIncrement();
    }

    void EasyWaveIncrement()
    {
        waveCount++;
        Wavetext.text = "Wave: " + waveCount.ToString();

        if (waveCount % 2 == 0)
        {
            enemyCount += EasyInc.EnemyCountInc;
            EasyInc.EnemyCountInc++;
        }
        else
        {
            if (!(spawnWait < 0.2f))
            {
                spawnWait -= EasyInc.SpawnWaitInc;
            }
            if (TimeBetweenWaves != 0)
            {
                TimeBetweenWaves -= EasyInc.TimeBetweenWavesInc;
            }
            if (TimeBetweenWaves < 0)
            {
                TimeBetweenWaves = 0;
            }
        }
        if (waveCount % 5 == 0)
        {
            enemy.GetComponent<Moving>().EasySpeed += EasyInc.EnemySpeedInc;
        }
        if (waveCount % 10 == 0)
        {
            enemySpawnCount++;
        }
    }

    void HardWaveIncrement()
    {
        waveCount++;
        Wavetext.text = "Wave: " + waveCount.ToString();

        if (waveCount % 2 == 0)
        {
            enemyCount += HardInc.EnemyCountInc;
            HardInc.EnemyCountInc++;
        }
        else
        {
            if (!(spawnWait < 0.2f))
            {
                spawnWait -= HardInc.SpawnWaitInc;
            }
            if (TimeBetweenWaves != 0)
            {
                TimeBetweenWaves -= HardInc.TimeBetweenWavesInc;
            }
            if (TimeBetweenWaves < 0)
            {
                TimeBetweenWaves = 0;
            }
        }
        if (waveCount % 5 == 0)
        {
            enemy.GetComponent<Moving>().HardSpeed += HardInc.EnemySpeedInc;
        }
        if (waveCount % 10 == 0)
        {
            enemySpawnCount++;
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
        if (player.GetComponent<PlayerHealth>().CurrentHealth == 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    [System.Serializable]
    public class EasyIncrement
    {
        public float EnemySpeedInc;
        public int EnemyCountInc;
        public float TimeBetweenWavesInc;
        public float SpawnWaitInc;
    }

    [System.Serializable]
    public class HardIncrement
    {
        public float EnemySpeedInc;
        public int EnemyCountInc;
        public float TimeBetweenWavesInc;
        public float SpawnWaitInc;
    }
}


