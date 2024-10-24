using UnityEngine;
using System.Collections;

public class AutoMoveToPickup : MonoBehaviour
{
    // Ссылка на объект, куда перемещать предметы (точка багажника пикапа)
    public Transform pickupTruck;

    // Смещение между предметами по осям X и Z
    public Vector3 gridOffset = new Vector3(0.2f, 0, 0.2f);

    // Количество предметов в одном ряду
    public int itemsPerRow = 3;

    // Задержка перед перемещением (в секундах)
    public float delay = 2f;

    // Статические переменные для отслеживания текущей позиции в сетке
    private static int currentItemIndex = 0;
    private static Vector3 cumulativeOffset = Vector3.zero;

    void Start()
    {
        // Начинаем корутину для перемещения с задержкой
        StartCoroutine(MoveAfterDelay());
    }

    // Корутина для перемещения объекта после задержки
    IEnumerator MoveAfterDelay()
    {
        // Ждем указанное время (delay)
        yield return new WaitForSeconds(delay);

        // Перемещаем объект в сетку
        MoveToGridPosition();
    }

    // Функция для перемещения предмета на его позицию в сетке
    void MoveToGridPosition()
    {
        // Рассчитываем позицию для текущего предмета на основе его индекса
        int row = currentItemIndex / itemsPerRow;    // Какой это ряд
        int col = currentItemIndex % itemsPerRow;    // Какой это столбец

        // Определяем новую позицию с учётом смещения по X и Z
        Vector3 targetPosition = pickupTruck.position + new Vector3(col * gridOffset.x, 0, row * gridOffset.z);

        // Перемещаем объект в вычисленную точку
        transform.position = targetPosition;

        // Увеличиваем индекс для следующего предмета
        currentItemIndex++;
    }
}
