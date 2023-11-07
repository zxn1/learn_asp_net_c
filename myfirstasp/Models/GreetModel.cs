namespace myfirstasp.Models;

public class GreetModel
{
    private string _message;

    public string Message
    {
        get
        {
            return _message;
        }
        set
        {
            _message = value;
        }
    }

    //apabila disingkatkan jadi bawh je
    //public string Message { get; set; } //private tu pun tak perlu declare

    //but boleh je guna mcm bawah ni
    public string getMessage()
    {
        return _message;
    }

    //tapi kalau guna getMessage() tidak digalakkan.
    //better guna get set ni je
}
