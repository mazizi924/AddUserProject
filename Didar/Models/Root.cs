using System;
using System.Collections.Generic;

namespace Didar.Models
{
    public class Root
    {
        public Response Response { get; set; }
    }

    public class Response
    {
        public string Id { get; set; }
        public int Code { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string OwnerId { get; set; }
        public string CompanyId { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthDateMessageId { get; set; }
        public bool BirthDateisValid { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string WorkPhoneExtension { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public bool CanDelete { get; set; }
        public bool CanEdit { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsVIP { get; set; }
        public bool IsMine { get; set; }
        public bool HasAccess { get; set; }
        public string LeadGenerationType { get; set; }
        public string LeadStatus { get; set; }
        public string LeadType { get; set; }
        public string ContactType { get; set; }
        public bool IsCustomer { get; set; }
        public bool IsProspect { get; set; }
        public string Type { get; set; }
        public string BackgroundInfo { get; set; }
        public DateTime RegisterTime { get; set; }
        public string Position { get; set; }
        public string CustomerCode { get; set; }
        public string EconomicIssue { get; set; }
        public string NationalCode { get; set; }
        public string RegistrationNumber { get; set; }
        public string NationalID { get; set; }
        public string ZipCode { get; set; }
        public string CityTitle { get; set; }
        public string ProvinceTitle { get; set; }
        public string ProvinceId { get; set; }
        public string CityId { get; set; }
        public bool HasCompany { get; set; }
        public string CompanyName { get; set; }
        public object CompanyIsCustomer { get; set; }
        public object CompanyIsProspect { get; set; }
        public string CompanyAndPosition { get; set; }
        public double Feedback { get; set; }
        public string VisibilityType { get; set; }
        public OtherPhones OtherPhones { get; set; }
        public OtherEmails OtherEmails { get; set; }
        public Websites Websites { get; set; }
        public Addresses Addresses { get; set; }
        public BankAccounts BankAccounts { get; set; }
        public Owner Owner { get; set; }
        public ContactStatus ContactStatus { get; set; }
        public List<object> CustomFieldValues { get; set; }
        public List<object> Segments { get; set; }
        public object KeepInTouch { get; set; }
    }
    public class OtherPhones
    {
        public List<object> KeyValues { get; set; }
    }

    public class OtherEmails
    {
        public List<object> KeyValues { get; set; }
    }

    public class Websites
    {
        public List<object> KeyValues { get; set; }
    }

    public class Addresses
    {
        public List<object> KeyValues { get; set; }
    }

    public class BankAccounts
    {
        public List<object> Values { get; set; }
    }

    public class Owner
    {
        public string UserId { get; set; }
        public string DisplayName { get; set; }
        public string PictureUrl { get; set; }
    }

    public class ContactStatus
    {
    }
     
}
