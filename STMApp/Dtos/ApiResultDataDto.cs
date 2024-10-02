namespace STMApp.Dtos
{
    public class ApiResultDataDto<T> : ApiResultDto
    {
        public T Data { get; set; }
    }
}
