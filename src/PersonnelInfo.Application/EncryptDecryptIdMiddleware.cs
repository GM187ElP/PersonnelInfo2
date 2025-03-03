using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Text;

public class EncryptDecryptIdMiddleware
{
    private readonly RequestDelegate _next;
    private readonly RSAESEncryption _rsaESEncryption;

    public EncryptDecryptIdMiddleware(RequestDelegate next, RSAESEncryption rsaESEncryption)
    {
        _next = next;
        _rsaESEncryption = rsaESEncryption;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        //Handle GET, POST, and PUT requests
        if (/*context.Request.Method == "GET" ||*/ context.Request.Method == "POST" || context.Request.Method == "PUT")
        {
            ////For GET requests, decrypt the route parameter
            //if (context.Request.Method == "GET")
            //{
            //    var routeValues = context.GetRouteData()?.Values;
            //    if (routeValues != null && routeValues.ContainsKey("id"))
            //    {
            //        var encryptedId = routeValues["id"]?.ToString();
            //        if (!string.IsNullOrEmpty(encryptedId))
            //        {
            //            try
            //            {
            //                var decryptedId = _rsaESEncryption.DecryptWithHybrid(encryptedId);
            //                routeValues["id"] = decryptedId; // Replace with decrypted ID
            //            }
            //            catch (Exception)
            //            {
            //                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            //                await context.Response.WriteAsync("Invalid encrypted ID in route.");
            //                return;
            //            }
            //        }
            //    }
            //}

            //// For POST and PUT requests, handle body decryption
            if (context.Request.Method == "POST" || context.Request.Method == "PUT")
            {
                var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();

                // Deserialize the body into a dictionary to access "id"
                var json = JsonSerializer.Deserialize<Dictionary<string, object>>(requestBody);

                if (json != null && json.ContainsKey("id"))
                {
                    var encryptedId = json["id"]?.ToString();
                    if (!string.IsNullOrEmpty(encryptedId))
                    {
                        try
                        {
                            // Decrypt the ID from the body
                            var decryptedId = _rsaESEncryption.DecryptWithHybrid(encryptedId);
                            json["id"] = decryptedId; // Replace with decrypted ID
                        }
                        catch (Exception)
                        {
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            await context.Response.WriteAsync("Invalid encrypted ID in request body.");
                            return;
                        }
                    }
                }

                // Rewind the body stream to send it forward in the pipeline
                context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(json)));
            }
        }

        // Proceed to the next middleware or controller
        await _next(context);
    }
}
