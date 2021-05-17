using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGeneration : MonoBehaviour
{
    [SerializeField] GameObject car;
    [SerializeField] GameObject topGround;
    [SerializeField] GameObject botGround;
    [SerializeField] GameObject groundPanel;
    // Start is called before the first frame update
    void Start()
    {
        Generate(topGround);
        Generate(botGround);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Generate cars for each ground
    /// </summary>
    /// <param name="parent"></param>
    void Generate(GameObject parent)
    {
        Rect ground = parent.transform.GetComponent<RectTransform>().rect;
        Rect carRect = car.transform.GetComponent<RectTransform>().rect;
        int height = Mathf.CeilToInt(ground.height);
        int width = Mathf.CeilToInt(ground.width);
        int numCarInARow = Mathf.CeilToInt((width - 40) / (carRect.width + 15));
        for (int roww = 0; roww < 3; roww++)
        {
            for (int col = 0; col < numCarInARow; col++)
            {
                int x = col * 35 + 30;
                int y = -30 - roww * 60;
                Vector3 pos = new Vector3(x, y, 0);
                GameObject carClone = Instantiate(car, Vector3.zero, Quaternion.identity);
                carClone.transform.localPosition = pos;
                carClone.transform.SetParent(parent.transform, false);
                carClone.transform.SetParent(groundPanel.transform);
            }
        }
    }
}
