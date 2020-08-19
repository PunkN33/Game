using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
public class Compass : MonoBehaviour
{
	public RawImage compassImage;
	public Transform player;
	public GameObject iconPrefab;
	List<QuestMarker> questMarkers = new List<QuestMarker>();
    public QuestMarker one;
    public QuestMarker two;
    public QuestMarker three;
    public QuestMarker four;
    public QuestMarker five;
    public QuestMarker six;
    public QuestMarker seven;
    public QuestMarker eight;
    public QuestMarker nine;
    public QuestMarker ten;
    public float maxDistance = 500f;
    private float _compassUnit;

    private void Start()
    {
        _compassUnit = compassImage.rectTransform.rect.width / 360f;

        AddQuestMarker(one);
        AddQuestMarker(two);
        AddQuestMarker(three);
        AddQuestMarker(four);
        AddQuestMarker(five);
        AddQuestMarker(six);
        AddQuestMarker(seven);
        AddQuestMarker(eight);
        AddQuestMarker(nine);
        AddQuestMarker(ten);
}

	public void Update()
	{
		compassImage.uvRect = new Rect(player.localEulerAngles.y / 360, 0, 1, 1);

		foreach(QuestMarker marker in questMarkers)
		{
			marker.image.rectTransform.anchoredPosition = GetPosOnCompass(marker);
			float dst = Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.z), marker.position);
			float scale = 0.1f;           
			if(dst<maxDistance)
			{
				scale = 1f - (dst / maxDistance);
			}
			marker.image.rectTransform.localScale = Vector3.one * scale;
		}
	}

	public void AddQuestMarker(QuestMarker marker)
	{
        if (marker != null)
        {
            GameObject newMarker = Instantiate(iconPrefab, compassImage.transform);
            marker.image = newMarker.GetComponent<Image>();
            marker.image.sprite = marker.icon;

            questMarkers.Add(marker);
        }
        if (marker == null)
        {
            questMarkers.Remove(marker);
        }

    }

	Vector2 GetPosOnCompass(QuestMarker marker)
	{
		Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.z);
		Vector2 playerFrw = new Vector2(player.transform.forward.x, player.transform.forward.z);

		float angle = Vector2.SignedAngle(marker.position - playerPos, playerFrw);

		return new Vector2(_compassUnit * angle, 0f);
	}
}