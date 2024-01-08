using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VongXoay : MonoBehaviour
{
    [SerializeField] Sprite[] imgPictures;
    [SerializeField] GameObject[] goImages;

    [SerializeField] Transform pStart;
    [SerializeField] Transform pEnd;

    [SerializeField] float speed;
    [SerializeField] float time = 3f;

    [SerializeField] ShowMessage txtInformation;
    string[] information = {
        "bạn có thể ghép đôi người chơi khác thành 1 cặp để kết nối sinh mệnh của họ với nhau",
        "ban có thể điều tra người chơi xem lượt đó họ đã thủ tiêu ai chưa",
        "bạn ăn xác chết để chiến thắng",
        "Bạn có thể dùng linh hồn đi xuyên tường",
        "Bạn đặt những quả bom hẹn giờ vào người hơi khác",
        "Bạn có thể thấy được người chơi khác đang đến gần",
        "bạn có thể tắt mic người chơi khác khi cuộc họp đang diễn ra",
        "bạn có thể biết số lượng hồn ma và cứu một người chơi ",
        "bạn có thể thủ tiêu một người chơi bất kì",
        "bạn có thể tàng hình",
        "sinh mệnh của cặp tình nhân gắn liền với nhau, 2 người chơi sẽ thắng nếu sống đến cuối cùng",
        "bạn có thể biến thành người chơi khác",
        "bạn có thể theo dấu một người chơi",
        "bạn có thể nhìn xuyên tường",
        "bạn chiến thắng nếu là người cuối cùng sống sót, bạn có thể nuốt toàn bộ người chơi mà không thấy xác cho đến khi bắt đầu cuộc họp"};
    int i;
    string[] phe = { "Chính diện", "Trung lập", "Phản diện" };
    int[] type = { 0, 0, 1, 0, 2, 0, 2, 0, 0, 2, 0, 2, 0, 0, 1 };
    private void Start()
    {
        i = 2;
        goImages[0].transform.GetComponent<Image>().sprite = imgPictures[0];
        goImages[1].transform.GetComponent<Image>().sprite = imgPictures[1];
    }
    // Update is called once per frame
    void Update()
    {
        if(time <= 0)
        {
            if(time > -10)
            {
                time = -11;
                End();
            }
            return;
        }
        UpdateCard(ref goImages[0]);
        UpdateCard(ref goImages[1]);
        speed+=10;
        time -= Time.deltaTime;
    }

    void UpdateCard(ref GameObject go)
    {
        go.transform.position = go.transform.position + new Vector3(0, -speed*Time.deltaTime, 0);
        if(go.transform.position.y <= pEnd.position.y)
        {
            go.transform.position = pStart.position;
            go.transform.GetComponent<Image>().sprite = imgPictures[i];
            i++;
            i %= imgPictures.Length;
        }
    }
    void End()
    {
        i = Random.Range(0, imgPictures.Length);
        pStart.GetComponent<Image>().sprite = imgPictures[i];
        transform.GetComponent<Animator>().SetTrigger("End");
    }
    public void Show()
    {
        txtInformation.transform.gameObject.SetActive(true);
        txtInformation.Show(information[i] + "\nPhe: " + phe[type[i]]);
    }
}
