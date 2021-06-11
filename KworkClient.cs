using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Text;
using System.Net.WebSockets;
using System.IO;
using System.Linq;

namespace Kwork
{
    public class KworkClient
    {
        //Account
        private string _login = null;
        private string _password = null;
        private string _lastPhone = null;
        private string _token = null;
        private string _proxy = null;

        private string _host = "https://api.kwork.ru/";

        private HttpClient clientSession;
        private ClientWebSocket _clientWebSocket;
        private CancellationTokenSource _receivingCancellationTokenSource;

        private string channelUrl { get { return $"wss://notice.kwork.ru/ws/public/{_GetChannel()}"; } set { this.channelUrl = value; } }

        //Delegates
        private delegate void _OnUpdate(string text);
        public delegate void _OnMessage(Types.Updates.KworkUpdateNewInbox message);

        
        public delegate void _OnTyping(string s);
        public _OnMessage OnMessage;

        
        public _OnTyping OnTyping;



        //private _OnUpdate onUpdate = OnUpdate;

        public KworkClient(string Login, string Password, string LastPhone = null, string Proxy = null)
        {
            this._login = Login;
            this._password = Password;
            this._lastPhone = LastPhone;
            this._proxy = Proxy;
            this.clientSession = new HttpClient() {BaseAddress = new Uri(this._host)};
            this._token = _GetToken(Login:Login,Password:Password);
        }


        public JObject MakeApiRequest(string ApiMethod, string method = "post", Dictionary<string, string> Params = null)
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            //Set up method
            if (method == "post"){httpRequest.Method = HttpMethod.Post;}
            else if (method == "get"){httpRequest.Method = HttpMethod.Get;}
            //Set up Headers
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", "bW9iaWxlX2FwaTpxRnZmUmw3dw==");

            if (this._token != null)
            {
                this.clientSession.DefaultRequestHeaders.Add("token", this._token);
            }


            //Create url with params
            var uriBuilder = new UriBuilder(this._host + ApiMethod);

            if (Params != null)
            {
                var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);

                foreach (KeyValuePair<string, string> pair in Params)
                {
                    query[pair.Key] = pair.Value;
                }

                uriBuilder.Query = query.ToString();
            }

            httpRequest.RequestUri = new Uri(uriBuilder.ToString());

            HttpResponseMessage responseMessage = this.clientSession.Send(httpRequest);

            //Checking for errors
            _CheckForErrors(JObject.Parse(responseMessage.Content.ReadAsStringAsync().Result));

            return  JObject.Parse(responseMessage.Content.ReadAsStringAsync().Result);

        }

        private string _GetToken(string Login, string Password)
        {
            var paramsToRequest = new Dictionary<string, string>();
            paramsToRequest.Add("login", Login);
            paramsToRequest.Add("password", Password);
            if (this._token != null)
            {
                paramsToRequest.Add("phone_last", this._token.Substring(this._token.Length-4));
            }
            var r = MakeApiRequest(ApiMethod:"signIn",Params: paramsToRequest);
            return r["response"]["token"].ToString();
        }

        private bool _CheckForErrors(JObject keyValues)
        {
            if (bool.Parse(keyValues.GetValue("success").ToString())) { return true; }
            else
            {
                
                switch (int.Parse(keyValues.GetValue("error_code").ToString()))
                {
                    // TODO Add error message
                    //keyValues.GetValue("error").ToString()
                    case 105: throw new Exceptions.InvalidLoginOrPassword();
                    case 100:
                        throw new Exceptions.NotEnougthParamsForRequest();
                    case 150:
                        throw new Exceptions.ClientDoNotHavePayerOrders();
                    case 151:
                        throw new Exceptions.ClientDoNotHaveWorkerOrders();
                    case 130:
                        throw new Exceptions.ChattingIsNotAllowed();
                    default:
                        break;
                }
                return false;
            }
        }

        public Types.KworkActor GetMe()
        {
            JObject json = MakeApiRequest(ApiMethod: "actor");
            Types.KworkActor actor = JsonSerializer.Deserialize<Types.KworkActor>(json["response"].ToString());
            
            return actor;
        }

        public Types.KworkSearchResults Search(string query, int page = 1)
        {
            var paramsToRequest = new Dictionary<string, string>();
            paramsToRequest.Add("query", query);
            paramsToRequest.Add("page", page.ToString());
            
            JObject json = MakeApiRequest(ApiMethod: "search", Params: paramsToRequest);
            Types.KworkSearchResults results = JsonSerializer.Deserialize<Types.KworkSearchResults>(json["response"].ToString());
            
            return results;
        }

        public Types.KworkUser GetUser(long id)
        {
            var paramsToRequest = new Dictionary<string, string>();
            paramsToRequest.Add("id", id.ToString());
            
            JObject json = MakeApiRequest(ApiMethod: "user", Params: paramsToRequest);
            Types.KworkUser user = JsonSerializer.Deserialize<Types.KworkUser>(json["response"].ToString());
            
            return user;
        }

        public Types.KworkProject[] GetProjects(string query, string keyword = "")
        {
            var paramsToRequest = new Dictionary<string, string>();
            paramsToRequest.Add("query", query.ToString());
            paramsToRequest.Add("keyword", keyword.ToString());

            JObject json = MakeApiRequest(ApiMethod: "projects", Params: paramsToRequest);
            Types.KworkProject[] projects = JsonSerializer.Deserialize<Types.KworkProject[]>(json["response"].ToString());
            return projects;
        }
        public void SendMessage(long user_id, string text)
        {
            var paramsToRequest = new Dictionary<string, string>();
            paramsToRequest.Add("user_id", user_id.ToString());
            paramsToRequest.Add("text", text.ToString());

            JObject json = MakeApiRequest(ApiMethod: "inboxCreate", Params: paramsToRequest);
        }
        public void DeleteMessage(long message_id)
        {
            var paramsToRequest = new Dictionary<string, string>();
            paramsToRequest.Add("id", message_id.ToString());
            JObject json = MakeApiRequest(ApiMethod: "inboxDelete", Params: paramsToRequest);
        }
        public Types.KworkDialog[] GetDialogs()
        {
            JObject json = MakeApiRequest(ApiMethod: "dialogs");
            Types.KworkDialog[] dialogs = JsonSerializer.Deserialize<Types.KworkDialog[]>(json["response"].ToString());
            return dialogs;
        }
        public void SendTyping(long dialogId)
        {
            var paramsToRequest = new Dictionary<string, string>();
            paramsToRequest.Add("recipientId", dialogId.ToString());
            JObject json = MakeApiRequest(ApiMethod: "typing", Params: paramsToRequest);
        }
        
        public Types.KworkMessage[] GetDialogWithUser(string username, int page = 1)
        {
            var paramsToRequest = new Dictionary<string, string>();
            paramsToRequest.Add("username", username.ToString());
            paramsToRequest.Add("page", page.ToString());
            JObject json = MakeApiRequest(ApiMethod: "inboxes", Params: paramsToRequest);
            Types.KworkMessage[] messages = JsonSerializer.Deserialize<Types.KworkMessage[]>(json["response"].ToString());
            return messages;
        }

        public void SetOffline()
        {
            MakeApiRequest(ApiMethod: "offline");
        }

        public Types.KworkWorkerOrder[] GetWorkerOrders(int page = 1, string filter = "all")
        {
            var paramsToRequest = new Dictionary<string, string>();
            paramsToRequest.Add("page", page.ToString());
            paramsToRequest.Add("filter", filter.ToString());
            JObject json = MakeApiRequest(ApiMethod: "workerOrders", Params: paramsToRequest);
            Types.KworkWorkerOrder[] orders = JsonSerializer.Deserialize<Types.KworkWorkerOrder[]>(json["response"]["orders"].ToString());
            return orders;
        }

        public Types.KworkPayerOrder[] GetPayerOrders(int page = 1, string filter = "all")
        {
            var paramsToRequest = new Dictionary<string, string>();
            paramsToRequest.Add("page", page.ToString());
            paramsToRequest.Add("filter", filter.ToString());
            JObject json = MakeApiRequest(ApiMethod: "payerOrders", Params: paramsToRequest);
            Types.KworkPayerOrder[] orders = JsonSerializer.Deserialize<Types.KworkPayerOrder[]>(json["response"]["orders"].ToString());
            return orders;
        }
        private string _GetChannel()
        {
            JObject json = MakeApiRequest(ApiMethod: "getChannel");
            return json["response"]["channel"].ToString();
        }

        public void StartReceiving(CancellationToken cancellationToken = default)
        {
            _receivingCancellationTokenSource = new CancellationTokenSource();

            cancellationToken.Register(() => _receivingCancellationTokenSource.Cancel());

            ReceiveAsync(_receivingCancellationTokenSource.Token);
        }

        private async void ReceiveAsync(CancellationToken cancellationToken = default)
        {

            this._clientWebSocket = new ClientWebSocket();

            await _clientWebSocket.ConnectAsync(new Uri(channelUrl), CancellationToken.None);

            while (!cancellationToken.IsCancellationRequested)
            {   
                

                var buffer = new ArraySegment<byte>(new byte[1024]);
                WebSocketReceiveResult result = null;
                var allBytes = new List<byte>();

                do
                {
                    try
                    {
                        result = await _clientWebSocket.ReceiveAsync(buffer, CancellationToken.None);
                    }
                    catch (WebSocketException)
                    {
                        await _clientWebSocket.ConnectAsync(new Uri(channelUrl), CancellationToken.None);
                        continue;
                    }
                    for (int i = 0; i < result.Count; i++)
                    {
                        allBytes.Add(buffer.Array[i]);
                    }
                }
                while (!result.EndOfMessage);

                string text = Encoding.UTF8.GetString(allBytes.ToArray(), 0, allBytes.Count);
                OnUpdate(text);
            }
        }

        private void OnUpdate(string text)
        {
            JObject json =  JObject.Parse(Uri.UnescapeDataString(text).ToString());
            string Event = JObject.Parse(json.GetValue("text").ToString()).GetValue("event").ToString();
            switch (Event)
            {
                case ("new_inbox"):
                    Types.Updates.KworkUpdateNewInbox inbox = JsonSerializer.Deserialize<Types.Updates.KworkUpdateNewInbox>(JObject.Parse(json.GetValue("text").ToString()).GetValue("data").ToString());
                    OnMessage?.Invoke(inbox);
                    break;
                case ("is_typing"):
                    break;
                default:
                    break;
            }
        }

        public void StopReceiving()
        {
            try
            {
                _receivingCancellationTokenSource.Cancel();
            }
            catch (WebException)
            {
            }
            catch (TaskCanceledException)
            {
            }
            finally
            {
                _receivingCancellationTokenSource.Dispose();
            }
        }
    }
}
