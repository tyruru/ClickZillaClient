using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public abstract class ApiCommandHandler
{
    private readonly string _baseUrl;
    
    protected ApiCommandHandler(string baseUrl)
    {
        _baseUrl = baseUrl;
    }
    
    protected async Task<T> GetAsync<T>(string endpoint)
    {
        using var request = UnityWebRequest.Get($"{_baseUrl}/{endpoint}");
        return await SendRequestAsync<T>(request);
    }

    protected async Task<TReturn> PostAsync<TReturn, TRequest>(string endpoint, TRequest data)
    {
        var json = JsonConvert.SerializeObject(data);
        using var request = UnityWebRequest.PostWwwForm($"{_baseUrl}/{endpoint}", "POST");
        request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        return await SendRequestAsync<TReturn>(request);
    }
    
    protected async Task<T> PutAsync<T>(string endpoint, object data)
    {
        using var request = UnityWebRequest.Put($"{_baseUrl}/{endpoint}", JsonUtility.ToJson(data));
        request.SetRequestHeader("Content-Type", "application/json");
        return await SendRequestAsync<T>(request);
    }
    
    protected async Task DeleteAsync(string endpoint)
    {
        using var request = UnityWebRequest.Delete($"{_baseUrl}/{endpoint}");
        await SendRequestAsync<object>(request);
    }
    protected async Task<T> SendRequestAsync<T>(UnityWebRequest request)
    {
        try
        {
            Debug.Log($"[{request.url}]: send request");

            var operation = request.SendWebRequest();
            
            while (!operation.isDone)
            {
                await Task.Yield();
            }

            if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError($"[{request.url}]: {request.error}");
                return default;
            }

            if (typeof(T) == typeof(object))
            {
                return default;
            }

            var json = request.downloadHandler.text;
            return JsonConvert.DeserializeObject<T>(json);
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
            return default;
        }
    }
}
