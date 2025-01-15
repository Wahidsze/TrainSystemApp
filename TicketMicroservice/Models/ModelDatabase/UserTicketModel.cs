﻿namespace TicketMicroservice.Models.ModelDatabase
{
    public class UserTicketModel : BaseModel
    {
        public Guid UserId { get; set; }
        public Guid TicketId { get; set; }
        public bool IsBuying { get; set; }
    }
}
