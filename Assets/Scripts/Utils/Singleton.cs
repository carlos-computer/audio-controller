using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

#region Fields
	
	private static T _instance;
	private static bool _applicationIsQuitting = false;

#endregion

#region Properties
	

	public static T Instance
	{
		get
		{
			if (_applicationIsQuitting)
			{
				Debug.LogWarning($"[Singleton] Instancia de {nameof(T)} ya no está disponible porque el juego está cerrándose.");
				return null;
			}

			if (_instance == null)
			{
				// Busca una instancia existente
				_instance = FindObjectOfType<T>();

				if (_instance == null)
				{
					// Crea un nuevo GameObject si no existe uno en la escena
					GameObject singletonObject = new ($"{nameof(T)} (Singleton)");
					_instance = singletonObject.AddComponent<T>();
				}
			}

			return _instance;
		}
	}

#endregion

#region Unity Methods
	
	protected virtual void Awake()
	{
		if (_instance == null)
		{
			_instance = this as T;
			DontDestroyOnLoad(gameObject);
		}
		else if (_instance != this)
		{
			Debug.LogWarning($"[Singleton] Otra instancia de {nameof(T)} ya existe. Destruyendo esta: {gameObject.name}");
			Destroy(gameObject);
		}
	}

	protected virtual void OnApplicationQuit()
	{
		_applicationIsQuitting = true;
	}

#endregion

}