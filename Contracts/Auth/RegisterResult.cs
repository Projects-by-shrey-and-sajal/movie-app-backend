namespace MovieBooking.API.Contracts.Auth
{
    public class RegisterResult
    {
        public bool Succeeded { get; set; }=false;
        public bool EmailAlreadyExists { get; set; }=false;
        public RegisterResponse? RegisterResponse { get; set; }=null;
        public IEnumerable<string> Errors { get; set; }=[];
    }
}