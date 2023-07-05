using Assignment_C_4.Models;
using Newtonsoft.Json;

namespace Assignment_C_4.Sevices
{
    public static class SessionServices
    {
        public static List<SanPham> GetObjFromSession(ISession session, string key)
        {
            // Lấy string Json từ Session
            var jsonData = session.GetString(key);
            if (jsonData == null) return new List<SanPham>();
            // Chuyển đổi dữ liệu vừa lấy được sang dạng mong muốn
            var products = JsonConvert.DeserializeObject<List<SanPham>>(jsonData);
            // Nếu null thì trả về 1 list rỗng
            return products;
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
