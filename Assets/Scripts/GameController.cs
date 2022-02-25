using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameController : MonoBehaviour
{
    public static GameController instance; // singleton yapisi icin gerekli ornek ayrintilar icin BeniOku 22. satirdan itibaren bak.


    [HideInInspector]public int score, elmas; // ayrintilar icin benioku 9. satirdan itibaren bak

    [HideInInspector] public bool isContinue;  // ayrintilar icin beni oku 19. satirdan itibaren bak

    public int collectingCount = 0;
    public Transform goldTarget;


    private void Awake()
	{
        if (instance == null) instance = this;
        //else Destroy(this);
	}

	void Start()
    {
        isContinue = false;
    }


    /// <summary>
    /// Bu fonksiyon geçerli leveldeki scoreu belirtilen miktarda artirir veya azaltir. Artirma icin +5 gibi pozitif eksiltme
    /// icin -5 gibi negatif deger girin.
    /// </summary>
    /// <param name="eklenecekScore">Her collectible da ne kadar score eklenip cikarilacaksa parametre olarak o sayi verilmeli</param>
    public void SetScore(int eklenecekScore)
	{
        score += eklenecekScore;
        UIController.instance.SetGamePlayScoreText();
        // Eðer oyunda collectible yok ise developer kendi score sistemini yazmalý...

    }


    /// <summary>
    /// Bu fonksiyon geçerli leveldeki elmasi belirtilen miktarda artirir veya azaltir. Artirma icin +5 gibi pozitif eksiltme
    /// icin -5 gibi negatif deger girin.
    /// </summary>
    /// <param name="eklenecekElmas">Her collectible da ne kadar elmas eklenip cikarilacaksa parametre olarak o sayi verilmeli</param>
    public void SetElmas(int eklenecekElmas)
    {
        elmas += eklenecekElmas;
        // buradaki elmas artýnca totalScore da otomatik olarak artacak.. bu sebeple asagidaki kodlar eklendi.
        PlayerPrefs.SetInt("totalElmas", PlayerPrefs.GetInt("totalElmas" + eklenecekElmas));
       // UIController.instance.SetTotalElmasText(); // totalElmaslarýn yazili oldugu texti
    }


    /// <summary>
    /// Oyun sonu x ler hesaplanip kac ile carpilacaksa parametre olacak o sayi gonderilmeli.
    /// </summary>
    /// <param name="katsayi"></param>
    public void ScoreCarp(int katsayi)
	{      
        score = 1 * score;
        PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("totalScore") + score);
    }



    public void CheckCollector()
	{

        isContinue = false;
        DrawMeshSbi.instance.DeleteAllMesh();
        DrawMeshSbi.instance.ActivateDrawing();
	}

    public void FinalEvents()
	{
        ScoreCarp(1);
        isContinue = false;
        DrawMeshSbi.instance.isDrawable = false;
        UIController.instance.ActivateWinScreen();
    }

}
