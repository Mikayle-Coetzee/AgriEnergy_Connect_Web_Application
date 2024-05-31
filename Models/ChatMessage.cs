#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

namespace ST10023767_PROG.Models
{
    /// <summary>
    /// Model class representing a chat message.
    /// </summary>
    public class ChatMessage
    {
        /// <summary>
        /// Gets or sets the unique identifier of the chat message.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username of the sender of the message.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the content of the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the message was sent.
        /// </summary>
        public DateTime TimeSent { get; set; }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
