#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
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
    /// Controller for handling chat-related actions.
    /// </summary>
    public class ChatController : Controller
    {
        /// <summary>
        /// Database context for interacting with local database.
        /// </summary>
        private readonly LocalDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatController"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public ChatController(LocalDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all chat messages from the database.
        /// </summary>
        /// <returns>A JSON result containing the chat messages.</returns>
        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var messages = await _context.Collaboration.OrderBy(m => m.TimeSent).ToListAsync();
            return Json(messages);
        }

        /// <summary>
        /// Sends a new chat message to the database.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <returns>An HTTP status code indicating the result of the operation.</returns>
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
