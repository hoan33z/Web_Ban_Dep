using Assignment_C_4.ViewModel;
using Newtonsoft.Json;

namespace Assignment_C_4.Sevices
{
    public static class SessionGHCTServices
    {
        public static List<GHCT> GetObjFromSession(ISession session, string key)
        {
            // Lấy string Json từ Session
            var jsonData = session.GetString(key);
            if (jsonData == null) return new List<GHCT>();
            // Chuyển đổi dữ liệu vừa lấy được sang dạng mong muốn
            var ghct = JsonConvert.DeserializeObject<List<GHCT>>(jsonData);
            // Nếu null thì trả về 1 list rỗng
            return ghct;
        }
        public static void SetObjToSession(ISession session, string key, object values)
        {
            var jsonData = JsonConvert.SerializeObject(values);
            session.SetString(key, jsonData);
        }
        public static bool CheckObjInList(Guid id, List<GHCT> products)
        {
            return products.Any(x => x.ID == id);
        }
    }
}
