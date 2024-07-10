using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HeartController : MonoBehaviour
{
    public GameObject[] heart;
    //public TextMeshPro points;
    void Update()
    {
        //points.text = GameManager.Instance.TotalPoints.ToString();
    }
    /*
        public void UpdatePoints(int totalPoints)
        {
            points.text = totalPoints.ToString();
        }*/

    public void DisableHeart(int i)
    {
        heart[i].SetActive(false);
    }

    public void ActiveHeart(int i)
    {
        heart[i].SetActive(true);
    }
}
