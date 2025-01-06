using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace MTCG_Patrick_Rohrweckh.HttpServer
{
    internal class HttpRequest
    {
        public HttpRequest(StreamReader reader)
        {
           
            // ----- 1. Read the HTTP-Request -----
            string? line;
            
            // 1.1 first line in HTTP contains the method, path and HTTP version
            line = reader.ReadLine();
            if (line != null)
            {
                Console.WriteLine(line);
                string[] words = line.Split(' ');
                method = words[0];
                path = words[1];
            }

            // 1.2 read the HTTP-headers (in HTTP after the first line, until the empy line)
            int content_length = 0; // we need the content_length later, to be able to read the HTTP-content
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
                if (line == "")
                {
                    break;  // empty line indicates the end of the HTTP-headers
                }

                // Parse the header
                var parts = line.Split(':');
                if (parts.Length == 2 && parts[0] == "Content-Length")
                {
                    content_length = int.Parse(parts[1].Trim());
                }
            }

            // 1.3 read the body if existing
            if (content_length > 0)
            {
                var data = new StringBuilder(200);
                char[] chars = new char[1024];
                int bytesReadTotal = 0;
                while (bytesReadTotal < content_length)
                {
                    var bytesRead = reader.Read(chars, 0, chars.Length);
                    bytesReadTotal += bytesRead;
                    if (bytesRead == 0)
                        break;
                    data.Append(chars, 0, bytesRead);
                }
                Console.WriteLine(data.ToString());
                content = data.ToString();
            }
        }
        public string? content { get; set; }
        public string? method { get; set; }
        public string? path { get; set; }
    }
}
