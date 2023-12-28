using UnityEngine;
using UnityEngine.Video;
using System.Collections;
using UnityEngine.SceneManagement;

public class MyVideoPlayer : MonoBehaviour
{

    public GameObject cinemaPlane; // экран видко
    public GameObject btnPlay; // кнопка старта
    public GameObject btnPause; // кнопка паузы
    public GameObject knob; // бегунок
    public GameObject progressBar; // текуший уровень прогресса видео
    public GameObject progressBarBG; // задний фон прогреса видео

    private float maxKnobValue; // максимальное значение, до которого може дойти ползунок
    private float newKnobX; // новая позиция ползунка по оси X
    private float maxKnobX; // максимальная позиция ползунка по оси X
    private float minKnobX; // минимальная позиция ползунка по оси X
    private float knobPosY; // позиция ползунка по оси Y.
    private float simpleKnobValue; // упрощенное значение ползунка
    private float knobValue; // значение ползунка
    private float progressBarWidth; // размер 
    private bool knobIsDragging; // флажок на смещение ползунка 
    private bool videoIsJumping = false; // флажок на перемешение ползунка и изменение кадра видео
    private bool videoIsPlaying = true; // флажок на отображение кнопки и запуска видео
    private VideoPlayer videoPlayer; // видео плеер к которму применён скрипт 
    private bool videolastpos; // флажок на проверку последнего состояния плеера
    
    // обрабатываем, что происходит при открытии сцены
    private void Start  ()
    {
        knobPosY = knob.transform.localPosition.y; // задаём позицию ползунка по y
        videoPlayer = GetComponent<VideoPlayer>(); // приводим gameobject к videoplayer
        btnPause.SetActive(true); // делаем видимым кнопку паузы
        btnPlay.SetActive(false); // делаем видимым кнопку старта
        videoPlayer.frame = (long)100; // перемешаемся в начало видео
        // вычисляем ширину полоски прогресса
        progressBarWidth = progressBarBG.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // обрабатываем, что происходит каждый кадр
    private void Update()
    {
        // проверяем, не перетаскивается ли ползунок или не происходит ли перемещение видео
        if (!knobIsDragging && !videoIsJumping)
        {
            // проверяем, есть ли кадры в видеоплеере
            if (videoPlayer.frameCount > 0)
            {
                // обновляем положение ползунка и прогресса видео в соответствии с текущим кадром видео.

                // находим какой "процент" кадро прошёл
                float progress = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
                // изменяем значение полоски прогресса видео в соотв. с progress
                progressBar.transform.localScale = new Vector3(progressBarWidth * progress, progressBar.transform.localScale.y, 0);
                // изменяем позицию ползунка
                knob.transform.localPosition = new Vector2(progressBar.transform.localPosition.x + (progressBarWidth * progress), knob.transform.localPosition.y);
            }
        }
        // проверяем, была ли нажата левая кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            // получаем позицию курсора
            Vector3 pos = Input.mousePosition;
            Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));

            // проверяем, попадает ли он на кнопку паузы или кнопку старта
            if (hitCollider != null && (hitCollider.CompareTag(btnPause.tag)) || hitCollider.CompareTag(btnPlay.tag))
                BtnPlayVideo(); 
            //// проверяем, попадает ли он на кнопку старта
            //if (hitCollider != null && )
            //{
            //    BtnPlayVideo();
            //}
        }
    }

    // функция при нажатии на бегунок
    public void KnobOnPressDown()
    {
        VideoStop(); // останавливаем видео
        // находим минимальную позицию ползунка по X
        minKnobX = progressBar.transform.localPosition.x;
        // находим максимальную позицию ползунка по X
        maxKnobX = minKnobX + progressBarWidth;
    }

    // функция при отпускании бегкнка
    public void KnobOnRelease()
    {
        knobIsDragging = false;
        CalcKnobSimpleValue(); // изменям значение ползунка
        if (videolastpos) // если плеер был запущен (находился в режиме проигрывания)
            VideoPlay(); // запускаем видео
        VideoJump(); // заменяем кадр
        // Метод StartCoroutine используется для запуска
        // корутины в Unity. Корутина - это специальный тип метода,
        // который позволяет выполнять асинхронные операции в игре.
        // В данном случае, мы запускаем корутину DelayedSetVideoIsJumpingToFalse
        StartCoroutine(DelayedSetVideoIsJumpingToFalse()); 
    }

    IEnumerator DelayedSetVideoIsJumpingToFalse()
    {
        yield return new WaitForSeconds(2); // вызываем ожидание
        SetVideoIsJumpingToFalse(); // запрещаем перемещать кадры
    }

    // функция при перетаскивании бегунка
    public void KnobOnDrag()
    {
        knobIsDragging = true; // разрешаем перетаскивание ползунка
        videoIsJumping = true; // разрешаем смену кадров
        // запоминаем позицию мыши в вектор
        Vector3 curScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        // изменяем позицию бегунка
        knob.transform.position = new Vector2(curPosition.x, curPosition.y);
        // задаём новую позицию бегунка в соответствие с его локацией
        newKnobX = knob.transform.localPosition.x;
        // проверяем позицию на макс и мин значение
        if (newKnobX > maxKnobX) { newKnobX = maxKnobX; }
        if (newKnobX < minKnobX) { newKnobX = minKnobX; }
        knob.transform.localPosition = new Vector2(newKnobX, knobPosY);
        CalcKnobSimpleValue(); // смотрим сколько от видео прошло
        // обновляем положение полоски прогресса видео
        progressBar.transform.localScale = new Vector3(simpleKnobValue * progressBarWidth, progressBar.transform.localScale.y, 0);
    }

    private void SetVideoIsJumpingToFalse()
    {
        // переводим возможность перемешения кадра в ложное состояние
        videoIsJumping = false;
    }

    private void CalcKnobSimpleValue()
    {
        // метод, вычисляющий упрощенное значение ползунка
        maxKnobValue = maxKnobX - minKnobX; // вычисляем максимальное значение
        knobValue = knob.transform.localPosition.x - minKnobX; // находим
                                                               // текушее значение
        simpleKnobValue = knobValue / maxKnobValue; 
        // находим, Сколько "процентов" от видео прошло
    }

    private void VideoJump()
    {
        // метод, перемещающий видео на определенный кадр
        // в соответствии с положением ползунка.
        var frame = videoPlayer.frameCount * simpleKnobValue;
        videoPlayer.frame = (long)frame;
    }


    private void BtnPlayVideo()
    {
        // в зависимости от флажка или ставим
        // видео на паузу, или запускаем его
        if (videoIsPlaying)
        {
            VideoStop();
        }
        else
        {
            VideoPlay();
        }
    }

    private void VideoStop()
    {
        videolastpos = videoIsPlaying;
        videoIsPlaying = false; // меняем флажок 
        videoPlayer.Pause(); // ставим видео на паузу
        btnPause.SetActive(false); // скрываем кнпоку паузы
        btnPlay.SetActive(true); // отображаем кнпоку запуска
    }

    private void VideoPlay()
    {
        videolastpos = videoIsPlaying;
        videoIsPlaying = true; // меняем флажок 
        videoPlayer.Play(); // снимаем видео с паузы
        btnPause.SetActive(true); // отображаем кнпоку паузы
        btnPlay.SetActive(false); // скрываем кнопку запуска
    }
}
