namespace BlogApp.utility
{
    public class Response
    {
        public object Data { get; set; }
        public string? Message { get; set; }
        public int? status { get; set; }

        public Response(object data,string? message,int? status) { 
            this.Data = data;
            this.Message = message;
            this.status = status;
        }
    }
}
