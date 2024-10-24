using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GarageDoorController : MonoBehaviour
{
    // Ссылка на компонент Animator для дверей
    public Animator doorAnimator;

    // Флаг для проверки состояния двери
    private bool isDoorOpen = false;

    void Update()
    {
        // Если игрок нажимает клавишу "F" на клавиатуре
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Переключаем анимацию открытия и закрытия
            if (isDoorOpen)
            {
                doorAnimator.Play("GarageDoorClose");
            }
            else
            {
                doorAnimator.Play("GarageDoorOpen");
            }
            isDoorOpen = !isDoorOpen;
        }
    }
}

