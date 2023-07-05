using Assignment_C_4.Models;
using Newtonsoft.Json;

namespace Assignment_C_4.Sevices
{
    public class SessionDetail
    {
        public static SanPham GetObjFromSession(ISession session, string key)
        {
            var jsonData = session.GetString(key);
            if (jsonData == null) return new SanPham();
            var detail = JsonConvert.DeserializeObject<SanPham>(jsonData);
            return detail;
        }
        public static void SetObjToSession(ISession session, string key, object values)
        {
            var jsonData = JsonConvert.SerializeObject(values);
            session.SetString(key, jsonData);
        }
    }
}
