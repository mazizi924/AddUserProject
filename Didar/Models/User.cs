using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Models
{
    public class User
    {
        public Contact Contact { get; set; }
    }
    public class Contact
    {
        public string Id { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string OwnerId { get; set; }
        public string CustomerCode { get; set; }
        public List<string> SegmentIds { get; set; }
    }

    public class Result
    {
        public Response Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    } 

     
}
