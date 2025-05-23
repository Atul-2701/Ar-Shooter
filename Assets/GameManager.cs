using BigRookGames.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [SerializeField] GameObject target;
    public Scrollbar xAxis;
    public Scrollbar yAxis;
    public Scrollbar Distance;
    public Vector3 position { get; private set; }

    [SerializeField] Text xValue;
    [SerializeField] Text yValue;
    [SerializeField] Text distanceValue;

    [SerializeField] GameObject menuPanel;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3();
        xAxis.value = 0.5f;
        yAxis.value = 0.5f;
        Distance.value = 0.4f;
        UpdateValue();
        xAxis.onValueChanged.AddListener(delegate { UpdateValue(); });
        yAxis.onValueChanged.AddListener(delegate { UpdateValue(); });
        Distance.onValueChanged.AddListener(delegate { UpdateValue(); });
        Instantiate(target, Boundary(xAxis.value, xAxis.value, Distance.value), Quaternion.identity);
    }

    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<GameManager>();
            if (instance == null)
            {
                Debug.LogError("No GameManager found in scene. Please add one to the scene.");
            }
        }
        return instance;
    }
    public void CloseAndOpenMenu()
    {
        if (menuPanel.activeInHierarchy)
        {
            menuPanel.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            menuPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void UpdateValue()
    {
        position = Boundary(xAxis.value, xAxis.value, Distance.value);
        xValue.text = ((int)(xAxis.value * 10f)).ToString();
        yValue.text = ((int)(yAxis.value * 10f)).ToString();
        distanceValue.text = ((int)(Distance.value * 15f)).ToString();
        Debug.Log(position + "hdfxcjdsfjhdsjkfh");
        return;
    }

    public Vector3 Boundary(float xAxis, float yAxis, float Distance)
    {
        Vector3 SpawnPoint = new Vector3(Random.Range(xAxis, -xAxis) * 10f, Random.Range(yAxis, -yAxis) * 10f, Distance * 15f);
        return SpawnPoint;
    }
}