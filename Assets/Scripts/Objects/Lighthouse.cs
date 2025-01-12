using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lightgouse : MonoBehaviour
{
    [SerializeField] private Light2D _light;

    private PolygonCollider2D _lightPolygonCollider;
    private List<Collider2D> _turretSpots;

    private void Awake()
    {
        _lightPolygonCollider = _light.GetComponent<PolygonCollider2D>();
        _lightPolygonCollider.OverlapCollider(new ContactFilter2D().NoFilter(), _turretSpots);
    }

    private void OnMouseDown()
    {
    }
}
