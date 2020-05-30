﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Klad_Up : MonoBehaviour
{
    private GameObject data;
    TreasureEditor treasureEditor;
    GameObject dog;//псина
    public GameObject rad1;//полоски радара
    public GameObject rad2;
    public GameObject rad3;
    public GameObject rad4;
    public static int podnatoKladov = 0;
    public GameObject PurseOnTheDog;
    public GameObject HatOnTheDogLeather;
    public GameObject HatOnTheDogStraw;
  //  [HideInInspector]
    public bool isCarringObject = false;
    private void Start()
    {
        dog = GameObject.Find("Dog");
        data = GameObject.Find("Data");
        treasureEditor = data.GetComponent<TreasureEditor>();
    }
    private void OnTriggerEnter(Collider other)//зона на которой происходт потбор предмета
    {   if (treasureEditor.purse == false && treasureEditor.amulet == false)//если не подобран кошель
        {
            if (other.gameObject.tag == "Klad")//проверяем этот ли клад по тегу
            {
                if(other.gameObject.CompareTag("Klad")) AutoAllocator.currentPointsAmmountOnTheField--;
                Destroy(other.gameObject);//уничтажаем клад
                podnatoKladov++;
                if (treasureEditor.toStage1 < podnatoKladov || treasureEditor.toStage1 == 0)
                {
                    treasureEditor.Stages();//метод рандомного клада
                }
                else
                {
                    treasureEditor.bone = true;
                    treasureEditor.score = treasureEditor.score + 25;
                }
                Debug.Log("Очки "+podnatoKladov);
                Debug.Log("Кость " + treasureEditor.bone);
                Debug.Log("Золотая кость " + treasureEditor.goldenBone);
                Debug.Log("Кошелек " + treasureEditor.purse);
                Debug.Log("Амулет " + treasureEditor.amulet);
                treasureEditor.bone = false;
                treasureEditor.goldenBone = false;
                dog.gameObject.GetComponent<Joystic_touch>().enabled = false;//отключаем передвежение для анимации
                Invoke("Timef", 2);//запускаем метод через две секунды (если примерно столько будет анимация)
            }
        }
        

    }
        public void Timef()//метод при котором мы включаем управление и убираем полоски радара
        {
        dog.gameObject.GetComponent<Joystic_touch>().enabled = true;
        if (rad1.activeSelf)
        {
            rad1.SetActive(false);
        }
        if (rad2.activeSelf)
        {
            rad2.SetActive(false);
        }
        if (rad3.activeSelf)
        {
            rad3.SetActive(false);
        }
        if (rad4.activeSelf)
        {
            rad4.SetActive(false);
        }
        }
    public void purse()
    {
        int dos = 0;
        dos = Random.Range(0, 100);
        if (treasureEditor.purse == true && !isCarringObject && dos <= 50)
        {
            isCarringObject = true;
            PurseOnTheDog.SetActive(true);
        }
        if (treasureEditor.purse == true && !isCarringObject && dos >= 50)
        {
            isCarringObject = true;
            int dosc = 0;
            dosc = Random.Range(0, 100);
            if (dosc >= 50)
            {
                HatOnTheDogStraw.SetActive(true);
            }
            else
            {
                HatOnTheDogLeather.SetActive(true);
            }
        }
    }
}
