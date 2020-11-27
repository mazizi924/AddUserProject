using Didar.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services
{
    public interface IUserService
    {
        Result AddUser(User user);
    }
    public class UserService : IUserService
    {
        HttpClient client=new HttpClient();
        string apiUrl = "https://app.didar.me/api/contact/save?apikey=" + Properties.Settings.Default["apikey"] ;
        public Result AddUser(User user)
        {
            try
            { 
                string jsonRequest = JsonConvert.SerializeObject(user, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }); 
                var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
                HttpResponseMessage response =  client.PostAsync(apiUrl, content).Result;
                if (response != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var customerJsonString = response.Content.ReadAsStringAsync().Result;
                        var result = JsonConvert.DeserializeObject<Root>(custome‌​rJsonString);

                        return new Result
                        {
                            Data = result.Response,
                            IsSuccess = true,
                            Message = "اطلاعات ثبت شد"
                        };
                    }
                    else {
                        return new Result
                        {
                            Data = null,
                            IsSuccess = false,
                            Message = response.ReasonPhrase== "Contact's data not found"?"کاربری با این اطلاعات یافت نشد" : response.ReasonPhrase
                        };  
                            }
                }
            }
            catch (Exception){ }
            return new Result
            {
                IsSuccess = false,
                Message = "خطا در ثبت اطلاعات"
            };
        }
    }
}
