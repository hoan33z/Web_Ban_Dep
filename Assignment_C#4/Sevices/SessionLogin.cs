using Assignment_C_4.Models;
using Newtonsoft.Json;

namespace Assignment_C_4.Sevices
{
    public class SessionLogin
    {
        public static NguoiDung GetObjFromSession(ISession session, string key)
        {
            var jsonData = session.GetString(key);
            if (jsonData == null) return null;
            var login = JsonConvert.DeserializeObject<NguoiDung>(jsonData);
            return login;
        }
        public static void SetObjToSession(ISession session, string key, object values)
        {
            var jsonData = JsonConvert.SerializeObject(values);
            session.SetString(key, jsonData);
        }
        public static bool CheckObjInList(Guid id, List<SanPham> products)
        {
            return products.Any(x => x.ID == id);
        }

    }
}
