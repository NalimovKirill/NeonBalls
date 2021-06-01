using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerBall : MonoBehaviour
{
    [SerializeField] private GameObject[] _ballsTemplate;
    [SerializeField] private Text _showCountOfBalls;
    [SerializeField] private InputField _fieldToWriteCount;

    [SerializeField] private GameObject _holderBalls;

    [SerializeField] private int _maxCount = 100;

    public int currentNumberOfBalls;
   
    private void LateUpdate()
    {
         _showCountOfBalls.text = "Количество шаров " + _holderBalls.transform.childCount.ToString();
        //_showCountOfBalls.text = "Количество шаров: " + currentNumberOfBalls;
    }

    public void AddBallButton()
    {
        int number = int.Parse(_fieldToWriteCount.text);

        if (number.GetType() == typeof(int))
        {
            int freeSpace = _maxCount - _holderBalls.transform.childCount;

            if (number > freeSpace)
            {
                number = freeSpace;
            }

            for (int i = 0; i < number; i++)
            {
                int index = Random.Range(0, _ballsTemplate.Length);
                Instantiate(_ballsTemplate[index], _holderBalls.transform);

               // currentNumberOfBalls++;
            }
        }
        else
        {
            print("Введите целое число");
        }

    }
}
