using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value = 100;
    public RectTransform valueRectTransform;
    public GameObject gameplayUI;
    public GameObject gameoverScene;

    private float _maxValue;



    void Start()
    {
        _maxValue = value;
        DrawHealthBar();
    }
    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            PlayerIsDead()
  ;
        }

        DrawHealthBar();
    }
    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);
    }
    private void PlayerIsDead()
    {
        gameplayUI.SetActive(false);
        gameoverScene.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireBallCasterr>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;

    }
}
