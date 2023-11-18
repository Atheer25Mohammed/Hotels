using Hotels.Data;
using Hotels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotels.Controllers
{
    public class DashboardController : Controller
    {
        private readonly HotelsUserContext _context;

        public DashboardController(HotelsUserContext context)
        {
            _context = context; 
            
        }
        public IActionResult Delete(int id)
        {
            var hotelDel=_context.hotel.SingleOrDefault(x=>x.id==id);   
            if (hotelDel!=null)
            {
                _context.hotel.Remove(hotelDel);    
                _context.SaveChanges();
                 TempData["Del"] = "Ok";
            }

            return RedirectToAction("Index");
        }

        public IActionResult CreateNewRooms(Rooms rooms)
        {
            _context.rooms.Add(rooms);
            _context.SaveChanges();
			return RedirectToAction("Rooms");
		}

        public IActionResult CreateNewRoomDetails(RoomDetails roomDetails)
        {
            _context.roomDetails.Add(roomDetails);
            _context.SaveChanges();
            return RedirectToAction("RoomDetails");
        }

        [HttpPost]
		public IActionResult Index(string city)
		{
			var hotel = _context.hotel.Where(x=>x.City.Equals(city));
			return View(hotel);
		}

		public IActionResult RoomDetails()
        {
            var hotel = _context.rooms.ToList();
            ViewBag.hotel = hotel;


            var roomDetails = _context.rooms.ToList();
            return View(roomDetails);

		}
		public IActionResult Rooms()
		{

            var hotel=_context.hotel.ToList();  
            ViewBag.hotel=hotel;  
            
            var rooms=_context.rooms.ToList();

			return View(rooms);
		}
        [Authorize]
		public IActionResult Index()
        {
            var hotel=_context.hotel.ToList();
            return View(hotel);
        }
		//ModelState.IsValid
		public IActionResult CreateNewHotel(Hotel hotels)
        {
            if(ModelState.IsValid)
            {
                _context.hotel.Add(hotels);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            var hotel = _context.hotel.ToList();
            return View("index", hotel);

		}
        [HttpPost]
        [ValidateAntiForgeryToken]
        

        public IActionResult Update(Rooms rooms)
        {
            if (ModelState.IsValid)
            {
                _context.rooms.Update(rooms);
                _context.SaveChanges();
                return RedirectToAction("Rooms");

            }
            return View(rooms);
        }
        public IActionResult EditRoom(int id)
        {
            var room = _context.rooms.SingleOrDefault(x => x.Id == id);
            return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       
		public IActionResult Update(Hotel hotel)
		{
			if (ModelState.IsValid)
			{
				_context.hotel.Update(hotel);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}

			return View("Edit");


		}
		public IActionResult Edit(int id)
		{
			var hoteledit = _context.hotel.SingleOrDefault(x => x.id == id);

			return View(hoteledit);
		}
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(RoomDetails roomDetails)
        {
            if (ModelState.IsValid)
            {
                _context.roomDetails.Update(roomDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(roomDetails);
        }
        public IActionResult EditRoomDitails(int id)
        {
            var roomDitails = _context.rooms.SingleOrDefault(x => x.Id == id);
            return View(roomDitails);
        }
    }
}
