using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeLider : MonoBehaviour
{
    public TextMeshProUGUI textTime;
    public float timiLiderBoard;

    private void Start()
    {
        /// Сохранение добавить
    }
    void Update()
    {
        timiLiderBoard += Time.deltaTime;

        textTime.text = Mathf.Round(timiLiderBoard).ToString();
    }
}
