using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mailbox : MonoBehaviour
{
    public Player player;
    public GameObject mailIcon;
    public Image[] postcards = new Image[3]; //postcards[x], 0 = bunny, 1 = cat, 2 = fox
    public List<Mail> mail = new List<Mail>();
    public GameObject mailMenu;
    public int currentMail = 0;
    public Image currentImage;

    public bool deliveredBunny = false;
    public bool deliveredCat = false;
    public bool deliveredFox = false;

    private void Awake()
    {
        if (mail[currentMail].image != null)
        {
            currentImage.sprite = mail[currentMail].image;
        } else
        {
            currentImage.sprite = null;
        }
    }

    private void Update()
    {
        if (currentMail >= mail.Count)
        {
            currentMail = mail.Count;
        }

        if (currentMail < 0)
        {
            currentMail = 0;
        }
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        OpenMail();

        if (player.canReach && player.itemsHeld.Count > 0 && player.selectedItem < player.itemsHeld.Count)
        {
            if (player.itemsHeld[player.selectedItem].floofType == FloofType.BUNNYTAIL && player.itemsHeld[player.selectedItem].growthStage == 3)
            {
                print("Delivered Bunny With CottonBall!");
                player.itemsHeld.RemoveAt(player.selectedItem);
                deliveredBunny = true;
                StartCoroutine(postCardDelivery());
            }

            else if (player.itemsHeld[player.selectedItem].floofType == FloofType.CATSPJS && player.itemsHeld[player.selectedItem].growthStage == 3)
            {
                print("Delivered Cat In PJs!");
                player.itemsHeld.RemoveAt(player.selectedItem);
                deliveredCat = true;
                StartCoroutine(postCardDelivery());
            }

            else if (player.itemsHeld[player.selectedItem].floofType == FloofType.FOXTAIL && player.itemsHeld[player.selectedItem].growthStage == 3)
            {
                print("Delivered Fox With Fluffy Tail!");
                player.itemsHeld.RemoveAt(player.selectedItem);
                deliveredFox = true;
                StartCoroutine(postCardDelivery());
            }
        }
    }


    IEnumerator postCardDelivery()
    {
        if (deliveredBunny == true || deliveredCat == true || deliveredFox == true)
        {
            yield return new WaitForSeconds(5f);
            mailIcon.SetActive(true);
            print("Postcard!");
        }

        else
        {
            mailIcon.SetActive(false);
        }
    }

    public void OpenMail()
    {
        Time.timeScale = 0;
        mailMenu.SetActive(true);
    }

    public void CloseMail()
    {
        mailMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Previous()
    {
        if (currentMail > 0)
        {
            currentMail--;
            currentImage.sprite = mail[currentMail].image;
        }
    }

    public void Next()
    {
        if (currentMail < mail.Count - 1)
        {
            currentMail++;
            currentImage.sprite = mail[currentMail].image;
        }
        
    }
    
}
