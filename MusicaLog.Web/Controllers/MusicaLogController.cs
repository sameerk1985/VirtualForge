using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using PagedList;
using System.Configuration;
using System;

namespace MusicaLog.Web.Controllers
{
    public class MusicaLogController : Controller
    {
        private readonly MusicaLogService.MusicaLogServiceClient MusicaLogServiceClient = new MusicaLogService.MusicaLogServiceClient();

        public MusicaLogController()
        {
        }

        // GET: MusicaLog
        public async Task<ActionResult> Index(string sortOrder, int? page)
        {
            ViewBag.AlbumSortParam = string.IsNullOrEmpty(sortOrder) ? "album" : "";
            ViewBag.ArtistSortParam = string.IsNullOrEmpty(sortOrder) ? "artist" : "";
            ViewBag.TypeSortParam = string.IsNullOrEmpty(sortOrder) ? "type" : "";
            ViewBag.StockSortParam = string.IsNullOrEmpty(sortOrder) ? "stock" : "";

            var musicaLogs = from s in await MusicaLogServiceClient.GetMusicaLogsAsync() select s;

            switch (sortOrder)
            {
                case "album":
                    musicaLogs = musicaLogs.OrderByDescending(s => s.AlbumName);
                    break;
                case "artist":
                    musicaLogs = musicaLogs.OrderBy(s => s.Artist);
                    break;
                case "type":
                    musicaLogs = musicaLogs.OrderByDescending(s => s.Type);
                    break;
                case "stock":
                    musicaLogs = musicaLogs.OrderByDescending(s => s.Stock);
                    break;
                default:
                    musicaLogs = musicaLogs.OrderBy(s => s.AlbumName);
                    break;
            }

            int pageSize = string.IsNullOrEmpty(ConfigurationManager.AppSettings["pageSize"]) ?  3 : Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
            int pageNumber = (page ?? 1);

            return View(musicaLogs.ToPagedList(pageNumber, pageSize));
        }

        // GET: MusicaLog/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var musicaLog = await MusicaLogServiceClient.GetMusicaLogAsync(id);

            if (musicaLog == null)
            {
                return HttpNotFound();
            }

            return View(musicaLog);
        }

        // GET: MusicaLog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MusicaLog/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "AlbumName,Artist,Type,Stock")] Common.Models.MusicaLog musicaLog)
        {
            if (ModelState.IsValid)
            {
                await MusicaLogServiceClient.AddMusicaLogAsync(musicaLog);
                return RedirectToAction("Index");
            }

            return View(musicaLog);
        }

        // GET: MusicaLog/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var musicaLog = await MusicaLogServiceClient.GetMusicaLogAsync(id);
            
            if (musicaLog == null)
            {
                return HttpNotFound();
            }

            return View(musicaLog);
        }

        // POST: MusicaLog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,AlbumName,Artist,Type,Stock")] Common.Models.MusicaLog musicaLog)
        {
            if (ModelState.IsValid)
            {
                await MusicaLogServiceClient.UpdateMusicaLogAsync(musicaLog);
                return RedirectToAction("Index");
            }
            return View(musicaLog);
        }

        // GET: MusicaLog/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var musicaLog = await MusicaLogServiceClient.GetMusicaLogAsync(id);

            if (musicaLog == null)
            {
                return HttpNotFound();
            }
            return View(musicaLog);
        }

        // POST: MusicaLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await MusicaLogServiceClient.DeleteMusicaLogAsync(id);
            return RedirectToAction("Index");
        }
    }
}
