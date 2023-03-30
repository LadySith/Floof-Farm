using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mailbox : MonoBehaviour
{
    public Player player;
    public GameObject mailIcon;
    public Mail mailPrefab;

    public Sprite[] postcards = new Sprite[3]; //postcards[x], 0 = bunny, 1 = cat, 2 = fox
    public List<Mail> mail = new List<Mail>();

    public GameObject mailMenu;
    public int currentMail = 0;
    public Image currentImage;

    private SoundHandler sh;

    public bool deliveredBunny = false;
    public bool deliveredCat = false;
    public bool deliveredFox = false;

    private void Awake()
    {
        if (mail.Count > 0)
        {
            if (mail[currentMail].image != null)
            {
                currentImage.sprite = mail[currentMail].image;
            }

            else
            {
                currentImage.sprite = null;
            }
        }
        
        else
        {
            currentImage.sprite = null;
        }

        sh = player.GetComponent<SoundHandler>();
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
        if (player.canReach && player.itemsHeld.Count > 0 && player.selectedItem < player.itemsHeld.Count)
        {
            if (player.itemsHeld[player.selectedItem].floofType == FloofType.BUNNYTAIL && player.itemsHeld[player.selectedItem].growthStage == 3)
            {
                print("Delivered Bunny With CottonBall!");
                deliveredBunny = true;
                StartCoroutine(deliverFloof(player.itemsHeld[player.selectedItem]));
                player.itemsHeld.RemoveAt(player.selectedItem);
            }

            else if (player.itemsHeld[player.selectedItem].floofType == FloofType.CATSPJS && player.itemsHeld[player.selectedItem].growthStage == 3)
            {
                print("Delivered Cat In PJs!");
                deliveredCat = true;
                StartCoroutine(deliverFloof(player.itemsHeld[player.selectedItem]));
                player.itemsHeld.RemoveAt(player.selectedItem);
            }

            else if (player.itemsHeld[player.selectedItem].floofType == FloofType.FOXTAIL && player.itemsHeld[player.selectedItem].growthStage == 3)
            {
                print("Delivered Fox With Fluffy Tail!");
                deliveredFox = true;
                StartCoroutine(deliverFloof(player.itemsHeld[player.selectedItem]));
                player.itemsHeld.RemoveAt(player.selectedItem);
            }

            else
            {
                OpenMail();
            }
        }
    }

    IEnumerator deliverFloof(Collectible floof)
    {

        if (floof.floofType == FloofType.BUNNYTAIL)
        {
            Mail newMail = Instantiate(mailPrefab, new Vector3(0, 0, 20), Quaternion.identity);
            newMail.image = postcards[0];
            newMail.rend.enabled = false;
            mail.Add(newMail);
            yield return new WaitForSeconds(5f);
            
            mailIcon.SetActive(true);
            sh.PlayBell();
            print("Bouncy Postcard!");
        }

        else if (floof.floofType == FloofType.CATSPJS)
        {
            Mail newMail = Instantiate(mailPrefab, new Vector3(0, 0, 20), Quaternion.identity);
            newMail.image = postcards[1];
            newMail.rend.enabled = false;
            mail.Add(newMail);
            yield return new WaitForSeconds(5f);
            
            mailIcon.SetActive(true);
            sh.PlayBell();
            print("Purring Postcard?");
        }

        else if (floof.floofType == FloofType.FOXTAIL)
        {
            Mail newMail = Instantiate(mailPrefab, new Vector3(0, 0, 20), Quaternion.identity);
            newMail.image = postcards[2];
            newMail.rend.enabled = false;
            mail.Add(newMail);
            yield return new WaitForSeconds(5f);
            
            mailIcon.SetActive(true);
            sh.PlayBell();
            print("Fluffy Postcard!");
        }

        else
        {
            mailIcon.SetActive(false);
        }
    }


    IEnumerator postCardDelivery()
    {
        if (deliveredBunny == true || deliveredCat == true || deliveredFox == true)
        {
            yield return new WaitForSeconds(5f);
            mailIcon.SetActive(true);
            sh.PlayBell();
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
        if (currentMail <= 0)
        {
            currentMail = 0;
        }
        else
        {
            currentMail = mail.Count - 1;
        }
        currentImage.sprite = mail[currentMail].image;
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
            sh.PlayPage();
        }
    }

    public void Next()
    {
        if (currentMail < mail.Count - 1)
        {
            currentMail++;
            currentImage.sprite = mail[currentMail].image;
            sh.PlayPage();
        }

    }

    

}
