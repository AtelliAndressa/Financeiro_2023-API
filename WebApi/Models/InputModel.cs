namespace WebApi.Models
{
    /// <summary>
    /// email e password do usuario para geração de token
    /// </summary>
    public class InputModel
    {
        public string Email { get; set; }   

        public string Password { get; set; }
    }
}
