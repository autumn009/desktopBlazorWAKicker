using System.Net;
using System.Text;
using Microsoft.AspNetCore.StaticFiles;

namespace desktopBlazorWAKicker
{
    internal class HttpServer
    {
        private string documentRoot { get; set; }
        private int port { get; set; }

        public HttpServer(string root, int port)
        {
            this.port = port;
            documentRoot = root;
        }

        private HttpListener? _listener = null;

        public void Start()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://*:" + port.ToString() + "/");
            _listener.Start();
            Receive();
        }

        public void Stop()
        {
            _listener?.Stop();
        }

        private void Receive()
        {
            _listener?.BeginGetContext(new AsyncCallback(ListenerCallback), _listener);
        }

        private void ListenerCallback(IAsyncResult result)
        {
            try
            {
                if (_listener?.IsListening == true)
                {
                    var context = _listener.EndGetContext(result);
                    var request = context.Request;

                    //Console.WriteLine($"{request.HttpMethod} {request.Url} {request.Url?.LocalPath}");

                    string path = documentRoot + request.Url?.LocalPath.Replace("/", "\\");
                    if (path.EndsWith("\\"))
                    {
                        path += "index.html";
                    }

                    var response = context.Response;
                    if (!File.Exists(path))
                    {
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        response.ContentType = "text/plain";
                        response.OutputStream.Write(Encoding.UTF8.GetBytes($"404 Not Found: {path}"));
                        response.OutputStream.Close();
                        Receive();
                        return;
                    }
                    var bytes = File.ReadAllBytes(path);

                    response.StatusCode = (int)HttpStatusCode.OK;
                    string mimetype;
                    var a = new FileExtensionContentTypeProvider();
                    a.TryGetContentType(path, out mimetype);

                    response.ContentType = mimetype ?? "application/octet-stream";
                    response.OutputStream.Write(bytes, 0, bytes.Length);
                    response.OutputStream.Close();
                    Receive();
                }

            }
            catch (HttpListenerException)
            {
                return;
            }
        }
    }
}
