namespace BloodBankAPI.Helper
{
    public class ResultResponse
    {
        protected ResultResponse(bool success,string caption,string message)
        {
            this.Status = success;
            this.Caption = caption;
            this.Message = message;
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public string Caption { get; set; }
        public static ResultResponse Success(string caption=null,string message=null)
        {
            return new ResultResponse(true,caption,message);
        }
        public static ResultResponse Failed(string caption,string messgae=null)
        {
            return new ResultResponse(false,caption,messgae);
        }
        public static ResultResponse<T> Success<T>(T data,string caption, string message = null)
        {
            return new ResultResponse<T>(data, true, caption, message);
        }

    }
    public class ResultResponse<T> : ResultResponse
    {
        public ResultResponse(T data,bool success,string caption,string message) :base(success,caption,message)
        {
            this.Data = data;
        }
        public T Data { get; set; }
    }
}
