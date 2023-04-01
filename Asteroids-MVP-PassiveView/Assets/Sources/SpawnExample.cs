using UnityEngine;
using Asteroids.Model;

public class SpawnExample : MonoBehaviour
{
    [SerializeField] private PresentersFactory _factory;
    [SerializeField] private Root _init;
    [SerializeField] private float _radius = 0.5f;

    private int _index;
    private float _secondsPerIndex = 1f;
    private Nlo _leftNlo;
    private Nlo _rightNlo;

    private void Update()
    {
        int newIndex = (int)(Time.time / _secondsPerIndex);

        if (newIndex > _index)
        {
            _index = newIndex;
            OnTick();
        }
    }

    private void OnTick()
    {
        float chance = Random.Range(0, 100);

        if (chance < 40)
        {
            _leftNlo = new Nlo(_rightNlo, GetRandomPositionInsideScreen(), Config.NloSpeed);
            _rightNlo = new Nlo(_leftNlo, GetRandomPositionInsideScreen(), Config.NloSpeed);
            _leftNlo.Target = _rightNlo;
            _factory.CreateNlo(_leftNlo);
            _factory.CreateNlo(_rightNlo);
        }
        else
        {
            Vector2 position = GetRandomPositionOutsideScreen();
            Vector2 direction = GetDirectionThroughtScreen(position);

            _factory.CreateAsteroid(new Asteroid(position, direction, Config.AsteroidSpeed));
        }
    }

    private Vector2 GetRandomPositionOutsideScreen()
    {
        return Random.insideUnitCircle.normalized + new Vector2(0.5F, 0.5F);
    }
    
    private Vector2 GetRandomPositionInsideScreen()
    {
        return Random.insideUnitCircle.normalized * _radius + new Vector2(0.5F, 0.5F);
    }

    private static Vector2 GetDirectionThroughtScreen(Vector2 postion)
    {
        return (new Vector2(Random.value, Random.value) - postion).normalized;
    }
}