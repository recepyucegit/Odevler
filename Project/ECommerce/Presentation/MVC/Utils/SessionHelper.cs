using Newtonsoft.Json;

namespace MVC.Utils
{
    public class SessionHelper
    {


        //Set (Session)
        public static void SetJsonProduct(ISession session, string key, object value)
        {
            //object türündeki bir değeri json'a doğrudan dönüştürmek için Newtonsoft.Json kütüphanesini nuget'dan çekmemiz gerekmektedir.

            string jsonFormat = JsonConvert.SerializeObject(value);
            session.SetString(key, jsonFormat);
        }


        //Get (Session)
        public static T GetProductFromJson<T>(ISession session, string key)
        {
            var result = session.GetString(key); //string gelir

            if (result == null)
            {
                return default(T);
            }
            else
            {
                //DeSerialize
                var deSerialize = JsonConvert.DeserializeObject<T>(result);
                return deSerialize;
            }
        }


    }
}
