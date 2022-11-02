using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("������ ����� ��������")] TMPro.TMP_InputField speedinp;
    [SerializeField, Tooltip("������ ����� ����������")] TMPro.TMP_InputField distinp;
    [SerializeField, Tooltip("������ ����� ������� ����� ������")] TMPro.TMP_InputField timinp;
    [SerializeField, Tooltip("������ ������")] GameObject CubePrefab;
    [SerializeField, Tooltip("������ ���� �� �����")] GameObject menu;
    [SerializeField, Tooltip("������ ���� ������ �� �����")] GameObject ErrorMsg;
    [SerializeField, Tooltip("����� �� ������ �����/����")] TMPro.TMP_Text startstopfield;
    float speed = 0;
    float dist = 0;
    float tim = 0;

    float Timer = 0;
    bool IsRunning = false;

    void CheckProper(TMPro.TMP_InputField tExt)
    {
         tExt.text = tExt.text.Replace('.', ',');
    }
    public void StartGame()
    {
        if(IsRunning)
        {
            menu.SetActive(true);
            IsRunning = false;
            foreach (Cube cb in FindObjectsOfType<Cube>()) Destroy(cb.gameObject);
        }
        else
        {
            
            CheckProper(speedinp);
            CheckProper(distinp);
            CheckProper(timinp);
            if (float.TryParse(speedinp.text, out speed) & float.TryParse(distinp.text, out dist) & float.TryParse(timinp.text, out tim))
                if(speed > 0 & dist > 0 & tim > 0)
            {
                menu.SetActive(false);
                IsRunning = true;
                Timer = 0;
            }
            if(!IsRunning)
            {
                ErrorMsg.SetActive(true);
                menu.SetActive(false);
            }
        }
        startstopfield.text = (IsRunning) ? "����" : "�����";
    }

    void SpawnNew()
    {
        var scrpt = Instantiate(CubePrefab, transform.position, CubePrefab.transform.rotation).GetComponent<Cube>();
        scrpt.SetParams(dist, speed);
    }
    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    // Update is called once per frame
    void Update()
    {
        if(IsRunning)
        {
            Timer -= Time.deltaTime;
            if (Timer < 0)
            {
                Timer = tim;
                SpawnNew();
            }
        }
    }
}
