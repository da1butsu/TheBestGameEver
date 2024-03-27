using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    public List<PlayerProgressLevel> level;
    public RectTransform experienceValueRectTransform;
    private int _levelValue = 1;
    public TextMeshProUGUI levelValueTMP;

    private float _experienceCurrentValue = 0;
    private float _experienceTargetValue = 100;

    public void addExpereence(float value)
    {
        _experienceCurrentValue += value;

        if(_experienceCurrentValue >= _experienceTargetValue)
        {
            SetLevel(_levelValue + 1);
            _experienceCurrentValue = 0;
        }
        DrawUI();
    }

    private void SetLevel(int value)
    {
        _levelValue = value;

        var currentLevel = level[_levelValue - 1];
        _experienceTargetValue = currentLevel.experienceForNextLevel;
        GetComponent<FireBallCasterr>().damage = currentLevel.fireballDamage;

        var granadeCaster = GetComponent<GrenadeCaster>();
        granadeCaster.damage = currentLevel.grenadeDamage;

        if (currentLevel.grenadeDamage < 0)
            granadeCaster.enabled = false;
        else
            granadeCaster.enabled = true;
            
        


    }
         
    private void DrawUI()
    {
        experienceValueRectTransform.anchorMax = new Vector2(_experienceCurrentValue / _experienceTargetValue, 1);
        levelValueTMP.text = _levelValue.ToString();
    }

    private void Start()
    {
        SetLevel(_levelValue);
        DrawUI();
        
    }

}
