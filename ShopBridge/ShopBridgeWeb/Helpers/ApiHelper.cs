using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ShopBridgeWeb.Helpers
{
    public static class ApiHelper
    {
        public static async Task<HttpResponseMessage> CallApi(string URL, HttpMethod invokeType, ByteArrayContent body, string bodyId, byte[] file,string fileName)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            response.StatusCode = HttpStatusCode.BadRequest;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(URL);

                    if (invokeType.Method == HttpMethod.Get.ToString())
                    {
                        var responseTask = client.GetAsync(URL);
                        responseTask.Wait();
                        response = responseTask.Result;
                    }
                    else if (invokeType.Method == HttpMethod.Post.ToString())
                    {
                        MultipartFormDataContent multiContent = new MultipartFormDataContent();
                        multiContent.Add(body, bodyId);

                        //byte[] imageData = null;
                        //if (formFile != null)
                        //{
                        //    using (var br = new BinaryReader(formFile.OpenReadStream()))
                        //    {
                        //        imageData = br.ReadBytes((int)formFile.OpenReadStream().Length);
                        //        ByteArrayContent bytes = new ByteArrayContent(imageData);
                        //        multiContent.Add(bytes, "file", formFile.FileName);
                        //    }
                        //}

                        if (file != null && file.Length > 0)
                        {
                            ByteArrayContent bytes = new ByteArrayContent(file);
                            multiContent.Add(bytes, "file", fileName);
                        }

                        //multiContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
                        var responseTask = client.PostAsync(URL, multiContent);
                        responseTask.Wait();

                        response = responseTask.Result;
                    }
                    else if (invokeType.Method == HttpMethod.Put.ToString())
                    {
                        MultipartFormDataContent multiContent = new MultipartFormDataContent();
                        //body.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        multiContent.Add(body, bodyId);

                        //byte[] imageData = null;
                        //if (formFile != null)
                        //{
                        //    using (var br = new BinaryReader(formFile.OpenReadStream()))
                        //    {
                        //        imageData = br.ReadBytes((int)formFile.OpenReadStream().Length);
                        //        ByteArrayContent bytes = new ByteArrayContent(imageData);
                        //        multiContent.Add(bytes, "file", formFile.FileName);
                        //    }
                        //}

                        if (file != null && file.Length > 0)
                        {
                            ByteArrayContent bytes = new ByteArrayContent(file);
                            multiContent.Add(bytes, "file", fileName);
                        }

                        //multiContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
                        var responseTask = client.PutAsync(URL, multiContent);
                        responseTask.Wait();

                        response = responseTask.Result;
                    }
                    else if (invokeType.Method == HttpMethod.Delete.ToString())
                    {
                        var responseTask = client.DeleteAsync(URL);
                        responseTask.Wait();

                        response = responseTask.Result;
                    }

                    response.StatusCode = response.StatusCode;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                //TODO: Need code to log error somewhere, for example in an error log file
            }

            return response;
        }
    }
}
