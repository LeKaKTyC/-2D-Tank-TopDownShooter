using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    [SerializeField] private Text _hpText;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _lvlText;

    public void UpdateLvlAndScore()
    {
        _lvlText.text = $"Level {Stats.Level}";
        _scoreText.text = $"Score: " + Stats.Score.ToString("D4"); // 23 => 0023 // change basic format with D4
    }

    public void UpdateHP(int hp)
    {
        _hpText.text = $"HP = {hp}";
    }
}
