using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class WorldController : MonoBehaviour
    {
		public static Action OnWorldGenerate;

		public static WorldController Instance => instance;

		private static WorldController instance;

        [SerializeField] private List<Tile> tilePrefabs = new List<Tile>();
		[SerializeField] private int worldSize;
		[SerializeField] private float perlinScale;
		[SerializeField] private GameObject playerPrefab;

		private Tile[,] tiles;
		private Vector2 offset;

		private void Awake()
		{
			instance = this;
		}

		private void Start()
		{
			offset = new Vector2(Random.Range(-1000, 1000), Random.Range(-1000, 1000));
			StartCoroutine( InitWorld() );
			//Camera.main.transform.position = new Vector3(worldSize / 2, worldSize / 2, -10);
			//Camera.main.orthographicSize = worldSize / 2f;
		}

		private IEnumerator InitWorld()
		{
			tiles = new Tile[worldSize,worldSize];
			Camera cam = FindFirstObjectByType<Camera>();
			cam.transform.position = new Vector3(worldSize / 2f, worldSize / 2f, -10f);
			cam.orthographicSize = worldSize / 2f;

			//Generate world
			for(int x = 0; x < worldSize; x++)
			{
				for(int y = 0; y < worldSize; y++)
				{
					int t = Mathf.Clamp(Mathf.RoundToInt(Mathf.PerlinNoise((offset.x + x) * perlinScale, (offset.y + y) * perlinScale) * tilePrefabs.Count), 0, tilePrefabs.Count-1);
					tiles[x, y] = Instantiate(tilePrefabs[t], new Vector3(x, y, 0), Quaternion.identity);
				}
				yield return null;
			}

			GameObject p = Instantiate(playerPrefab);
			while (cam.orthographicSize > 10)
			{
				cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5, Time.deltaTime * 2f);
				cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(p.transform.position.x, p.transform.position.y, -10), Time.deltaTime * 4);
				yield return null;
			}
			cam.transform.SetParent(p.transform);
			OnWorldGenerate?.Invoke();
		}

		public Vector3 GetWalkablePosition(Vector2 normalizedPositionFromCenter)
		{
			float closestDist = Mathf.Infinity;
			Vector3 closestPos = Vector3.zero;

			for (int x = 0; x < worldSize; x++)
			{
				for (int y = 0; y < worldSize; y++)
				{
					if (tiles[x, y].Effect == ETileEffect.Blocking || tiles[x,y].Effect == ETileEffect.Kill) continue;

					float d = (tiles[x, y].transform.position - new Vector3(worldSize * normalizedPositionFromCenter.x, worldSize * normalizedPositionFromCenter.y, 0)).sqrMagnitude;
					if(d < closestDist) 
					{
						closestDist = d;
						closestPos = tiles[x, y].transform.position;
					}
				}
			}
			return closestPos;
		}
		public Vector3 GetPositionOfType(Vector2 normalizedPositionFromCenter, ETileEffect[] tileTypes)
		{
			float closestDist = Mathf.Infinity;
			Vector3 closestPos = Vector3.zero;
			for (int x = 0; x < worldSize; x++)
			{
				for (int y = 0; y < worldSize; y++)
				{
					for (int i = 0;  i < tileTypes.Length; i++)
					{
						if (tiles[x, y].Effect == tileTypes[i])
						{
							float d = (tiles[x, y].transform.position - new Vector3(worldSize * normalizedPositionFromCenter.x, worldSize * normalizedPositionFromCenter.y, 0)).sqrMagnitude;
							if (d < closestDist)
							{
								closestDist = d;
								closestPos = tiles[x, y].transform.position;
							}
							break;
						}
					}
				}
			}
			return closestPos;
		}

	}
}