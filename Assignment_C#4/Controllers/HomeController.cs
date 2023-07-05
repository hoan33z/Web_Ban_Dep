using Assignment_C_4.ISevices;
using Assignment_C_4.Models;
using Assignment_C_4.Sevices;
using Assignment_C_4.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Assignment_C_4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISanPhamSevice sanPhamSevice; // Interface
        private readonly INguoiDungSevice nguoiDungSevice; // Interface
        private readonly IGioHangSevice gioHangSevice; // Interface
        private readonly IGioHangChiTietSevice gioHangChiTietSevice; // Interface
        private readonly IHoaDonChiTietSevice hoaDonChiTietSevice; // Interface
        private readonly IHoaDonSevice hoaDonSevice; // Interface
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            sanPhamSevice = new SanPhamSevice();
            nguoiDungSevice = new NguoiDungSevice();
            gioHangSevice = new GioHangSevice();
            gioHangChiTietSevice = new GioHangChiTietSevice();
            hoaDonChiTietSevice = new HoaDonChiTietSevice();
            hoaDonSevice = new HoaDonSevice();
        }

        public IActionResult Index()
        {
            ViewData["lg"] = SessionLogin.GetObjFromSession(HttpContext.Session, "login");
            return View();
        }
        public IActionResult Detail(Guid id)
        {
            ViewData["lg"] = SessionLogin.GetObjFromSession(HttpContext.Session, "login");
            var detail = sanPhamSevice.GetProductById(id);
            SessionDetail.SetObjToSession(HttpContext.Session, "detail", detail);
            ViewData["detail"] = SessionDetail.GetObjFromSession(HttpContext.Session, "detail");
            return View();
        }

        public IActionResult ShowListProduct()
        {
            ViewData["lg"] = SessionLogin.GetObjFromSession(HttpContext.Session, "login");
            var product = sanPhamSevice.GetAllProducts();
            return View(product);
        }
        public IActionResult CreateSP()
        {
            ViewData["lg"] = SessionLogin.GetObjFromSession(HttpContext.Session, "login");

            return View();
        }
        [HttpPost]
        public IActionResult CreateSP(SanPham SP, [Bind] IFormFile imageFile) // Thực hiện chức năng thêm
        {
            ViewData["lg"] = SessionLogin.GetObjFromSession(HttpContext.Session, "login");

            //var x = imageFile.FileName; // only for debug
            if (imageFile != null && imageFile.Length > 0) // Không null và không trống
            {
                //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                    imageFile.CopyTo(stream);
                }
                // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã được sao chép
                SP.HinhAnh = imageFile.FileName;
            }
            if (sanPhamSevice.GetAllProducts().FirstOrDefault(c=>c.TenSP==SP.TenSP)!=null && sanPhamSevice.GetAllProducts().Where(c=>c.TenSP==SP.TenSP).FirstOrDefault(c => c.Mau == SP.Mau) != null) // Nếu thêm thành công
            {
                return NotFound();
            }
            else
            {
                sanPhamSevice.CreateProduct(SP);
                return RedirectToAction("ShowListProduct");
            }
            //return RedirectToAction("Index");
        }
        public IActionResult DeleteSP(Guid id)
        {
            if (sanPhamSevice.DeleteProduct(id))
            {
                return RedirectToAction("ShowListProduct");
            }
            else return View("Index");
        }
        [HttpGet]
        public IActionResult EditSP(Guid id)
        {
            SanPham p = sanPhamSevice.GetProductById(id);
            return View(p);
        }
        public IActionResult EditSP(SanPham p) // Thực hiện việc Tạo mới
        {
            var sp = sanPhamSevice.GetAllProducts().Where(c => c.ID == p.ID);
            if (sanPhamSevice.UpdateProduct(p))
            {
                return RedirectToAction("ShowListProduct");
            }
            else return BadRequest();
        }

        public IActionResult CreateND()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateND(NguoiDung p)
        {
            if (nguoiDungSevice.CreateNguoiDung(p))
            {
                gioHangSevice.CreateGioHang(new GioHang() { IDND = p.IDND, ThongTin = "Khách Hàng" });
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }

        public IActionResult CreateGH(Guid id)
        {
            ViewData["lg"] = SessionLogin.GetObjFromSession(HttpContext.Session, "login");
            return View();
        }
        public IActionResult DeleteSession()
        {
            HttpContext.Session.Remove("Cart"); // Xóa 1 Session cụ thể nào đó
            return RedirectToAction("ShowGH");
        }

        public IActionResult Home()
        {
            ViewData["lg"] = SessionLogin.GetObjFromSession(HttpContext.Session, "login");
            var product = sanPhamSevice.GetAllProducts();
            return View(product);
        }

        public IActionResult SanPham()
        {
            ViewData["lg"] = SessionLogin.GetObjFromSession(HttpContext.Session, "login");
            var product = sanPhamSevice.GetAllProducts();
            return View(product);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(NguoiDung p)
        {
            var login = nguoiDungSevice.GetAllUser().FirstOrDefault(c => c.TaiKhoan == p.TaiKhoan);
            if (login == null) return View();
            if (login.MatKhau == p.MatKhau)
            {
                SessionLogin.SetObjToSession(HttpContext.Session, "login", login);
                ViewData["lg"] = SessionLogin.GetObjFromSession(HttpContext.Session, "login");
            }
            return View("Index");
        }
        public IActionResult Logout()
        {
            ViewData["lg"] = SessionLogin.GetObjFromSession(HttpContext.Session, "login");
            HttpContext.Session.Remove("login");
            return RedirectToAction("Index");
        }

        public IActionResult CreateGHCT(GioHangChiTiet ghct)
        {
            ViewData["lg"] = SessionLogin.GetObjFromSession(HttpContext.Session, "login");

            if (SessionLogin.GetObjFromSession(HttpContext.Session, "login") == null)
            {
                GHCT show = new GHCT() { ID = ghct.IDSP, TenSP = sanPhamSevice.GetProductById(ghct.IDSP).TenSP, Mau = sanPhamSevice.GetProductById(ghct.IDSP).Mau, GiaBan = sanPhamSevice.GetProductById(ghct.IDSP).GiaBan, KichCo = sanPhamSevice.GetProductById(ghct.IDSP).KichCo, HinhAnh = sanPhamSevice.GetProductById(ghct.IDSP).HinhAnh, SoLong = ghct.SoLuong };
                // Lấy được dữ liệu sản phẩm
                //var product = sanPhamSevice.GetProductById(ghct.IDSP);
                // Lấy dữ liệu từ Cart (Trong Session)
                var products = SessionGHCTServices.GetObjFromSession(HttpContext.Session, "Cart");
                // Kiểm tra xem list dữ liệu đó có phần tử nào chưa...
                if (products.Count == 0)
                {
                    products.Add(show);  // Nếu không có sp nào thì add nó vào
                                         // Sau đó gán lại giá trị vào trong Session
                    SessionServices.SetObjToSession(HttpContext.Session, "Cart", products);
                }
                else
                {
                    if (SessionGHCTServices.CheckObjInList(ghct.IDSP, products))
                    {
                       var sp = products.FirstOrDefault(c=>c.ID==ghct.IDSP);
                        sp.SoLong = ghct.SoLuong+sp.SoLong;
                        SessionServices.SetObjToSession(HttpContext.Session, "Cart", products);
                    }
                    else
                    {
                        products.Add(show);  // Nếu chưa có sản phẩm đó trong list thì thêm vào
                                             // Sau đó gán lại giá trị vào trong Session
                        SessionServices.SetObjToSession(HttpContext.Session, "Cart", products);
                    }
                }
                return RedirectToAction("ShowGHCT1");
            }
            else
            {
                Guid idnd = SessionLogin.GetObjFromSession(HttpContext.Session, "login").IDND;
                if (gioHangChiTietSevice.GetAllCartDetails().Where(c => c.IDND == idnd).FirstOrDefault(c => c.IDSP == ghct.IDSP) != null)
                {
                    var sp = gioHangChiTietSevice.GetAllCartDetails().Where(c => c.IDND == idnd).FirstOrDefault(c => c.IDSP == ghct.IDSP);
                    sp.SoLuong += ghct.SoLuong;
                    gioHangChiTietSevice.UpdateGioHangChiTiet(sp);
                }
                else
                {
                    gioHangChiTietSevice.CreateGioHangChiTiet(new GioHangChiTiet() { IDND = idnd, IDSP = ghct.IDSP, SoLuong = ghct.SoLuong });
                }
            }
            return RedirectToAction("ShowGHCT");
        }
        public IActionResult ShowGHCT1()
        {
            var products = SessionGHCTServices.GetObjFromSession(HttpContext.Session, "Cart");
            return View(products);

        }
        public IActionResult ShowGHCT()
        {
            ViewData["lg"] = SessionLogin.GetObjFromSession(HttpContext.Session, "login");
            if (SessionLogin.GetObjFromSession(HttpContext.Session, "login") == null)
            {
                return RedirectToAction("ShowGHCT1");
            }
            else
            {
                Guid idnd = SessionLogin.GetObjFromSession(HttpContext.Session, "login").IDND;
                List<SanPham> lstCTGioHang = new List<SanPham>();
                lstCTGioHang = (
                    from a in sanPhamSevice.GetAllProducts()
                    join b in gioHangChiTietSevice.GetAllCartDetails().Where(c => c.IDND == idnd) on a.ID equals b.IDSP
                    select new SanPham()
                    {
                        ID = a.ID,
                        TenSP = a.TenSP,
                        Mau = a.Mau,
                        KichCo = a.KichCo,
                        GiaBan = a.GiaBan,
                        SoLongTon = b.SoLuong,
                        HinhAnh = a.HinhAnh
                    }).ToList();
                return View(lstCTGioHang);
            }
        }
        public IActionResult DeleteGHCT(Guid id)
        {
            Guid idnd = SessionLogin.GetObjFromSession(HttpContext.Session, "login").IDND;
            var idGHCT = gioHangChiTietSevice.GetAllCartDetails().Where(c => c.IDND == idnd).FirstOrDefault(c => c.IDSP == id).ID;
            if (gioHangChiTietSevice.DeleteGioHangChiTiet(idGHCT))
            {
                return RedirectToAction("ShowGHCT");
            }
            else return View("Index");
        }

        public IActionResult ThanhToan()
        {
            ViewData["lg"] = SessionLogin.GetObjFromSession(HttpContext.Session, "login");
            if (ViewData["lg"] == null)
            {
                var products = SessionGHCTServices.GetObjFromSession(HttpContext.Session, "Cart");
                HoaDon hoaDon = new HoaDon() { IDND = Guid.Parse("36087100-7EB8-4BF8-0D6E-08DB3C51B1E0"), NgayTao = DateTime.Now, NgayThanhToan = DateTime.Now, TenKH = "Khách ko đăng nhập", SDT = 000000000, TongTien = 0, TrangThai = 1 };
                if (hoaDonSevice.CreateHoaDon(hoaDon))
                {
                    foreach (var x in products)
                    {
                        var sp = sanPhamSevice.GetAllProducts().FirstOrDefault(c => c.ID == x.ID);
                        hoaDonChiTietSevice.CreateHoaDonChiTiet(new HoaDonChiTiet() { IDHD = hoaDon.ID, IDSP = x.ID, SoLuong = x.SoLong, Gia = sp.GiaBan });
                        sp.SoLongTon -= x.SoLong;
                        sanPhamSevice.UpdateProduct(sp);
                        hoaDon.TongTien += (x.SoLong * sp.GiaBan);
                        hoaDon.TrangThai = 0;
                    }
                    hoaDonSevice.UpdateHoaDon(hoaDon);
                    HttpContext.Session.Remove("Cart");
                }
            }
            else
            {
                var nd = SessionLogin.GetObjFromSession(HttpContext.Session, "login");
                var gh = gioHangChiTietSevice.GetAllCartDetails().Where(c => c.IDND == nd.IDND);
                HoaDon hoaDon = new HoaDon() { IDND = nd.IDND, NgayTao = DateTime.Now, NgayThanhToan = DateTime.Now, TenKH = nd.TenND, SDT = nd.SDT, TongTien = 0, TrangThai = 1 };
                if (hoaDonSevice.CreateHoaDon(hoaDon))
                {
                    foreach (var x in gh)
                    {
                        var sp = sanPhamSevice.GetAllProducts().FirstOrDefault(c => c.ID == x.IDSP);
                        hoaDonChiTietSevice.CreateHoaDonChiTiet(new HoaDonChiTiet() { IDHD = hoaDon.ID, IDSP = x.IDSP, SoLuong = x.SoLuong, Gia = sp.GiaBan });
                        sp.SoLongTon -= x.SoLuong;
                        sanPhamSevice.UpdateProduct(sp);
                        hoaDon.TongTien += (x.SoLuong * sp.GiaBan);
                        hoaDon.TrangThai = 0;
                        gioHangChiTietSevice.DeleteGioHangChiTiet(x.ID);
                    }
                    hoaDonSevice.UpdateHoaDon(hoaDon);
                }
                return View(hoaDonChiTietSevice.GetAllBill().Where(c => c.IDHD == hoaDon.ID));
            }
            return RedirectToAction("Index");
        }


        public IActionResult QlHoaDon()
        {
            ViewData["lg"] = SessionLogin.GetObjFromSession(HttpContext.Session, "login");

            var lsthd = hoaDonSevice.GetAllBill();
            return View(lsthd);
        }
        public IActionResult EditHD(HoaDon HD)
        {
            ViewData["lg"] = SessionLogin.GetObjFromSession(HttpContext.Session, "login");
            var lsthd = hoaDonSevice.GetAllBill();
            HoaDon hd = hoaDonSevice.GetAllBill().FirstOrDefault(c => c.ID == HD.ID);
            if (hd == null)
            {
                return View("Index");
            }
            else
            {
                hd.TrangThai = HD.TrangThai;
                hoaDonSevice.UpdateHoaDon(hd);
                return RedirectToAction("QlHoaDon");
            }
        }
        [HttpGet]
        public IActionResult EditHD(Guid id)
        {
            ViewData["lg"] = SessionLogin.GetObjFromSession(HttpContext.Session, "login");
            var hd = hoaDonSevice.GetAllBill().FirstOrDefault(c => c.ID == id);
            return View(hd);
        }

        public IActionResult QlHoaDon1()
        {
            ViewData["lg"] = SessionLogin.GetObjFromSession(HttpContext.Session, "login");

            Guid idnd = SessionLogin.GetObjFromSession(HttpContext.Session, "login").IDND;
            var lsthd = hoaDonSevice.GetAllBill().Where(c => c.IDND == idnd);
            return View(lsthd);
        }
        public IActionResult DetailHD(Guid id)
        {
            ViewData["lg"] = SessionLogin.GetObjFromSession(HttpContext.Session, "login");

            List<HoaDonChiTiet> lsthd = hoaDonChiTietSevice.GetAllBill().Where(c => c.IDHD == id).ToList();
            return View(lsthd);
        }
        public IActionResult DeletelHD(Guid id)
        {
            ViewData["lg"] = SessionLogin.GetObjFromSession(HttpContext.Session, "login");
            hoaDonSevice.DeleteHoaDon(id);
            return RedirectToAction("QlHoaDon");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
