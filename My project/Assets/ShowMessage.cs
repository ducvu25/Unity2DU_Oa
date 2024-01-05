using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowMessage : MonoBehaviour
{
    TextMeshProUGUI txtMes;
    public float delay = 0.1f; // Thời gian trễ giữa các ký tự

    public void Show(string mes)
    {
        txtMes = GetComponent<TextMeshProUGUI>();
        StartCoroutine(ShowHelper(mes));
        txtMes.text = "";
    }
    public void ShowLoop(string mes)
    {
        txtMes = GetComponent<TextMeshProUGUI>();
        StartCoroutine(ShowHelperLoop(mes));
        txtMes.text = "";
    }

    private IEnumerator ShowHelper(string mes)
    {
        float elapsedTime = 0f;
        int i = 0;

        while (i < mes.Length)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= delay)
            {
                string _mes = mes.Substring(0, i + 1) + (i == mes.Length - 1 ? "" : "_");
                txtMes.text = _mes;
                i++;
                elapsedTime = 0f;
            }

            yield return null;
        }
    }
    private IEnumerator ShowHelperLoop(string mes)
    {
        float elapsedTime = 0f;
        int i = 0;

        while (i < mes.Length)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= delay)
            {
                string _mes = mes.Substring(0, i + 1);
                txtMes.text = _mes;
                i = (i+1) % mes.Length;
                elapsedTime = 0f;
            }

            yield return null;
        }
    }
}