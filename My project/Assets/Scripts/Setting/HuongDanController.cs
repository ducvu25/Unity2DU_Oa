using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuongDanController : MonoBehaviour
{
    string[] mes = { "Sử dụng phím mũi tên sang trái/phải hoặc phím A/D để di chuyển sang trái hoặc phải.",
                     "Sử dụng phím mũi tên lên/xuống hoặc phím W/S để di chuyển lên hoặc xuống.",
                     "Nếu bạn là \"Kẻ ngoại lai\" hãy sử dụng phím R để tấn công người chơi.",
                     "Nhiệm vụ của người chơi là hoàn thành các nhiệm vụ trong bản đồ hoặc tìm ra \"Kẻ ngoại lai\"."};
    public float[] time;
    [SerializeField] ShowMessage showMessage;
    [SerializeField] GameObject goHuongDan;
    float _time;
    int i;
    public bool check = false;
    // Start is called before the first frame update
    void Start()
    {
        _time = 0;
        i = 0;
        goHuongDan.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (i == time.Length || goHuongDan.activeSelf || !check) return;
        _time += Time.deltaTime;
        if(_time >= time[i])
        {
            SetActive();
            showMessage.Show(mes[i]);
            i++;
        }
        //Debug.Log(_time);
    }
    public void SetActive()
    {
        goHuongDan.SetActive(!goHuongDan.activeSelf);
    }
    public void Check()
    {
        check = true;
    }
}
