
using System.Web.Mvc;
using CjChan.Models;

namespace CjChan.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPost(Post post)
        {



            return View();
        }
    }
}