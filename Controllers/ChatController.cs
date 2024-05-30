#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2023
// Part: 2
#endregion

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10023767_PROG.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ST10023767_PROG.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ChatController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly LocalDbContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ChatController(LocalDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var messages = await _context.Collaboration.OrderBy(m => m.TimeSent).ToListAsync();
            return Json(messages);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] ChatMessage message)
        {
            message.TimeSent = DateTime.Now;
            _context.Collaboration.Add(message);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
